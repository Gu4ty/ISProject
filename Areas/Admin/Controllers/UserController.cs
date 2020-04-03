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
    }
}
