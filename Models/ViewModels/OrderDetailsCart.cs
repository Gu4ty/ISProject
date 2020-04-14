using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISProject.Models.ViewModels
{
    public class OrderDetailsCart
    {
        public List<ShoppingCart> listCart {get; set; }
        public OrderHeader OrderHeader { get; set; }

        public string ChangesMessage { get; set;}

    }
}