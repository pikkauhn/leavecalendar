namespace api.Models
{
    public enum UserRole
    {
        Admin,
        User,
        Manager
    }
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required UserRole Role { get; set; }
        public required int DepartmentId { get; set; }        
        public required Department Department { get; set; }
    }
}