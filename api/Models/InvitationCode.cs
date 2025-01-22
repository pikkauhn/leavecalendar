using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
  public class InvitationCode
  {
    [Key]
    public int idInvitationCode { get; set; }
    public required string Code { get; set; }
    public bool Used { get; set; }
    [ForeignKey("idUser")]
    public int IssuedBy { get; set; }
    [ForeignKey("idUser")]
    public int IssuedTo { get; set; }
    public DateTime IssuedAt { get; set; }
  }
}