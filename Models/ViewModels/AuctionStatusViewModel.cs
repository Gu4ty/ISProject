using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISProject.Models.ViewModels
{
    public class AuctionStatusViewModel
    {
        
        public AuctionStatusViewModel()
        {
            Auctions = new List<AuctionItemViewModel>();
        }

        public List<AuctionItemViewModel> Auctions { get; set; }


        public string CallBack { get; set; } 
        public string Status { get; set; } 

    } 
}