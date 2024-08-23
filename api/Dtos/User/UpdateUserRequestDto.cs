using api.Models;

namespace api.Dtos.User
{
    public class UpdateUserRequestDto
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required int Role { get; set; }
        public int DepartmentId { get; set; }
    }
}