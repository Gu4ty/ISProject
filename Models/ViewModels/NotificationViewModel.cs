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

        public List<NotiSell> NotiSell { get; set; }

        public List<Notification> NotiGeneral { get; set; }

        public List<NotiAuction> NotiAuction { get; set; }

        public string Type { get; set; }

        public NotificationViewModel()
        {
            NotiGeneral = new List<Notification>();
            NotiRole = new List<NotiRole>();
            NotiBuy = new List<NotiBuy>();
            NotiSell = new List<NotiSell>();
            NotiAuction = new List<NotiAuction>();
        }
        
    }
}