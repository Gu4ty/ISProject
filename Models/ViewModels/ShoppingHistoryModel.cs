using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISProject.Models.ViewModels
{
    public class ShoppingHistoryModel
    {
        public string UserId { get; set; }
        public List<OrderHeader> Orders { get; set; }
    }
}