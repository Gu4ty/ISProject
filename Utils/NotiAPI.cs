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

        public static async void SendNotification(ApplicationDbContext db, string sendTo, string message ,DateTime? date = null)
        {
             if(date ==null)
                date = DateTime.Now;

            var noti = new Notification()
            {
                Message=message,
                NotiDate = (DateTime)date,
                Seen= false,
                SendToUser = sendTo
            };

            db.Notification.Add(noti);
            await db.SaveChangesAsync();
        }

        public static async Task<bool> SendNotiRole(ApplicationDbContext db,string UserId, DateTime? date = null)
        {
            if(date ==null)
                date = DateTime.Now;
            
            var prev_noti_role = await db.NotiRole.FirstOrDefaultAsync(n=>n.UserID==UserId);
            if(prev_noti_role != null)
                return false;

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
                            " different products for a total of " + "$" + (OrderHeader.TotalPrice).ToString("F2"),
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
            
            Dictionary<string, List<OrderDetails> > sells_by_user = new Dictionary<string, List<OrderDetails>>();


            foreach(var od in orderDetails){
                var seller = od.ProductSale.Seller;
                var id = seller.Id;
                List<OrderDetails> sell_list;
                if(sells_by_user.TryGetValue(id,out sell_list) ){
                    sell_list.Add(od);
                }
                else{
                    sell_list = new List<OrderDetails>();
                    sell_list.Add(od);
                    sells_by_user.Add(id,sell_list);
                }

            }

            foreach(var (sellerID,sell_list) in sells_by_user){
                
                var message = "You have sold " + sell_list[0].Count + " Unit(s) of " + sell_list[0].Name;
                if(sell_list.Count > 1){
                    message = "You have sold multiple products to a user, check the details for more information";
                }

                var noti_sell = new NotiSell()
                {
                    SendToUser = sellerID,
                    NotiDate = (DateTime)date,
                    Message = message,
                    Seen = false,
                    OrderDetails=sell_list,
                };
                await db.NotiSell.AddAsync(noti_sell);
                await db.SaveChangesAsync();

            }  
            
            return true;
            
        }
            
    }
}