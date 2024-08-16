using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.LeaveBalance;
using api.Models;

namespace api.Interfaces
{
    public interface ILeaveBalanceService
    {
        Task<LeaveBalance> GetLeaveBalanceByIdAsync(int id);
        Task<IEnumerable<LeaveBalance>> GetLeaveBalancesByUserIdAsync(int userId);
        Task<LeaveBalance> CreateLeaveBalanceAsync(LeaveBalance leaveBalance);
        Task<LeaveBalance?> UpdateLeaveBalanceAsync(LeaveBalance leaveBalance);
        Task<LeaveBalance?> DeleteLeaveBalanceAsync(int id);
        Task<LeaveBalance?> CalculateLeaveBalanceAsync(int userId, int leaveTypeId);
    }

    public interface ILeaveBalanceRepository
    {
        Task<LeaveBalance?> GetLeaveBalanceByIdAsync(int id);
        Task<IEnumerable<LeaveBalance>> GetLeaveBalancesByUserIdAsync(int id);
        Task<LeaveBalance> CreateLeaveBalanceAsync(LeaveBalance leaveBalance);
        Task<LeaveBalance?> UpdateLeaveBalanceAsync(LeaveBalance leaveBalance);
        Task<LeaveBalance?> DeleteLeaveBalanceAsync(int id);
    }
        public interface ILeaveBalanceMapper
    {
        LeaveBalanceDto MapToLeaveBalanceDto(LeaveBalance leaveBalance);
        LeaveBalance MapToLeaveBalance(LeaveBalanceDto leaveBalanceDto);
    }
}