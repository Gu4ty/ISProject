using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class NotiRole : Notification
    {
        public string UserID { get; set; }
        [ForeignKey("UserID")]

        public virtual User User { get; set; }
        
    }
}