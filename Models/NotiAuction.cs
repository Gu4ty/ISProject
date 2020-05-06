using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class NotiAuction : Notification
    {
        public int AuctionHeaderID { get; set; }
        [ForeignKey("AuctionHeaderID")]
        public AuctionHeader AuctionHeader { get; set; } 

        public List<AuctionProduct> AuctionProduct   { get; set; }

        public string Status { get; set; }

       
        
    }
}