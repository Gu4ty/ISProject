using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class NotiBuy : Notification
    {
        public int OrderHeaderID { get; set; }
        [ForeignKey("OrderHeaderID")]
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}