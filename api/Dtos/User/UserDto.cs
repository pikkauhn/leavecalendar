namespace api.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required int Role { get; set; }
        public int DepartmentId { get; set; }
    }
    public class UpdateUserRequestDto
    {
        public required int Id { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required int Role { get; set; }
        public int DepartmentId { get; set; }
    }
    public class CreateUserRequestDto
    {
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public int DepartmentId { get; set; }
    }
    public class VerifyUserPassword
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}