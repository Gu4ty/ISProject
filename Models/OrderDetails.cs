using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual OrderHeader OrderHeader { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductSale ProductSale { get; set; }

        public int Count { get; set; }


        //Name, Description, Amount of product left and Price are properties we can find in ProductSale
        //However, this properties can be changed after the user decided to buy
        //the product, and we don't want this properties to change
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int AmountLeft { get; set; }
        public double Price { get; set; }

    }
}