using System.ComponentModel.DataAnnotations;

namespace api.Models
{
  public class InvitationCode
  {
    [Key]
    public int idInvitationCode { get; set; }
    public required string Code { get; set; }
    public bool Used { get; set; }
    public int IssuedBy { get; set; }
    public DateTime IssuedAt { get; set; }
  }
}