using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class AuctionHeader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SellerId { get; set; }
        [ForeignKey("SellerId")]
        public virtual Seller User { get; set;}
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double CurrentPrice { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double PriceStep { get; set; }

    }
}