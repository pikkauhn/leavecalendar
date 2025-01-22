using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        public int idUser { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required UserRole Role { get; set; }
        [ForeignKey("idDepartment")]
        public required int idDepartment { get; set; }
    }
}