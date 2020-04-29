using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISProject.Models.ViewModels
{
    public class AuctionViewModel
    {
        public List<ProductsAuctionViewModel> Products { get; set; }
        public AuctionHeader AuctionHeader { get; set;}
    }
}