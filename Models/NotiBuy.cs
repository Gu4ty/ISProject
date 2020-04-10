using System.Collections.Generic;

namespace ISProject.Models
{
    public class NotiBuy : Notification
    {
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}