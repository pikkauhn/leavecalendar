namespace api.Models
{
    public class ApiKeys
    {
        public int IdApiKeys { get; set; }
        public required string ApiKey { get; set; }
        public int UserId { get; set; }
    }
}