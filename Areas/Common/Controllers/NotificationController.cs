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

            NotificationViewModel nvm = new NotificationViewModel();

            if(!this.User.Identity.IsAuthenticated){
                return NotFound();
            }
           
            if(noti_type =="NotiRole" || noti_type==null )
            {
                var notifications = await _db.NotiRole
                                    .Where( n=>
                                            n.SendToUser== claim.Value ||
                                            (n.SendToUser == "All_A" && is_admin )
                                    )
                                    .Include(nr => nr.User)
                                    .ToListAsync();
              
                foreach(var n in notifications){
                    NotiRole nr = new NotiRole(){
                        Id = n.Id,
                        Message = n.Message,
                        User= n.User,
                        UserID = n.UserID,
                        NotiDate = n.NotiDate,
                        Seen = n.Seen,
                        SendToUser = n.SendToUser,
                    
                    };
                    nvm.NotiRole.Add(nr);
                    n.Seen = true;
                }
                _db.UpdateRange(notifications);

            }


            
            await _db.SaveChangesAsync();
            nvm.Type = noti_type;
            return View(nvm);
           
           

        }

        public async Task<IActionResult> Dismiss(int? id,string type)
        {
            if(id ==null)
                return NotFound();
            
            var noti = await _db.Notification.FirstOrDefaultAsync(n => n.Id==id);
            
            if(noti == null)
                return NotFound();
            
            _db.Notification.Remove(noti);
            await _db.SaveChangesAsync();
            Console.WriteLine(type);
            return RedirectToAction("Index","Notification",type);


        }

        public async Task<IActionResult> DismissAll(string type)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            bool is_admin = this.User.IsInRole(SD.ManagerUser);


           if(type =="NotiRole" || type ==null){
               var notifications = await _db.NotiRole
                                    .Where( n=>
                                            n.SendToUser== claim.Value ||
                                            (n.SendToUser == "All_A" && is_admin )
                                    )
                                    .Include(nr => nr.User)
                                    .ToListAsync();
                _db.RemoveRange(notifications);
           }

           await _db.SaveChangesAsync();
           return RedirectToAction("Index","Notification",type);

        }
       

        
    }
}
