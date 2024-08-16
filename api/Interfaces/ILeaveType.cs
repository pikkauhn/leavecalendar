using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Dtos.LeaveType;

namespace api.Interfaces
{
    public interface ILeaveTypeService
    {
        Task<LeaveType?> GetLeaveTypeByIdAsync(int id);
        Task<IEnumerable<LeaveType>> GetAllLeaveTypesAsync();
        Task<LeaveType> CreateLeaveTypeAsync(LeaveType leaveType);
        Task<LeaveType?> UpdateLeaveTypeAsync(LeaveType leaveType);
        Task<LeaveType?> DeleteLeaveTypeAsync(int id);
    }

    public interface ILeaveTypeRepository
    {
        Task<LeaveType?> GetLeaveTypeByIdAsync(int id);
        Task<IEnumerable<LeaveType>> GetAllLeaveTypesAsync();
        Task<LeaveType> CreateLeaveTypeAsync(LeaveType leaveType);
        Task<LeaveType?> UpdateLeaveTypeAsync(LeaveType leaveType);
        Task<LeaveType?> DeleteLeaveTypeAsync(int id);
    }
    public interface ILeaveTypeMapper
    {
        LeaveTypeDto MapToLeaveTypeDto(LeaveType leaveType);
        LeaveType MapToLeaveType(LeaveTypeDto leaveTypeDto);
    }
}