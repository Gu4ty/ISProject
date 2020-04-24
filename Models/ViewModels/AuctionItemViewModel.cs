using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISProject.Models.ViewModels
{
    public class AuctionItemViewModel
    {
        
        public AuctionItemViewModel()
        {
            Products = new List<Product>();
        }

        public AuctionHeader AuctionHeader { get; set; }
        public List<Product> Products   { get; set; }
    }
}