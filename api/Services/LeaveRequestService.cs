using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.LeaveRequest;
using api.Interfaces;
using api.Mappers;
using api.Models;

namespace api.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }
        public async Task<List<LeaveRequestDto>> GetAllLeaveRequestsAsync()
        {
            var leaveRequests = await _leaveRequestRepository.GetAllLeaveRequestsAsync();
            return leaveRequests.Select(lR => lR.ToLeaveRequestDto()).ToList();
        }
        public async Task<LeaveRequestDto?> GetLeaveRequestByIdAsync(int id)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(id);
            if (leaveRequest == null)
            {
                return null;
            }
            return leaveRequest.ToLeaveRequestDto();
        }
        public async Task<LeaveRequestDto> CreateLeaveRequestAsync(LeaveRequestDto leaveRequestDto)
        {
            var leaveRequest = leaveRequestDto.ToLeaveRequest();
            leaveRequest = await _leaveRequestRepository.CreateLeaveRequestAsync(leaveRequest);
            return leaveRequest.ToLeaveRequestDto();
        }
        public async Task<LeaveRequest?> UpdateLeaveRequestAsync(int id, LeaveRequestDto updatedLeaveRequest)
        {
            await _leaveRequestRepository.UpdateLeaveRequestAsync(updatedLeaveRequest.ToLeaveRequest());
            return updatedLeaveRequest.ToLeaveRequest();
        }
        public async Task<bool> DeleteLeaveRequestAsync(int id)
        {
            var leaveRequest = await _leaveRequestRepository.DeleteLeaveRequestAsync(id);
            return leaveRequest != null;
        }
    }
}