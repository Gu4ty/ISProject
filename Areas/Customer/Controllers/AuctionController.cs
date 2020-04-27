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
                        var product = await _db.ProductSale.Include(p => p.Product).Where(p => p.Id == item.ProductSale.Id).FirstOrDefaultAsync();
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
            var list = JsonConvert.DeserializeObject<List<ProductsAuctionViewModel>>(TempData["selectedProducts"].ToString());

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
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    CurrentPrice = total,
                    PriceStep = total / 20,
                    SellerId = claim.Value,
                    User = user
                }
            };
            return View(auction);
        }
    }
}
