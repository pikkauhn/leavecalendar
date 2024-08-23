namespace api.Models
{
    public enum UserRole
    {
        standard = 1,        
        manager = 2,
        admin = 3
    }
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required UserRole Role { get; set; }
        public required int DepartmentId { get; set; }        
    }
}