namespace ISProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Raiting { get; set; }

        public string PhoneNumber { get; set; }
    }
}