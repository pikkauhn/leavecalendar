using api.Dtos.InvitationCode;
using api.Models;

namespace api.Interfaces
{
    public interface IInvitationCodeService
    {
        Task<List<InvitationCodeDto>> GetAllInvitationCodesAsync();
        Task<InvitationCodeDto?> GetInvitationCodeByCodeAsync(string code);
        Task<InvitationCode> CreateInvitationCodeAsync(InvitationCode invitationCode);
        Task<InvitationCodeDto?> UpdateInvitationCodeAsync(int id, InvitationCodeChangeDto invitationCodeChangeDto);
        Task<InvitationCode?> DeleteInvitationCodeAsync(int id);
    }
    public interface IInvitationCodeRepository
    {
        Task<List<InvitationCode>> GetAllInvitationCodesAsync();
        Task<InvitationCode?> GetInvitationCodeByIdAsync(int id);
        Task<InvitationCode?> GetInvitationCodeByCodeAsync(string code);
        Task<InvitationCode> CreateInvitationCodeAsync(InvitationCode invitationCode);
        Task<InvitationCode?> UpdateInvitationCodeAsync(int id, InvitationCodeChangeDto invitationCodeChangeDto);
        Task<InvitationCode?> DeleteInvitationCodeAsync(int id);
    }
}