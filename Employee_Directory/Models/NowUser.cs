namespace Employee_Directory.Models
{
    internal class NowUser
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "";
        public string Password { get; set; } = "";
        public UserRole Role { get; set; }
    }
}
