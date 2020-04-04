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
using Microsoft.EntityFrameworkCore;

namespace ISProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SellerController(ApplicationDbContext db)
        {
            _db=db;
        }
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var products = await _db.ProductSale.Where(u => u.SellerId == claim.Value).ToListAsync();
            
            return View(products);
        }

        //GET - Create
        public async Task<IActionResult> Create()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ProductSellerViewModel ps = new ProductSellerViewModel(){
                Products = await _db.Product.ToListAsync(),
                ProductSale = new ProductSale{
                    SellerId = claim.Value
                }
            };
            return View(ps);
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductSellerViewModel model)
        {
            // var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            // var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // model.ProductSale.SellerId = claim.Value;

            if(ModelState.IsValid)
            {
                _db.ProductSale.Add(model.ProductSale);
                await _db.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            Console.WriteLine("NO fue valido");
            ProductSellerViewModel ps = new ProductSellerViewModel(){
                Products = await _db.Product.ToListAsync(),
                ProductSale = model.ProductSale
            };
            return View(ps);
        }


        //GET - Create Product
        public IActionResult CreateProduct()
        {
            return View();
        }


        //POST - CreateProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product model)
        {
            if(ModelState.IsValid)
            {
                var prodExists = _db.Product.Where(s => s.Name == model.Name && s.Description == model.Description);
                if(prodExists.Count() > 0){
                    //Error
                }
                else{
                    _db.Product.Add(model);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
                }
            }
            return View(model);            
        }

    }
}
