using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using ISProject.Models;
using ISProject.Models.ViewModels;
using ISProject.Data;
using ISProject.Utils;

namespace ISProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AuctionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuctionController(ApplicationDbContext db)
        {
            _db=db;
        }

        [Authorize(Roles=SD.SellerUser)]
        public async Task<IActionResult> Select()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var products = await _db.ProductSale.Include(p => p.Product).Include(p => p.Seller)
                                    .Where(p => p.SellerId == claim.Value && p.Units > 0)
                                    .ToListAsync();

            List<ProductsAuctionViewModel> prodAuctionList = new List<ProductsAuctionViewModel>();

            foreach(var prod in products){
                var prodAuction = new ProductsAuctionViewModel(){
                    ProductSale = prod,
                    Quantity = 0
                };
                prodAuctionList.Add(prodAuction);
            }

            return View(prodAuctionList);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Select(IList<ProductsAuctionViewModel> prodAuctionList)
        {
            if(ModelState.IsValid){
                var newProdList = new List<ProductsAuctionViewModel>();
                foreach(var item in prodAuctionList){
                    if(item.Quantity > 0){
                        if(item.Quantity > item.ProductSale.Units){
                            item.Quantity = item.ProductSale.Units;
                        }
                        var product = await _db.ProductSale.Include(p => p.Product).Include(p => p.Seller)
                                                        .Where(p => p.Id == item.ProductSale.Id)
                                                        .FirstOrDefaultAsync();
                        var prod = new ProductsAuctionViewModel(){
                            ProductSale = product,
                            Quantity = item.Quantity
                        };
                        newProdList.Add(prod);
                    }
                }

                TempData["selectedProducts"] = JsonConvert.SerializeObject(newProdList);
                return RedirectToAction(nameof(Create));
            }

            foreach(var modelState in ViewData.ModelState.Values){
                foreach(ModelError error in modelState.Errors){
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var products = await _db.ProductSale.Include(p => p.Product).Include(p => p.Seller)
                                    .Where(p => p.SellerId == claim.Value && p.Units > 0)
                                    .ToListAsync();

            List<ProductsAuctionViewModel> newprodAuctionList = new List<ProductsAuctionViewModel>();

            foreach(var prod in products){
                var prodAuction = new ProductsAuctionViewModel(){
                    ProductSale = prod,
                    Quantity = 0
                };
                newprodAuctionList.Add(prodAuction);
            }

            return View(newprodAuctionList);  
        }

        [Authorize(Roles=SD.SellerUser)]
        public async Task<IActionResult> Create()
        {
            var list = new List<ProductsAuctionViewModel>();
            try{
                list = JsonConvert.DeserializeObject<List<ProductsAuctionViewModel>>(TempData["selectedProducts"].ToString());
            }
            catch{
                return RedirectToAction("Index", "Seller");
            }

            double total = 0;
            foreach(var item in list){
                total += item.ProductSale.Price * item.Quantity;
            }
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var user = await _db.Seller.Where(s => s.Id == claim.Value).FirstOrDefaultAsync();

            var auction = new AuctionViewModel(){
                Products = (List<ProductsAuctionViewModel>)list,
                AuctionHeader = new AuctionHeader(){
                    Seen = false,
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    CurrentPrice = Math.Round((double)total, 2),
                    PriceStep = Math.Round((double)(total / 20), 2),
                    SellerId = claim.Value,
                    User = user
                }
            };
            return View(auction);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuctionViewModel auction)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var user = await _db.Seller.Where(s => s.Id == claim.Value).FirstOrDefaultAsync();

            if(ModelState.IsValid){
                AuctionHeader auctionHeader = new AuctionHeader(){
                    Seen = false,
                    SellerId = claim.Value,
                    User = user,
                    BeginDate = auction.AuctionHeader.BeginDate,
                    EndDate = auction.AuctionHeader.EndDate,
                    CurrentPrice = auction.AuctionHeader.CurrentPrice,
                    PriceStep = auction.AuctionHeader.PriceStep
                };
                _db.AuctionHeader.Add(auctionHeader);
                await _db.SaveChangesAsync();

                foreach(var item in auction.Products){
                    var productSale = await _db.ProductSale.Include(p => p.Product).Where(p => p.Id == item.ProductSale.Id).FirstOrDefaultAsync();
                    productSale.Units -= item.Quantity;

                    var product = await _db.Product.Where(p => p.Id == productSale.ProductId).FirstOrDefaultAsync();
                    var auctionProduct = new AuctionProduct(){
                        ProductId = product.Id,
                        Product = product,
                        AuctionId = auctionHeader.Id,
                        AuctionHeader = auctionHeader,
                        Quantity = item.Quantity
                    };
                    _db.AuctionProduct.Add(auctionProduct);
                }
                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "Seller");
            }

            foreach(var modelState in ViewData.ModelState.Values){
                foreach(ModelError error in modelState.Errors){
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return RedirectToAction(nameof(Select));

        }
        
        public async Task<IActionResult> Index(string callBack, string status)
        {
            var currentDate = DateTime.Now;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var auItems = new AuctionStatusViewModel();
            auItems.CallBack = callBack;
            auItems.Status = status;
            var auctions = await _db.AuctionHeader.Include(a => a.User).ToListAsync();

            if(callBack == SD.BidedAuctions){
                var newAuctions = new List<AuctionHeader>();
                var user_auctions = await _db.AuctionUser.Where(a => a.UserId == claim.Value).ToListAsync();
                foreach(var a in auctions){
                    if(UserParticipate(a.Id,user_auctions))
                        newAuctions.Add(a);
                }
                auctions = newAuctions;
            }
            if(callBack == SD.CreatedAuctions){
                auctions = await _db.AuctionHeader.Where(a => a.SellerId == claim.Value).Include(a => a.User).ToListAsync();
            }
          
            var filterAuctions = new List<AuctionItemViewModel>();

            foreach(var a in auctions){
                var item = new AuctionItemViewModel();
                item.AuctionHeader = a;
                item.AuctionProduct = await _db.AuctionProduct.Where(ap => ap.AuctionId == a.Id ).Include(a=> a.Product).ToListAsync();
                if(a.BeginDate > currentDate && status == SD.UpcomingStatus)
                    filterAuctions.Add(item);
                if(a.BeginDate <= currentDate && a.EndDate >= currentDate && status == SD.ActiveStatus)
                    filterAuctions.Add(item);
                if(a.EndDate < currentDate && status == SD.PastStatus)
                    filterAuctions.Add(item);
            }

            auItems.Auctions = filterAuctions;
            
            return View(auItems);
        
        }

        [Authorize]
        public async Task<IActionResult> FilterByUser()
        {
        
            var auctions = await _db.AuctionHeader.Include(a=> a.User).ToListAsync();
            List<AuctionItemViewModel> auItems = new List<AuctionItemViewModel>();


            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var id = claim.Value;

            var user_auctions = await _db.AuctionUser.Where(a=> a.UserId == id ).ToListAsync();

            var view_auction = new List<AuctionHeader>();

            foreach(var a in auctions)
            {
                if(UserParticipate(a.Id,user_auctions))
                    view_auction.Add(a);
            }

            foreach(var a in view_auction){
                    var item = new AuctionItemViewModel();
                    item.AuctionHeader = a;
                    item.AuctionProduct = await _db.AuctionProduct.Where(ap => ap.AuctionId == a.Id).Include(a=> a.Product).ToListAsync();
                    auItems.Add(item);
                    
            }

            return View("../Auction/Index", auItems);
           
            
        }

        [Authorize]
        public async Task<IActionResult> Details(int id, string status, string callBack)
        {
            var auction = await _db.AuctionHeader.Where(a => a.Id == id).Include(a => a.User).FirstOrDefaultAsync();
            if(auction == null)
                return NotFound();
            
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var vm = new AuctionItemViewModel();
            vm.AuctionHeader = auction;
            
            vm.AuctionProduct = await _db.AuctionProduct.Where(a => a.AuctionId == auction.Id).Include(a => a.Product).ToListAsync();

            var a_user = await _db.AuctionUser.Where(a => a.UserId == claim.Value && a.AuctionId == id).FirstOrDefaultAsync();
            
            if(a_user != null)
                ViewBag.Bid=true;
            else
                ViewBag.Bid=false;

            vm.AuctionUser = await _db.AuctionUser.FirstOrDefaultAsync(a => a.UserId == claim.Value && a.AuctionId==id);
            
            return View(vm);


        }

        
        [Authorize]
        public async Task<IActionResult> JoinAuction(int id)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            
            var au = await _db.AuctionHeader.FirstOrDefaultAsync(a => a.Id == id);
            

            var a_user = new AuctionUser()
            {
                UserId = claim.Value,
                AuctionId = id,
                LastPriceOffered = au.CurrentPrice + au.PriceStep
            };

            if(au.CurrentPrice < a_user.LastPriceOffered)
            {
                var outbided_user = await _db.AuctionUser.FirstOrDefaultAsync(a => a.AuctionId == au.Id && a.LastPriceOffered == au.CurrentPrice);
                if(outbided_user != null){
                    await NotiApi.SendNotiAuction(_db,"You were outbided, check the auction for more details",outbided_user.UserId,au.Id); 
                }
                await NotiApi.SendNotiAuction(_db,"You bid for $"+a_user.LastPriceOffered.ToString("F2")+" in an auction, check the auction for more details",a_user.UserId,au.Id);

                au.CurrentPrice = Math.Max(au.CurrentPrice, a_user.LastPriceOffered);
            }

            

            _db.AuctionUser.Add(a_user);
            _db.SaveChanges();

            return RedirectToAction("Details",new{id = id});
            
        }


      
        [Authorize]
        public async Task<IActionResult> QuickBid(int id) //get
        {
            
            var auction = await _db.AuctionHeader.FirstOrDefaultAsync(a=> a.Id==id);

            var vm = new QuickBidViewModel()
            {
                AuctionId = auction.Id,
                Count = 1,
                PriceStep = auction.PriceStep,
                CurrentPrice = auction.CurrentPrice
            };
            return PartialView(vm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuickBid(QuickBidViewModel qb)
        {
            
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var a_user = await _db.AuctionUser.FirstOrDefaultAsync(a=> a.UserId==claim.Value && a.AuctionId==qb.AuctionId);
            var auction = await _db.AuctionHeader.FirstOrDefaultAsync(a=> a.Id== qb.AuctionId );

            a_user.LastPriceOffered = qb.CurrentPrice + qb.Count * qb.PriceStep;
            
            
            if(auction.CurrentPrice < a_user.LastPriceOffered)
            {
                var outbided_user = await _db.AuctionUser.FirstOrDefaultAsync(a=> a.LastPriceOffered==auction.CurrentPrice);
                
                if(outbided_user.UserId != claim.Value)
                    await NotiApi.SendNotiAuction(_db,"You got outbided, check the auction for more details",outbided_user.UserId,auction.Id); 
                
                await NotiApi.SendNotiAuction(_db,"You bid for $"+a_user.LastPriceOffered.ToString("F2")+" in an auction, check the auction for more details",a_user.UserId,auction.Id);

                auction.CurrentPrice = Math.Max(auction.CurrentPrice, a_user.LastPriceOffered);
            }
            

            _db.SaveChanges();

            return RedirectToAction("Details",new{id = qb.AuctionId});
                
        }
       
        [Authorize]
        public async Task<IActionResult> CustomBid(int id) //get
        {
            var auction = await _db.AuctionHeader.FirstOrDefaultAsync(a=> a.Id==id);

            var vm = new CustomBidViewModel()
            {
                AuctionId = auction.Id,
                PriceStep = auction.PriceStep,
                CurrentPrice = auction.CurrentPrice,
                CustomBid = auction.CurrentPrice + auction.PriceStep
            };
            return PartialView(vm);
            
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomBid(CustomBidViewModel cb)
        {
            
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var a_user = await _db.AuctionUser.FirstOrDefaultAsync(a=> a.UserId==claim.Value && a.AuctionId==cb.AuctionId);
            var auction = await _db.AuctionHeader.FirstOrDefaultAsync(a=> a.Id== cb.AuctionId );

            a_user.LastPriceOffered = cb.CustomBid;
            
            if(auction.CurrentPrice < a_user.LastPriceOffered)
            {
                var outbided_user = await _db.AuctionUser.FirstOrDefaultAsync(a=> a.LastPriceOffered==auction.CurrentPrice);
                
                if(outbided_user.UserId != claim.Value)
                    await NotiApi.SendNotiAuction(_db,"You got outbided, check the auction for more details",outbided_user.UserId,auction.Id); 
                
                await NotiApi.SendNotiAuction(_db,"You bid for $"+a_user.LastPriceOffered.ToString("F2")+" in an auction, check the auction for more details",a_user.UserId,auction.Id);

                auction.CurrentPrice = Math.Max(auction.CurrentPrice, a_user.LastPriceOffered);
            }


            _db.SaveChanges();

            return RedirectToAction("Details",new{id = cb.AuctionId});
                
        }
        
        private bool UserParticipate(int auction_id, List<AuctionUser> auctions)
        {
            foreach(var a in auctions)
                if(a.AuctionId == auction_id)
                    return true;
            
            return false;
        }

        private async void Close(AuctionHeader auction)
        {
            var winner = await _db.AuctionUser.FirstOrDefaultAsync(u => u.AuctionId == auction.Id && u.LastPriceOffered == auction.CurrentPrice);

            if(winner == null)
            {
                var aproducts = await _db.AuctionProduct.Where(p => p.AuctionId == auction.Id).ToListAsync();

                foreach(AuctionProduct ap in aproducts)
                {
                    ProductSale psale = await _db.ProductSale.Where(ps => ps.ProductId == ap.ProductId && ps.SellerId == auction.SellerId).FirstAsync();

                    psale.Units += ap.Quantity;
                    _db.ProductSale.Update(psale);
                    // _db.AuctionProduct.Remove(ap);
                }

                await NotiApi.SendNotiAuction(_db,"Your auction was succefully ignored", auction.SellerId, auction.Id); 
                auction.Seen = true;
                _db.AuctionHeader.Update(auction);
            }
            else
            {
                //winner
                await NotiApi.SendNotiAuction(_db,"Congrats! You win the auction " + auction.Id.ToString() + ".", winner.UserId, auction.Id); 
                await NotiApi.SendNotiAuction(_db,"Your auction was succefully closed", auction.SellerId, auction.Id);
                auction.Seen = true;
                _db.AuctionHeader.Update(auction);
            }
            
            // _db.AuctionHeader.Remove(auction);
            _db.SaveChanges();
        } 

    }
}


