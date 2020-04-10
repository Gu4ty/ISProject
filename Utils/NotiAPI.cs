using System;
using System.Linq;
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
    }
}