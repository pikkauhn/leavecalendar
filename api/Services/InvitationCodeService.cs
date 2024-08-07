using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.InvitationCode;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Security;

namespace api.Services
{
    public class InvitationCodeService : IInvitationCodeService
    {
        private readonly IInvitationCodeRepository _invitationCodeRepository;
        public InvitationCodeService(IInvitationCodeRepository invitationCodeRepository)
        {
            _invitationCodeRepository = invitationCodeRepository;
        }

        public async Task<InvitationCodeDto> CreateInvitationCodeAsync(InvitationCodeDto invitationCodeDto)
        {
            invitationCodeDto.Code = CodeGenerator.GenerateRandomCode(10);
            var invitationCode = invitationCodeDto.ToInvitationCode();
            
            var createdInvitationCode = await _invitationCodeRepository.CreateInvitationCodeAsync(invitationCode);
            return createdInvitationCode.ToInvitationCodeDto();
        }

        public async Task<InvitationCode?> DeleteInvitationCodeAsync(int id)
        {
            return await _invitationCodeRepository.DeleteInvitationCodeAsync(id);
        }

        public async Task<List<InvitationCodeDto>> GetAllInvitationCodesAsync()
        {
            var invitationCodes = await _invitationCodeRepository.GetAllInvitationCodesAsync();
            return invitationCodes.Select(ic => ic.ToInvitationCodeDto()).ToList();
        }

        public async Task<InvitationCodeDto?> GetInvitationCodeByCodeAsync(string code)
        {
            var invitationCode = await _invitationCodeRepository.GetInvitationCodeByCodeAsync(code);
            if (invitationCode == null)
            {
                return null;
            }
            return invitationCode?.ToInvitationCodeDto();
        }

        public async Task<InvitationCodeDto?> GetInvitationCodeByIdAsync(int id)
        {
            var invitationCode = await _invitationCodeRepository.GetInvitationCodeByIdAsync(id);
            if (invitationCode == null)
            {
                return null;
            }
            return invitationCode?.ToInvitationCodeDto();
        }

        public async Task<InvitationCodeDto?> UpdateInvitationCodeAsync(int id, InvitationCodeDto invitationCodeDto)
        {
            var invitationCode = await _invitationCodeRepository.GetInvitationCodeByIdAsync(id);
            if (invitationCode == null)
            {
                return null;
            }

            var updatedInvitationCode = await _invitationCodeRepository.UpdateInvitationCodeAsync(id, invitationCodeDto);
            return updatedInvitationCode?.ToInvitationCodeDto();
        }
    }
}