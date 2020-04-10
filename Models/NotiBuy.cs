using System.Collections.Generic;

namespace ISProject.Models
{
    public class NotiBuy : Notification
    {
        public int OrderHeaderID { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}