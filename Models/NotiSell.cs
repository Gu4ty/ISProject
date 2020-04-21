using System.Collections.Generic;

namespace ISProject.Models
{
    public class NotiSell : Notification
    {
         public List<OrderDetails> OrderDetails { get; set; }
        
       
    }
}