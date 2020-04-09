using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISProject.Data;
using ISProject.Models.ViewModels;
using ISProject.Models;


namespace ISProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            OrderDetailsCart detailCart = new OrderDetailsCart()
            {
                OrderHeader = new OrderHeader()
            };

            detailCart.OrderHeader.TotalPrice = 0;

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var cart = _db.ShoppingCart.Where(c => c.UserId == claim.Value);

            if(cart != null)
            {
                detailCart.listCart = cart.ToList();
            }

            foreach(var item in detailCart.listCart)
            {
                item.ProductSale = await _db.ProductSale.Include(m => m.Product).Where(m => m.Id == item.ProductSaleID).FirstOrDefaultAsync();
                detailCart.OrderHeader.TotalPrice += (item.ProductSale.Price * item.Count);
                if(item.ProductSale.Product.Description.Length > 100)
                {
                    item.ProductSale.Product.Description = item.ProductSale.Product.Description.Substring(0, 99) + "...";
                }
            }
 
            return View(detailCart);
        }
    }
   
}