using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ISProject.Data;
using ISProject.Models;
using ISProject.Models.ViewModels;

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
            return View(await _db.ProductSale.Include(s => s.Product).Include(s => s.Seller).ToListAsync());
        }


        [Authorize]
        public async Task<IActionResult> Details(int id){
            var product = await _db.ProductSale.Include(s => s.Product).Include(s => s.Seller).Where(s => s.Id == id).FirstOrDefaultAsync();

            ShoppingCart shcart = new ShoppingCart(){
                ProductSale = product,
                ProductSaleID = product.Id
            };

            return View(shcart);
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
