using api.Models;

namespace api.Dtos.User
{
    public class CreateUserRequestDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required UserRole Role { get; set; }
        public int DepartmentId { get; set; }
    }
}