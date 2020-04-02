using Microsoft.AspNetCore.Identity;


namespace ISProject.Models
{
    public class Seller : User
    {
        public int Rating { get; set; }        
    }
}