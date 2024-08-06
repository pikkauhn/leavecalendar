using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.InvitationCode;
using api.Models;

namespace api.Mappers
{
    public static class InvitationCodeMapper
    {
        public static InvitationCodeDto ToInvitationCodeDto(this InvitationCode invitationCode)
        {
            return new InvitationCodeDto
            {
                Id = invitationCode.Id,
                Code = invitationCode.Code,
                Used = invitationCode.Used,
                IssuedBy = invitationCode.IssuedBy,
                IssuedAt = invitationCode.IssuedAt
            };
        }

        public static InvitationCode ToInvitationCode(this InvitationCodeDto invitationCodeDto)
        {
            return new InvitationCode
            {
                Id = invitationCodeDto.Id,
                Code = invitationCodeDto.Code,
                Used = invitationCodeDto.Used,
                IssuedBy = invitationCodeDto.IssuedBy,
                IssuedAt = invitationCodeDto.IssuedAt
            };
        }
    }
}