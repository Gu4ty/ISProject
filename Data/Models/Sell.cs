using System;
using System.ComponentModel.DataAnnotations;

namespace ISProject.Data.Models
{
    public class Sell
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int Units { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}