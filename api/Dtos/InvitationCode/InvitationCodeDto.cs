namespace api.Dtos.InvitationCode
{
    public class InvitationCodeDto
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public bool Used { get; set; }
        public int IssuedBy { get; set; }
    }
    public class InvitationCodeChangeDto
    {
        public int Id { get; set; }
        public bool Used { get; set; }
    }    
}