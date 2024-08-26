namespace api.Dtos.InvitationCode
{
    public class InvitationCodeDto
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public bool Used { get; set; }
        public int IssuedBy { get; set; }
        public DateTime IssuedAt { get; set; }
    }
}