namespace api.Dtos.User
{

    public class UserDto
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required int Role { get; set; }
        public int idDepartment { get; set; }
    }
    public class UpdateUserRequestDto
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public int Role { get; set; }
        public int? idDepartment { get; set; }
    }
    public class CreateUserRequestDto
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public int Role { get; set; }
        public int? idDepartment { get; set; }
    }
    public class VerifyUserPassword
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}