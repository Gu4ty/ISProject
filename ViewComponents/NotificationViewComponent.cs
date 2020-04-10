using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ISProject.Data;
using ISProject.Models;
using ISProject.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ISProject.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        ApplicationDbContext _db;
      

        public NotificationViewComponent(ApplicationDbContext db)
        {
            _db = db;
           
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
          
            var user = await _db.User.FirstOrDefaultAsync(u => u.Id == claim.Value);

            bool is_admin = this.User.IsInRole(SD.ManagerUser);

            var notifications = await _db.Notification
                                    .Where(
                                        n => !n.Seen &&
                                        (
                                            n.SendToUser== claim.Value ||
                                            (n.SendToUser == "All_A" && is_admin )
                                            
                                        )
                                    )
                                    .ToListAsync();
                                    
            
            
            
            return View(notifications);
        }
    }
}