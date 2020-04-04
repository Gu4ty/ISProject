
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class ShoppingCart
    {   
        public ShoppingCart()
        {
            Count=1;
        }
        public int Id { get; set; }
        public string SellerID { get; set; }
        [NotMapped]
        [ForeignKey("SellerID")]
        public virtual Seller Seller { get; set; }
        public int ProductSaleID { get; set; }
        [NotMapped]
        [ForeignKey("ProductSaleID")]
        public virtual ProductSale ProductSale { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        public int Count { get; set; }
    }
}