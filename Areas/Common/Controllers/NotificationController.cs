using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ISProject.Data;
using ISProject.Models;
using ISProject.Models.ViewModels;
using System.Security.Claims;
using ISProject.Utils;

namespace ISProject.Controllers
{
    
    [Area("Common")]
    public class NotificationController : Controller
    {
       
        private readonly ApplicationDbContext _db;

        public NotificationController(ApplicationDbContext db){
            _db = db;
            
        }

        public async Task<IActionResult> Index(string noti_type)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            bool is_admin = this.User.IsInRole(SD.ManagerUser);

            if(!this.User.Identity.IsAuthenticated){
                return NotFound();
            }

            if(noti_type ==null || noti_type == "All" )
            {
                var notifications = await _db.Notification
                                    .Where( n=>
                                            n.SendToUser== claim.Value ||
                                            (n.SendToUser == "All_A" && is_admin )
                                    )
                                    .ToListAsync();
                return View(notifications);
            }
            return NotFound();
        }

       

        
    }
}
