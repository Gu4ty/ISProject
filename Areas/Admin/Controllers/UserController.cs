using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ISProject.Models;
using ISProject.Models.ViewModels;
using ISProject.Data;
using ISProject.Utils;

namespace ISProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ManagerUser)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db=db;
        }
       
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
            var ps = await _db.ProductSale.Include(p => p.Product).Where(seller => seller.SellerId == id).ToListAsync();
            ViewBag.Id = id;
            return View(ps);
        }
        
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

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _db.User.FindAsync(id);

            var currentDate = DateTime.Now;
            var auctions = await _db.AuctionHeader.Where(a => a.SellerId == user.Id 
                                        && a.BeginDate <= currentDate && a.EndDate >= currentDate)
                                        .ToListAsync();
            var msg = "The auction created by " + user.Name + ", in which you were participating, was cancelled.";
            foreach(var item in auctions){
                var users = await _db.AuctionUser.Where(a => a.AuctionId == item.Id).ToListAsync();
                foreach(var u in users){
                    NotiApi.SendNotification(_db, u.UserId, msg, currentDate);
                }
            }

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

        public async Task<IActionResult> Auctions(string id, string callBack,string status)
        {
            var user = await _db.User.Where(u => u.Id == id).FirstOrDefaultAsync();
            if(user == null){
                return NotFound();
            }
            
            var vm = new AuctionStatusViewModel();
            vm.UserId = user.Id;
            vm.CallBack = callBack;
            vm.Status = status;
            var auctions = new List<AuctionHeader>();

            if(callBack == SD.CreatedAuctions)
            {
                auctions = await _db.AuctionHeader.Include(a => a.User).Where(a => a.SellerId == user.Id).ToListAsync();
            }
            else{
                var aUsers = await _db.AuctionUser.Where(u => u.UserId == user.Id).ToListAsync();
                foreach(var a in aUsers){
                    var auction = await _db.AuctionHeader.Include(au => au.User).Where(au => au.Id == a.AuctionId).FirstOrDefaultAsync();
                    auctions.Add(auction);
                }
            }

            var currentDate = DateTime.Now;
            foreach(var item in auctions){
                var products = await _db.AuctionProduct.Include(a => a.Product).Where(a => a.AuctionId == item.Id).ToListAsync();
                var itemVM = new AuctionItemViewModel(){
                    AuctionHeader = item,
                    AuctionProduct = products,
                    CallBack = callBack
                };
                itemVM.AuctionUser = await _db.AuctionUser.Include(u => u.User).Where(u => u.AuctionId == item.Id && u.UserId == user.Id).FirstOrDefaultAsync();
                if(currentDate < item.BeginDate && status == SD.UpcomingStatus)
                    vm.Auctions.Add(itemVM);
                if(currentDate >= item.BeginDate && currentDate <= item.EndDate && status == SD.ActiveStatus)
                    vm.Auctions.Add(itemVM);
                if(currentDate > item.EndDate && status == SD.PastStatus)
                    vm.Auctions.Add(itemVM);
            }
            return View(vm);
        }

        [Authorize(Roles = SD.ManagerUser)]
        public async Task<IActionResult> DeleteAuction(int id, string userId, string callBack,string status)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var auction = await _db.AuctionHeader.Include(a => a.User).Where(a => a.Id == id).FirstOrDefaultAsync();
            if(auction == null){
                return NotFound();
            }

            var currentDate = DateTime.Now;
            var adminMsg = "You have succesfully deleted one of " + auction.User.Name + " auctions.";
            NotiApi.SendNotification(_db, claim.Value, adminMsg, currentDate);
            NotiApi.SendNotification(_db, auction.SellerId, "One of your auctions was deleted by an admin of the application", currentDate);

            var products = await _db.AuctionProduct.Where(a => a.AuctionId == id).ToListAsync();
            foreach(var ap in products)
            {
                ProductSale psale = await _db.ProductSale.Where(ps => ps.ProductId == ap.ProductId && ps.SellerId == auction.SellerId).FirstAsync();
                psale.Units += ap.Quantity;
                _db.ProductSale.Update(psale);
            }
            var users = await _db.AuctionUser.Where(a => a.AuctionId == id).ToListAsync();
            if(users != null)
            {
                var msg = "The auction created by " + auction.User.Name + ", which had a total of "
                            + products.Count().ToString() + " products and in which you were participating, was cancelled.";
                foreach(var user in users){
                    NotiApi.SendNotification(_db, user.UserId, msg, currentDate);
                }
                _db.AuctionUser.RemoveRange(users);
            }
            _db.AuctionProduct.RemoveRange(products);
            _db.AuctionHeader.Remove(auction);

            await _db.SaveChangesAsync();
            return RedirectToAction("Auctions", new{ id = userId, status = status, callBack = callBack});
        }
    }
}
