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
        Task<IEnumerable<LeaveRequest>> GetAllLeaveRequestsAsync();
        Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id);
        Task<LeaveRequest> CreateLeaveRequestAsync(LeaveRequestDto leaveRequestDto);
        Task<bool> UpdateLeaveRequestAsync(int id, LeaveRequestDto updatedLeaveRequest);
        Task<bool> DeleteLeaveRequestAsync(int id);
        Task<LeaveRequest?> ApproveLeaveRequestAsync(int leaveRequestId);
        Task<LeaveRequest?> DenyLeaveRequestAsync(int leaveRequestId);
    }

    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<LeaveRequest>> GetAllLeaveRequestsAsync();
        Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id);
        Task<LeaveRequest> AddLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<bool> UpdateLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<bool> DeleteLeaveRequestAsync(LeaveRequest leaveRequest);
    }
}