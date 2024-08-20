using api.Dtos.LeaveRequest;
using api.Dtos.LeaveType;
using api.Interfaces;
using api.Models;
using AutoMapper;

namespace api.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveTypeService _leaveTypeService;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeService leaveTypeService, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeService = leaveTypeService;
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
            var leaveType = await _leaveTypeService.GetLeaveTypeByIdAsync(updatedLeaveRequest.LeaveType);
            if (leaveType == null)
            {
                return null;
            }

            existingLeaveRequest.Reason = updatedLeaveRequest.Reason;
            existingLeaveRequest.StartDate = updatedLeaveRequest.StartDate;
            existingLeaveRequest.EndDate = updatedLeaveRequest.EndDate;
            existingLeaveRequest.Status = (LeaveStatus)updatedLeaveRequest.Status;
            existingLeaveRequest.LeaveType = leaveType;
            existingLeaveRequest.Comment = updatedLeaveRequest.Comment;

        //             public required string Reason { get; set; }
        // public DateTime StartDate { get; set; }
        // public DateTime EndDate { get; set; }
        // public required LeaveStatus Status { get; set; }
        // public required LeaveType LeaveType { get; set; }
        // public string? Comment { get; set; }

            await _leaveRequestRepository.UpdateLeaveRequestAsync(existingLeaveRequest);
            return _mapper.Map<LeaveRequestDto>(existingLeaveRequest);
        }
        public async Task<bool> DeleteLeaveRequestAsync(int id)
        {
            var leaveRequest = await _leaveRequestRepository.DeleteLeaveRequestAsync(id);
            return leaveRequest != null;
        }
    }
}