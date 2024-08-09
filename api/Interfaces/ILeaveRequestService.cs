using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.LeaveRequest;
using api.Models;

namespace api.Interfaces
{
    public interface ILeaveRequestService
    {
        Task<List<LeaveRequestDto>> GetAllLeaveRequestsAsync();
        Task<LeaveRequestDto?> GetLeaveRequestByIdAsync(int id);
        Task<LeaveRequestDto> CreateLeaveRequestAsync(LeaveRequestDto leaveRequestDto);
        Task<LeaveRequest?> UpdateLeaveRequestAsync(int id, LeaveRequestDto updatedLeaveRequestDto);
        Task<bool> DeleteLeaveRequestAsync(int id);
    }

    public interface ILeaveRequestRepository
    {
        Task<List<LeaveRequest>> GetAllLeaveRequestsAsync();
        Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id);
        Task<LeaveRequest> CreateLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<LeaveRequest?> UpdateLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<LeaveRequest?> DeleteLeaveRequestAsync(int id);
    }
}