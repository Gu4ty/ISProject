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
            if(noti_type == "NotiBuy" || noti_type == null){
                
                var notifications = await _db.NotiBuy
                                    .Where( n=>
                                            n.SendToUser== claim.Value
                                    )
                                    .Include(n=> n.OrderHeader)
                                    .Include(n => n.OrderHeader.User)
                                    .ToListAsync();

                foreach(var n in notifications){
                    n.OrderDetails = await _db.OrderDetails.Where(o=> o.OrderId == n.OrderHeaderID ).ToListAsync();
                    
                    NotiBuy nr = new NotiBuy(){
                        Id = n.Id,
                        Message = n.Message,
                        OrderHeaderID = n.OrderHeaderID,
                        OrderHeader = n.OrderHeader,
                        OrderDetails = n.OrderDetails,
                        NotiDate = n.NotiDate,
                        Seen = n.Seen,
                        SendToUser = n.SendToUser,
                    
                    };
                    
                    nvm.NotiBuy.Add(nr);
                    n.Seen = true;
                }

                _db.UpdateRange(notifications);


            }

            if(noti_type == "NotiSell" || noti_type == null){
                
                var notifications = await _db.NotiSell
                                    .Where( n=>
                                            n.SendToUser== claim.Value
                                    )
                                    .Include(n=> n.OrderDetails)
                                    .ToListAsync();
                
                foreach(var n in notifications){
                    NotiSell ns = new NotiSell(){
                        Id = n.Id,
                        Message = n.Message,
                        NotiDate = n.NotiDate,
                        Seen = n.Seen,
                        SendToUser = n.SendToUser,
                        OrderDetails = n.OrderDetails,
                        OrderDetailsID = n.OrderDetailsID,
                    };
                    nvm.NotiSell.Add(ns);
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
                                    .ToListAsync();
                _db.RemoveRange(notifications);
            }
            
            if(type == "NotiBuy" || type==null){
                var notifications = await _db.NotiBuy
                                    .Where( n=>
                                            n.SendToUser== claim.Value
                                    )
                                    .ToListAsync();
                _db.RemoveRange(notifications);
            }

            if(type == "NotiSell" || type==null){
                var notifications = await _db.NotiSell
                                    .Where( n=>
                                            n.SendToUser== claim.Value
                                    )
                                    .ToListAsync();
                _db.RemoveRange(notifications);
            } 

           await _db.SaveChangesAsync();
           return RedirectToAction("Index","Notification",type);

        }
       
        public async Task<IActionResult> BuyDetails(int id)
        {
            var noti_buy = await _db.NotiBuy
                .Where(n=> n.Id==id)
                .Include(n=> n.OrderHeader)
                .Include(n=> n.OrderDetails)
                .Include(n=> n.OrderHeader.User)
                .FirstOrDefaultAsync();
            
            return View(noti_buy);
        }
        
    }
}
