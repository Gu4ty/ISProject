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
            UpcomingAuctions = new List<AuctionItemViewModel>();
            ActiveAuctions = new List<AuctionItemViewModel>();
            PastAuctions = new List<AuctionItemViewModel>();
        }

        public List<AuctionItemViewModel> UpcomingAuctions { get; set; }
        public List<AuctionItemViewModel> ActiveAuctions { get; set; }
        public List<AuctionItemViewModel> PastAuctions { get; set; }

        public string CallBack { get; set; } 
        public string Status { get; set; } 

    } 
}