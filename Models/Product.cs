using System.ComponentModel.DataAnnotations;

namespace ISProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}