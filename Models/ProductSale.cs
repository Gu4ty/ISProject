using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class ProductSale
    {
        [Key]
        public int Id { get; set; }
        
        public int Price { get; set; }
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
    }
}