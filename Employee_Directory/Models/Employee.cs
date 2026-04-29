namespace Employee_Directory.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Department { get; set; } = "";
        public string Team { get; set; } = "";
        public string? Part { get; set; }
        public string Position { get; set; } = "";
        public string Name { get; set; } = "";
        public string? ExtensionNumber { get; set; }
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string? PhotoPath { get; set; }
    }
}
