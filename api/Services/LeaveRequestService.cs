using api.Dtos.LeaveRequest;
using api.Interfaces;
using api.Models;
using AutoMapper;

namespace api.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;            
        }
        public async Task<List<LeaveRequestDto>> GetAllLeaveRequestsAsync()
        {
            var leaveRequests = await _leaveRequestRepository.GetAllLeaveRequestsAsync();
            return _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
        }
        public async Task<LeaveRequestDto?> GetLeaveRequestByIdAsync(int id)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(id);
            if (leaveRequest == null)
            {
                return null;
            }
            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
        public async Task<LeaveRequestDto> CreateLeaveRequestAsync(LeaveRequestDto leaveRequestDto)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestDto);
            var createdLeaveRequest = await _leaveRequestRepository.CreateLeaveRequestAsync(leaveRequest);
            return _mapper.Map<LeaveRequestDto>(createdLeaveRequest);
        }
        public async Task<LeaveRequestDto?> UpdateLeaveRequestAsync(int id, LeaveRequestDto updatedLeaveRequest)
        {
            var existingLeaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(id);
            if (existingLeaveRequest == null)
            {
                return null;
            }

            existingLeaveRequest.Reason = updatedLeaveRequest.Reason;
            existingLeaveRequest.StartDate = updatedLeaveRequest.StartDate;
            existingLeaveRequest.EndDate = updatedLeaveRequest.EndDate;
            existingLeaveRequest.Status = (LeaveStatus)updatedLeaveRequest.Status;
            existingLeaveRequest.LeaveType = (LeaveType)updatedLeaveRequest.LeaveType;
            existingLeaveRequest.ResponseByUserId = updatedLeaveRequest.ResponseByUserId;
            existingLeaveRequest.Comment = updatedLeaveRequest.Comment;

            await _leaveRequestRepository.UpdateLeaveRequestAsync(existingLeaveRequest);
            return _mapper.Map<LeaveRequestDto>(existingLeaveRequest);
        }
        public async Task<LeaveRequestDto?> UpdateLeaveStatusAsync(int id, LeaveRequestDto updatedLeaveRequest)
        {
            var existingLeaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(id);
            if (existingLeaveRequest == null)
            {
                return null;
            }
            existingLeaveRequest.Status = (LeaveStatus)updatedLeaveRequest.Status;
            existingLeaveRequest.LeaveType = (LeaveType)updatedLeaveRequest.LeaveType;
            existingLeaveRequest.Comment = updatedLeaveRequest.Comment;

            await _leaveRequestRepository.UpdateLeaveRequestAsync(existingLeaveRequest);
            return _mapper.Map<LeaveRequestDto>(existingLeaveRequest);
        }
        public async Task<bool> DeleteLeaveRequestAsync(int id)
        {
            var leaveRequest = await _leaveRequestRepository.DeleteLeaveRequestAsync(id);
            return leaveRequest != null;
        }

        public Task<List<LeaveRequest>> GetLeaveRequestByUserIdAsync(int userId)
        {
            var leaveRequests = _leaveRequestRepository.GetLeaveRequestByUserIdAsync(userId);
            return leaveRequests!;            
        }
    }
}