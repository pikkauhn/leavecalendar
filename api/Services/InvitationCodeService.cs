using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using api.Dtos.InvitationCode;
using api.Interfaces;
using api.Models;
using api.Security;
using api.Dtos.LeaveRequest;

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

        public async Task<InvitationCodeDto> CreateInvitationCodeAsync(InvitationCodeDto invitationCodeDto)
        {
            invitationCodeDto.Code = CodeGenerator.GenerateRandomCode(10);
            var invitationCode = _mapper.Map<InvitationCode>(invitationCodeDto);
            
            var createdInvitationCode = await _invitationCodeRepository.CreateInvitationCodeAsync(invitationCode);
            return _mapper.Map<InvitationCodeDto>(createdInvitationCode);
        }

        public async Task<InvitationCode?> DeleteInvitationCodeAsync(int id)
        {
            return await _invitationCodeRepository.DeleteInvitationCodeAsync(id);
        }

        public async Task<List<InvitationCodeDto>> GetAllInvitationCodesAsync()
        {
            var invitationCodes = await _invitationCodeRepository.GetAllInvitationCodesAsync();
            return _mapper.Map<List<InvitationCodeDto>>(invitationCodes);
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

        public async Task<InvitationCodeDto?> GetInvitationCodeByIdAsync(int id)
        {
            var invitationCode = await _invitationCodeRepository.GetInvitationCodeByIdAsync(id);
            if (invitationCode == null)
            {
                return null;
            }
            return _mapper.Map<InvitationCodeDto>(invitationCode);
        }

        public async Task<InvitationCodeDto?> UpdateInvitationCodeAsync(int id, InvitationCodeDto invitationCodeDto)
        {
            var invitationCode = await _invitationCodeRepository.GetInvitationCodeByIdAsync(id);
            if (invitationCode == null)
            {
                return null;
            }

            var updatedInvitationCode = await _invitationCodeRepository.UpdateInvitationCodeAsync(id, invitationCodeDto);
            return _mapper.Map<InvitationCodeDto>(updatedInvitationCode);
        }
    }
}