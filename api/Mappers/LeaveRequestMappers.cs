using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.LeaveRequest;
using api.Models;

namespace api.Mappers
{
    public static class LeaveRequestMappers
    {
        public static LeaveRequestDto ToLeaveRequestDto(this LeaveRequest leaveRequest)
        {
            return new LeaveRequestDto
            {
                Id = leaveRequest.Id,
                UserId = leaveRequest.UserId,
                Reason = leaveRequest.Reason,
                StartDate = leaveRequest.StartDate,
                EndDate = leaveRequest.EndDate,
                Status = leaveRequest.Status,
                LeaveType = leaveRequest.LeaveType,
                Comment = leaveRequest.Comment
            };
        }
        public static LeaveRequest ToLeaveRequest(this LeaveRequestDto leaveRequestDto)
        {
            return new LeaveRequest
            {
                Id = leaveRequestDto.Id,
                UserId = leaveRequestDto.UserId,
                Reason = leaveRequestDto.Reason,
                StartDate = leaveRequestDto.StartDate,
                EndDate = leaveRequestDto.EndDate,
                Status = leaveRequestDto.Status,
                LeaveType = leaveRequestDto.LeaveType,                
                Comment = leaveRequestDto.Comment
            };
        }
    }
}