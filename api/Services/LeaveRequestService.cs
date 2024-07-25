using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
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

        public LeaveRequest? ApproveLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = _leaveRequestRepository.GetLeaveRequestById(leaveRequestId);
            if (leaveRequest == null)
            {
                return null;
            }
            leaveRequest.Status = "Approved";
            _leaveRequestRepository.UpdateLeaveRequest(leaveRequest);
            return leaveRequest;
        }

        public void CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            try
            {
                _leaveRequestRepository.CreateLeaveRequest(leaveRequest);
            }
            catch (Exception ex)
            {
                Console.Write($"Error creating leave request: {ex.Message}");
                throw new Exception("Failed to create leave request");
            }
        }

        public void DeleteLeaveRequest(int id)
        {
            try
            {
                _leaveRequestRepository.DeleteLeaveRequest(id);
            }
            catch (Exception ex)
            {
                Console.Write($"Error deleting leave request {id}: {ex.Message}");
                throw new Exception("Failed to delete leave request");
            }
        }

        public LeaveRequest? DenyLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = _leaveRequestRepository.GetLeaveRequestById(leaveRequestId);
            if (leaveRequest == null)            
            {
                return null;
            }
            leaveRequest.Status = "Denied";
            _leaveRequestRepository.UpdateLeaveRequest(leaveRequest);
            return leaveRequest;
        }

        public List<LeaveRequest> GetAllLeaveRequests()
        {
            try
            {
                return _leaveRequestRepository.GetAllLeaveRequests();
            }
            catch (Exception ex)
            {
                Console.Write($"Error getting all leave requests:  {ex.Message}");
                throw new Exception("Failed to get all leave requests");
            }
        }

        public LeaveRequest? GetLeaveRequestById(int id)
        {
            var leaveRequest = _leaveRequestRepository.GetLeaveRequestById(id);
            if (leaveRequest == null)
            {
                return null;
            }
            try
            {
                return _leaveRequestRepository.GetLeaveRequestById(id);
            }
            catch (Exception ex)
            {
                Console.Write($"Error getting leave request {id}: {ex.Message}");
                throw new Exception($"Failed to retrieve leave request {id}");
            }
        }

        public LeaveRequest? UpdateLeaveRequest(LeaveRequest leaveRequest)
        {
            var existingLeaveRequest = _leaveRequestRepository.GetLeaveRequestById(leaveRequest.Id);
            if (existingLeaveRequest == null)
            {
                return null;
            }
            try
            {
                existingLeaveRequest.Reason = leaveRequest.Reason;
                existingLeaveRequest.StartDate = leaveRequest.StartDate;
                existingLeaveRequest.EndDate = leaveRequest.EndDate;
                existingLeaveRequest.Status = leaveRequest.Status;
                existingLeaveRequest.LeaveType = leaveRequest.LeaveType;
                existingLeaveRequest.Comment = leaveRequest.Comment;

                _leaveRequestRepository.UpdateLeaveRequest(existingLeaveRequest);
                return existingLeaveRequest;
            }
            catch (Exception ex)
            {
                Console.Write($"Error updating leave request {existingLeaveRequest}: {ex.Message}");
                throw new Exception($"Failed to update leave request {existingLeaveRequest}: {ex.Message}");
            }
        }

    }
}