using System.Collections.Generic;

namespace ISProject.Models
{
    public class NotiSell : Notification
    {
        public int OrderDetailsID { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}