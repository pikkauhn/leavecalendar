using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class InvitationCode
  {
    public int Id { get; set; }
    public required string Code { get; set; }
    public bool Used { get; set; }
    public int IssuedBy { get; set; }
    public DateTime IssuedAt { get; set; }
    // public User? IssuedByNavigation { get; set; }
  }
}