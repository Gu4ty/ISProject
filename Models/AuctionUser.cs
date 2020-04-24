using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class AuctionUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int AuctionId { get; set; }
        [ForeignKey("AuctionId")]
        public virtual AuctionHeader AuctionHeader { get; set; }

        [Required]
        public double LastPriceOffered { get; set; }

    }
}