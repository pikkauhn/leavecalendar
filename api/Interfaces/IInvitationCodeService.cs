using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.InvitationCode;
using api.Models;

namespace api.Interfaces
{
    public interface IInvitationCodeService
    {
        Task<List<InvitationCodeDto>> GetAllInvitationCodesAsync();
        Task<InvitationCodeDto?> GetInvitationCodeByIdAsync(int id);
        Task<InvitationCodeDto?> GetInvitationCodeByCodeAsync(string code);
        Task<InvitationCodeDto> CreateInvitationCodeAsync(InvitationCodeDto invitationCodeDto);
        Task<InvitationCodeDto?> UpdateInvitationCodeAsync(int id, InvitationCodeDto invitationCodeDto);
        Task<InvitationCode?> DeleteInvitationCodeAsync(int id);
    }
    public interface IInvitationCodeRepository
    {
        Task<List<InvitationCode>> GetAllInvitationCodesAsync();
        Task<InvitationCode?> GetInvitationCodeByIdAsync(int id);
        Task<InvitationCode?> GetInvitationCodeByCodeAsync(string code);
        Task<InvitationCode> CreateInvitationCodeAsync(InvitationCode invitationCode);
        Task<InvitationCode?> UpdateInvitationCodeAsync(int id, InvitationCode invitationCode);
        Task<InvitationCode?> DeleteInvitationCodeAsync(int id);
    }
}