using api.Dtos.LeaveRequest;
using api.Models;

namespace api.Interfaces
{
    public interface ILeaveRequestService
    {
        Task<List<LeaveRequestDto>> GetAllLeaveRequestsAsync();
        Task<LeaveRequestDto?> GetLeaveRequestByIdAsync(int id);
        Task<List<LeaveRequest>> GetLeaveRequestByUserIdAsync(int userId);
        Task<LeaveRequestDto> CreateLeaveRequestAsync(LeaveRequestDto leaveRequestDto);
        Task<LeaveRequestDto?> UpdateLeaveRequestAsync(int id, LeaveRequestDto updatedLeaveRequestDto);
        Task<bool> DeleteLeaveRequestAsync(int id);
    }

    public interface ILeaveRequestRepository
    {
        Task<List<LeaveRequest>> GetAllLeaveRequestsAsync();
        Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id);
        Task<List<LeaveRequest>?> GetLeaveRequestByUserIdAsync(int userId);
        Task<LeaveRequest> CreateLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<LeaveRequest?> UpdateLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<LeaveRequest?> DeleteLeaveRequestAsync(int id);
    }
}