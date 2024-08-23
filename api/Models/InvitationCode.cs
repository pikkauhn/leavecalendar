namespace api.Models
{
  public class InvitationCode
  {
    public int Id { get; set; }
    public required string Code { get; set; }
    public bool Used { get; set; }
    public int IssuedBy { get; set; }
    public DateTime IssuedAt { get; set; }
    // public required User IssuedByNavigation { get; set; }
  }
}