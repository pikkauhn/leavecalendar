using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}