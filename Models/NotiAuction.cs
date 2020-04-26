using System;
using System.ComponentModel.DataAnnotations;


namespace ISProject.Models
{
    public class NotiAuction : Notification
    {
        public AuctionHeader AuctionHeader { get; set; }   
        
    }
}