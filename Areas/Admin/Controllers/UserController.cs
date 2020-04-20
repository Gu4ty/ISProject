using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ISProject.Models;
using ISProject.Models.ViewModels;
using ISProject.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ISProject.Utils;

namespace ISProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db=db;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var sellerList = await _db.Seller.Where(u=>u.Id != claim.Value).ToListAsync();
            var userList =  await _db.User.Where(u=>u.Id != claim.Value).ToListAsync();

            List<User> regularUser = new List<User>();
            bool ok = true;
            foreach(var user in userList){
                ok = true;
                foreach(var seller in sellerList){
                    if(seller.Id == user.Id){
                        ok = false;
                        break;
                    }
                }
                if(ok){
                    regularUser.Add(user);
                }
            }

            UserViewModel uvm = new UserViewModel();
            uvm.Sellers = sellerList;
            uvm.Users = regularUser;
            
            return View(uvm);
        }
        [Authorize]
        public async Task<IActionResult> SellsDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.Seller
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var ps = await _db.ProductSale.Where(seller => seller.SellerId == id).ToListAsync();
            return View(ps);
        }
        [Authorize]
        public async Task<IActionResult> BuysDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShoppingHistoryModel orders = new ShoppingHistoryModel(){
                UserId = id,
                Orders = await _db.OrderHeader.Where(p => p.UserId == id).ToListAsync()
            };
           
            return View(orders);
        }

        public async Task<IActionResult> ShopDetails(int id){
            var order = await _db.OrderHeader.Where(p => p.Id == id).FirstOrDefaultAsync();
            if(order == null)
            {
                return NotFound();
            }
            var items = new OrderDetailModel(){
                UserId = order.UserId,
                Products = await _db.OrderDetails.Where(p => p.OrderId == order.Id).ToListAsync(),
                Price = order.TotalPrice
            };

            return View(items);
        }

        [Authorize]
         public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] User user)
        {
            string role = Request.Form["rdUserRole"].ToString();
            Console.WriteLine(role);

            if (id != user.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    User userBd = await _db.User.FindAsync(id);
                    
                    if(role == SD.SellerUser)
                    {
                        if(await _db.Seller.FindAsync(id) == null)
                        {   
                            // Console.WriteLine("customer to seller");
                            _db.User.Remove(userBd);
                            await _db.SaveChangesAsync();
                            
                            Console.WriteLine(userBd.Id);
                            userBd.UserName = user.UserName;
                            userBd.Email = user.Email;
                            userBd.PhoneNumber = user.PhoneNumber;
                            userBd.AccessFailedCount = user.AccessFailedCount;
                            Seller sel = CreateSellerFromUser(userBd);
                            _db.Seller.Add(sel);
                        }
                        else
                        {
                            userBd.UserName = user.UserName;
                            userBd.Email = user.Email;
                            userBd.PhoneNumber = user.PhoneNumber;
                            userBd.AccessFailedCount = user.AccessFailedCount;
                            _db.Update(userBd);
                        }
                    }
                    else
                    {
                        if(await _db.Seller.FindAsync(id) != null)
                        {   
                            // Console.WriteLine("seller to costumer");
                            Seller sel = await _db.Seller.FindAsync(id);
                            _db.Seller.Remove(sel);
                            await _db.SaveChangesAsync();

                            // Console.WriteLine(sel.Id);

                            User us = CreateUserFromSeller(sel);
                            us.UserName = user.UserName;
                            us.Email = user.Email;
                            us.PhoneNumber = user.PhoneNumber;
                            us.AccessFailedCount = user.AccessFailedCount;
                            _db.User.Add(us);
                            await _db.SaveChangesAsync();
                        }
                        else
                        {
                            userBd.UserName = user.UserName;
                            userBd.Email = user.Email;
                            userBd.PhoneNumber = user.PhoneNumber;
                            userBd.AccessFailedCount = user.AccessFailedCount;
                            _db.User.Update(userBd);
                        }
                    }
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _db.User.FindAsync(id);
            _db.User.Remove(user);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _db.User.Any(e => e.Id == id);
        }
        public User CreateUserFromSeller(Seller userBd)
        {
            return new User()
            {
                Id = userBd.Id,
                Name = userBd.Name,
                UserName = userBd.UserName,
                NormalizedUserName = userBd.NormalizedUserName,
                Email = userBd.Email,
                NormalizedEmail = userBd.NormalizedEmail,
                EmailConfirmed = userBd.EmailConfirmed,
                PasswordHash = userBd.PasswordHash,
                SecurityStamp = userBd.SecurityStamp
            };
        }
        public Seller CreateSellerFromUser(User userBd)
        {
            return new Seller()
            {
                Id = userBd.Id,
                Name = userBd.Name,
                UserName = userBd.UserName,
                NormalizedUserName = userBd.NormalizedUserName,
                Email = userBd.Email,
                NormalizedEmail = userBd.NormalizedEmail,
                EmailConfirmed = userBd.EmailConfirmed,
                PasswordHash = userBd.PasswordHash,
                SecurityStamp = userBd.SecurityStamp,
                Rating = 0
            };
        }
        
        public async Task<IActionResult> Lock(string id)
        {
            if(id==null){
                return NotFound();
            }
            var user = await _db.User.Where(m => m.Id==id).FirstOrDefaultAsync();
            if(user ==null){
                return NotFound();
            }
            user.LockoutEnd = DateTime.Now.AddYears(1000);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> UnLock(string id)
        {
            if(id==null){
                return NotFound();
            }
            var user = await _db.User.Where(m => m.Id==id).FirstOrDefaultAsync();
            if(user ==null){
                return NotFound();
            }
            user.LockoutEnd = DateTime.Now;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
