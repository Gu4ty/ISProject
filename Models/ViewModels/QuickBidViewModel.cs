using System.ComponentModel.DataAnnotations;

namespace ISProject.Models.ViewModels
{
    public class QuickBidViewModel
    {
        public int AuctionId { get; set; }

        public double CurrentPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Count should be greater than 0")]
        public int Count { get; set; }

        public double PriceStep { get; set; }
    }
}