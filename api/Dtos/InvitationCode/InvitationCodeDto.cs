using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.InvitationCode
{
    public class InvitationCodeDto
    {
        public required string Code { get; set; }
        public bool Used { get; set; }
        public int IssuedBy { get; set; }
        public DateTime IssuedAt { get; set; }
    }
}