using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UpdateUserRequestDto
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }
        public int AvailableVacationDays { get; set; }
        public int AvailableSickDays { get; set; }
        public int DepartmentId { get; set; }
    }
}