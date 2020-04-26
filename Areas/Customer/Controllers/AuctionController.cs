using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISProject.Models;
using ISProject.Models.ViewModels;
using ISProject.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
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
            return View();
        }


        public async Task<IActionResult> Index()
        {

            var auctions = await _db.AuctionHeader.Include(a=> a.User).ToListAsync();
            List<AuctionItemViewModel> auItems = new List<AuctionItemViewModel>();

            

            
                
            foreach(var a in auctions){
                var item = new AuctionItemViewModel();
                item.AuctionHeader = a;
                item.AuctionProduct = await _db.AuctionProduct.Where(ap => ap.AuctionId == a.Id ).Include(a=> a.Product).ToListAsync();
                auItems.Add(item);
                
            }
            
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
        public async Task<IActionResult> Details(int id)
        {
            var auction = await _db.AuctionHeader.Where(a => a.Id == id).Include(a=> a.User).FirstOrDefaultAsync();
            if(auction==null)
                return NotFound();
            
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var vm = new AuctionItemViewModel();
            vm.AuctionHeader = auction;
            
            
            vm.AuctionProduct = await _db.AuctionProduct.Where(a => a.AuctionId == auction.Id).Include(a=> a.Product).ToListAsync();

            var a_user = await _db.AuctionUser.Where(a => a.UserId==claim.Value && a.AuctionId == id).FirstOrDefaultAsync();
            
            if(a_user != null)
                ViewBag.Bid=true;
            else
                ViewBag.Bid=false;

            vm.AuctionUser = await _db.AuctionUser.FirstOrDefaultAsync(a=> a.UserId==claim.Value && a.AuctionId==id);
            
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
                var outbided_user = await _db.AuctionUser.FirstOrDefaultAsync(a=> a.LastPriceOffered==au.CurrentPrice);
                await NotiApi.SendNotiAuction(_db,"You were outbided, check the auction for more details",outbided_user.UserId,au.Id); 
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


    }
}
