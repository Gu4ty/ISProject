using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ISProject.Data;
using ISProject.Models.ViewModels;
using ISProject.Models;
using ISProject.Utils;


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

        public async Task<IActionResult> Summary()
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
            }

            detailCart.OrderHeader.OrderTime = DateTime.Now;
            detailCart.OrderHeader.User = await _db.User.Where(u => u.Id == claim.Value).FirstOrDefaultAsync();
            detailCart.OrderHeader.UserId = claim.Value;
 
            return View(detailCart);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPost(OrderDetailsCart detailCart)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            User user =  await _db.User.Where(u => u.Id == claim.Value).FirstOrDefaultAsync();
            
            detailCart.listCart = await _db.ShoppingCart.Where(c => c.UserId == claim.Value).ToListAsync();
            
            detailCart.OrderHeader.TotalPrice = 0;
            detailCart.OrderHeader.User = user;
            detailCart.OrderHeader.UserId = claim.Value;
            detailCart.OrderHeader.OrderTime = DateTime.Now;

            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            _db.OrderHeader.Add(detailCart.OrderHeader);
            await _db.SaveChangesAsync();


            foreach(var item in detailCart.listCart)
            {
                item.ProductSale = await _db.ProductSale.Include(p => p.Product).Where(p => p.Id == item.ProductSaleID).FirstOrDefaultAsync();
                OrderDetails orderDetails = new OrderDetails()
                {
                    OrderId = detailCart.OrderHeader.Id,
                    OrderHeader = detailCart.OrderHeader,
                    ProductId = item.ProductSaleID,
                    ProductSale = item.ProductSale,
                    Count = item.Count,
                    Price = item.ProductSale.Price,
                    Name = item.ProductSale.Product.Name,
                    Description = item.ProductSale.Product.Description
                };
                orderDetailsList.Add(orderDetails);
                detailCart.OrderHeader.TotalPrice += orderDetails.Count * orderDetails.Price;
                _db.OrderDetails.Add(orderDetails);
            }

            _db.ShoppingCart.RemoveRange(detailCart.listCart);
            HttpContext.Session.SetInt32(SD.ssShoppingCartCount, 0);

            await _db.SaveChangesAsync();

            //If the purchase was done send a Notification 
            await NotiApi.SendNotiBuy(_db,claim.Value,detailCart.OrderHeader,orderDetailsList);

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Plus(int id)
        {
            var cart = await _db.ShoppingCart.Where(s => s.Id == id).FirstOrDefaultAsync();
            cart.Count += 1;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Minus(int id)
        {
            var cart = await _db.ShoppingCart.Where(s => s.Id == id).FirstOrDefaultAsync();
            if(cart.Count == 1)
            {
                _db.ShoppingCart.Remove(cart);
                await _db.SaveChangesAsync();

                var cnt = _db.ShoppingCart.Where(u => u.UserId == cart.UserId).ToList().Count();
                HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);
            }
            else
            {
                cart.Count -= 1;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Remove(int id)
        {
            var cart = await _db.ShoppingCart.Where(s => s.Id == id).FirstOrDefaultAsync();

            _db.ShoppingCart.Remove(cart);
            await _db.SaveChangesAsync();

            var cnt = _db.ShoppingCart.Where(u => u.UserId == cart.UserId).ToList().Count();
            HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);

            return RedirectToAction(nameof(Index));
        }
    }
   
}