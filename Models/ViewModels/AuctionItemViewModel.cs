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
            AuctionProduct = new List<AuctionProduct>();
        }

        public AuctionHeader AuctionHeader { get; set; }
        public List<AuctionProduct> AuctionProduct   { get; set; }
        public AuctionUser AuctionUser { get; set; }
    }
}