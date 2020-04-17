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

            var products = await _db.ProductSale.Include(s => s.Product).Where(u => u.SellerId == claim.Value).ToListAsync();
            
            return View(products);
        }

        //GET - Create
        public async Task<IActionResult> Create()
        {
            ProductSellerViewModel ps = new ProductSellerViewModel(){
                Products = await _db.Product.ToListAsync(),
                ProductSale = new ProductSale()
            };

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var seller = await _db.Seller.Where(s => s.Id == claim.Value).FirstAsync();
            ps.ProductSale.Seller = seller;
            ps.ProductSale.SellerId = claim.Value;

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
                var product = await _db.Product.Where(s => s.Id == model.ProductSale.ProductId).FirstAsync();
                model.ProductSale.Product = product;
                _db.ProductSale.Add(model.ProductSale);
                await _db.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
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

        public async Task<IActionResult> Details(int id){
            ProductSale ps = await _db.ProductSale.Include(p => p.Product).Where(p => p.Id == id).FirstAsync();
            if(ps != null){
                return View(ps);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ProductSale model){
            ProductSale ps = await _db.ProductSale.Include(p => p.Product).Where(p => p.Id == model.Id).FirstAsync();
            if(ps != null){
                ps.Price = model.Price;
                ps.Units = model. Units;

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(ps);
        }

    }
}
