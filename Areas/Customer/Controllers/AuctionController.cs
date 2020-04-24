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
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var products = await _db.ProductSale.Include(p => p.Product)
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
        public IActionResult Select(List<ProductsAuctionViewModel> prodAuctionList)
        {
            var newProdList = new List<ProductsAuctionViewModel>();
            foreach(var item in prodAuctionList){
                if(item.Quantity > 0){
                    if(item.Quantity > item.ProductSale.Units){
                        item.Quantity = item.ProductSale.Units;
                    }
                    newProdList.Add(item);
                }
            }    

            return RedirectToAction("Create", newProdList);
        }

        public async Task<IActionResult> Create(List<ProductsAuctionViewModel> prodAuctionList){
            return View();
        }
    }
}
