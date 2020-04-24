using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class AuctionProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        public int AuctionId { get; set; }
        [ForeignKey("AuctionId")]
        public virtual AuctionHeader AuctionHeader { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage="The amount of products must be at least one.")]
        public int Quantity { get; set; }

    }
}