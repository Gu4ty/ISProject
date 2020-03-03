namespace ISProject.Data.Models
{
    public class AdminUser
    {
        public int Id { get; set; }
        public NormalUser NormalUser { get; set; }
        public int NormalUserId { get; set; }
    }
}