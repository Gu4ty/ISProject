using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class ProductSale
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Range(0.01, int.MaxValue, ErrorMessage = "Price should be greater than $0")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Units should be greater than 0")]
        public int Units { get; set; }
        
        [Required]
        [Display(Name = "Seller")]
        public string SellerId { get; set;}       
        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }
        
        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set;}
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Image { get; set; }

    }
}