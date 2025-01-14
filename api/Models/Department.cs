using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Department
    {   
        [Key]     
        public int idDepartment { get; set; }
        public required string Name { get; set; }
    }
}