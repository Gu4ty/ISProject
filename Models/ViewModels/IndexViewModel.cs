using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISProject.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ProductSale> Products { get; set; }
    }
}