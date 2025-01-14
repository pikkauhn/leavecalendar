using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ApiKeys
    {
        [Key]
        public int idApiKeys { get; set; }
        public required string ApiKey { get; set; }
        public int UserId { get; set; }
    }
}