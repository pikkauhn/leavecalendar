using AutoMapper;
using api.Dtos.InvitationCode;
using api.Interfaces;
using api.Models;
using api.Security;

namespace api.Services
{
    public class InvitationCodeService : IInvitationCodeService
    {
        private readonly IInvitationCodeRepository _invitationCodeRepository;
        private readonly IMapper _mapper;
        public InvitationCodeService(IInvitationCodeRepository invitationCodeRepository, IMapper mapper)
        {
            _invitationCodeRepository = invitationCodeRepository;
            _mapper = mapper;
        }

        public async Task<InvitationCode> CreateInvitationCodeAsync(InvitationCode invitationCode)
        {
            invitationCode.Code = CodeGenerator.GenerateRandomCode(10);
            
            var createdInvitationCode = await _invitationCodeRepository.CreateInvitationCodeAsync(invitationCode);
            return createdInvitationCode;
        }

        public async Task<InvitationCode?> DeleteInvitationCodeAsync(int id)
        {
            return await _invitationCodeRepository.DeleteInvitationCodeAsync(id);
        }

        public async Task<List<InvitationCodeDto>> GetAllInvitationCodesAsync()
        {
            var invitationCodes = await _invitationCodeRepository.GetAllInvitationCodesAsync();
            var invitationcodeDto = _mapper.Map<List<InvitationCodeDto>>(invitationCodes);
            return invitationcodeDto;
        }

        public async Task<InvitationCodeDto?> GetInvitationCodeByCodeAsync(string code)
        {
            var invitationCode = await _invitationCodeRepository.GetInvitationCodeByCodeAsync(code);
            if (invitationCode == null)
            {
                return null;
            }
            return _mapper.Map<InvitationCodeDto>(invitationCode);
        }

        public async Task<InvitationCodeDto?> UpdateInvitationCodeAsync(int id, InvitationCodeChangeDto invitationCodeChangeDto)
        {
            var invitationCode = await _invitationCodeRepository.GetInvitationCodeByIdAsync(id);
            if (invitationCode == null)
            {
                return null;
            }

            var updatedInvitationCode = await _invitationCodeRepository.UpdateInvitationCodeAsync(id, invitationCodeChangeDto);
            return _mapper.Map<InvitationCodeDto>(updatedInvitationCode);
        }
    }
}