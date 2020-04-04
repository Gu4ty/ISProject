using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISProject.Models.ViewModels
{
    public class ProductSellerViewModel
    {
        public List<Product> Products { get; set; }

        public ProductSale ProductSale { get; set; }
    }
}