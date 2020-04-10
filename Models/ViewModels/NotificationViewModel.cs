using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISProject.Models.ViewModels
{
    public class NotificationViewModel
    {

        public List<NotiRole> NotiRole { get; set; }

        public List<NotiBuy> NotiBuy { get; set; }

        public string Type { get; set; }

        public NotificationViewModel()
        {
            NotiRole = new List<NotiRole>();
            NotiBuy = new List<NotiBuy>();
        }
        
    }
}