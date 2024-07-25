using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ILeaveRequestRepository
    {
        List<LeaveRequest> GetAllLeaveRequests();
        LeaveRequest? GetLeaveRequestById(int id);
        void CreateLeaveRequest(LeaveRequest leaveRequest);
        LeaveRequest? UpdateLeaveRequest(LeaveRequest leaveRequest);
        void DeleteLeaveRequest(int id);
    }

    public interface ILeaveRequestService
    {
        List<LeaveRequest> GetAllLeaveRequests();
        LeaveRequest? GetLeaveRequestById(int id);
        void CreateLeaveRequest(LeaveRequest leaveRequest);
        LeaveRequest? UpdateLeaveRequest(LeaveRequest leaveRequest);
        void DeleteLeaveRequest(int id);
        LeaveRequest? ApproveLeaveRequest(int leaveRequestId);
        LeaveRequest? DenyLeaveRequest(int leaveRequestId);
    }
}