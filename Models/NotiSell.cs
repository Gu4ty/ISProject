using System.Collections.Generic;

namespace ISProject.Models
{
    public class NotiSell : Notification
    {
        public OrderDetails OrderDetails { get; set; }
    }
}