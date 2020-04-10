
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class ShoppingCart
    {   
        public int Id { get; set; }

        public string UserId { get; set; }
        [NotMapped]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        public int ProductSaleID { get; set; }
        [NotMapped]
        [ForeignKey("ProductSaleID")]
        public virtual ProductSale ProductSale { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        public int Count { get; set; }

        public ShoppingCart()
        {
            Count = 1;
        }
    }
}