using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ISProject.Data;
using ISProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ISProject.Utils
{
    public static class NotiApi
    {
        public static void SetSeen(Notification n){
            n.Seen=true;  
           
        }

        public static async Task<bool> SendNotiRole(ApplicationDbContext db,string UserId, DateTime? date = null)
        {
            if(date ==null)
                date = DateTime.Now;
            

            var user = await db.User.FirstOrDefaultAsync(u => u.Id==UserId);
            if(user == null)
                return false;

            var noti_role = new NotiRole(){
                Message = "The Customer " + user.Name + " wants to become in to a seller",
                NotiDate = (DateTime)date,
                Seen = false,
                UserID = UserId,
                User = user,
                SendToUser = "All_A",
            };
            await db.NotiRole.AddAsync(noti_role);
            await db.SaveChangesAsync();
            
            return true;
        }

        public static async Task<bool> SendNotiBuy(ApplicationDbContext db,string BuyerID,OrderHeader OrderHeader,List<OrderDetails> OrderDetails, DateTime? date = null){
            if(date ==null)
                date = DateTime.Now;


            var noti_buy = new NotiBuy(){
                Message = "You have bought a total of " + OrderDetails.Count().ToString() + 
                            " different products for a total of " + "$"+OrderHeader.TotalPrice.ToString(),
                NotiDate = (DateTime)date,
                Seen = false,
                OrderHeader = OrderHeader,
                SendToUser = BuyerID,
            };

            await db.NotiBuy.AddAsync(noti_buy);
            await db.SaveChangesAsync();
            
            return true;


        }

        public static async Task<bool> SendNotiSells(ApplicationDbContext db, List<OrderDetails> orderDetails, DateTime? date = null)
        {
            if(date ==null)
                date = DateTime.Now;
            
            foreach(var od in orderDetails){
                var seller = od.ProductSale.Seller;
                var noti_sell = new NotiSell()
                {
                    SendToUser = seller.Id,
                    NotiDate = (DateTime)date,
                    Message = "You have sold " + od.Count + " Unit(s) of " + od.Name,
                    Seen = false,
                    OrderDetails=od,
                    OrderDetailsID = od.Id,
                };
                await db.NotiSell.AddAsync(noti_sell);
                await db.SaveChangesAsync();

            }
            
            return true;
            
        }
            
    }
}