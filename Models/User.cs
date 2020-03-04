using Microsoft.AspNetCore.Identity;


namespace ISProject.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } 
        public int Raiting { get; set; }
       
    }
}