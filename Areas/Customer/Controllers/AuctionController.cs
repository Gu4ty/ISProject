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

        public async Task<IActionResult> Index()
        {

            var auctions = await _db.AuctionHeader.Include(a=> a.User).ToListAsync();
            List<AuctionItemViewModel> auItems = new List<AuctionItemViewModel>();

            var auction_products = await _db.AuctionProduct.Include(a=>a.Product).ToListAsync();

            List<Product> LoadProducts(AuctionHeader auction, List<AuctionProduct> a_products)
            {
                List<Product> load = new List<Product>();
                int id = auction.Id;
                foreach(var ap in a_products){
                    if(ap.AuctionId == id)
                        load.Add(ap.Product);
                }

                return load;
            }
                
            foreach(var a in auctions){
                var item = new AuctionItemViewModel();
                item.AuctionHeader = a;
                item.Products = LoadProducts(a,auction_products);
                auItems.Add(item);
                
            }
            
            return View(auItems);
        
            
            // bool UserParticipate(int auction_id, List<AuctionUser> auctions)
            // {
            //     foreach(var a in auctions)
            //         if(a.AuctionId == auction_id)
            //             return true;
                
            //     return false;
            // }

            // var user_auctions = await _db.AuctionUser.Where(a=> a.UserId == id ).ToListAsync();

            // var view_auction = new List<AuctionHeader>();

            // foreach(var a in auctions)
            // {
            //     if(UserParticipate(a.Id,user_auctions))
            //         view_auction.Add(a);
            // }

            // foreach(var a in view_auction){
            //         var item = new AuctionItemViewModel();
            //         item.AuctionHeader = a;
            //         item.Products = LoadProducts(a,auction_products);
            //         auItems.Add(item);
                    
            // }

            // return View(auItems);
        }

        [Authorize]
        public async Task<IActionResult> FilterByUser()
        {
        
            List<Product> LoadProducts(AuctionHeader auction, List<AuctionProduct> a_products)
            {
                List<Product> load = new List<Product>();
                int id = auction.Id;
                foreach(var ap in a_products){
                    if(ap.AuctionId == id)
                        load.Add(ap.Product);
                }

                return load;
            }
                 
            bool UserParticipate(int auction_id, List<AuctionUser> auctions)
            {
                foreach(var a in auctions)
                    if(a.AuctionId == auction_id)
                        return true;
                
                return false;
            }

            var auctions = await _db.AuctionHeader.Include(a=> a.User).ToListAsync();
            List<AuctionItemViewModel> auItems = new List<AuctionItemViewModel>();

            var auction_products = await _db.AuctionProduct.Include(a=>a.Product).ToListAsync();

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
                    item.Products = LoadProducts(a,auction_products);
                    auItems.Add(item);
                    
            }

            return View("../Auction/Index", auItems);
           
            
        }

        
        [Authorize(Roles=SD.SellerUser)]
        public async Task<IActionResult> Select()
        {
            return View();
        }


    }
}
