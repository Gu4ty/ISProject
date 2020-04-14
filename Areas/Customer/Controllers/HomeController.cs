using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ISProject.Data;
using ISProject.Models;
using ISProject.Utils;

namespace ISProject.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger){
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim != null)
            {
                var cnt = _db.ShoppingCart.Where(u => u.UserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);
            }

            return View(await _db.ProductSale.Include(s => s.Product).Include(s => s.Seller).Where(s => s.Units > 0).ToListAsync());
        }


        [Authorize]
        public async Task<IActionResult> Details(int id){
            var product = await _db.ProductSale.Include(s => s.Product)
                                .Include(s => s.Seller).Where(s => s.Id == id).FirstOrDefaultAsync();
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var user = await _db.User.Where(s => s.Id == claim.Value).FirstAsync();

            ShoppingCart shcart = new ShoppingCart(){
                ProductSale = product,
                ProductSaleID = product.Id,
                User = user,
                UserId = claim.Value
            };

            return View(shcart);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ShoppingCart shCart)
        {
            shCart.Id = 0;
            if(ModelState.IsValid)
            {
                ShoppingCart cartFromDB = await _db.ShoppingCart.Where(c => c.UserId == shCart.UserId
                                    && c.ProductSaleID == shCart.ProductSaleID).FirstOrDefaultAsync();
                    
                if(cartFromDB == null)
                {
                    await _db.ShoppingCart.AddAsync(shCart);
                }
                else
                {
                    cartFromDB.Count = cartFromDB.Count + shCart.Count;
                }
                await _db.SaveChangesAsync();


                var count = _db.ShoppingCart.Where(c => c.UserId == shCart.UserId).ToList().Count();
                HttpContext.Session.SetInt32(SD.ssShoppingCartCount, count);

                return RedirectToAction("Index");
            }
            
            var product = await _db.ProductSale
                                .Include(s => s.Product)
                                .Include(s => s.Seller)
                                .Where(s => s.Id == shCart.ProductSaleID)
                                .FirstOrDefaultAsync();
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var user = await _db.User.Where(s => s.Id == claim.Value).FirstAsync();

            ShoppingCart newCart = new ShoppingCart(){
                ProductSale = product,
                ProductSaleID = product.Id,
                User = user,
                UserId = claim.Value
            };
            return View(newCart);
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
