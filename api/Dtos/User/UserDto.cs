using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }
        public int DepartmentId { get; set; }
    }
}