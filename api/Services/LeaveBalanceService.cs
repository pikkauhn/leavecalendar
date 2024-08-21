using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api.Services
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;
        private readonly IMapper _mapper;

        public LeaveBalanceService(ILeaveBalanceRepository leaveBalanceRepository, IMapper mapper)
        {
            _leaveBalanceRepository = leaveBalanceRepository;
            _mapper = mapper;
        }

        public Task<LeaveBalance?> CalculateLeaveBalanceAsync(int userId, int leaveTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveBalance> CreateLeaveBalanceAsync(LeaveBalance leaveBalance)
        {
            var createdLeaveBalance = await _leaveBalanceRepository.CreateLeaveBalanceAsync(leaveBalance);
            return createdLeaveBalance;
        }

        public async Task<LeaveBalance?> DeleteLeaveBalanceAsync(int id)
        {
            var deletedLeaveBalance = await _leaveBalanceRepository.DeleteLeaveBalanceAsync(id);
            return deletedLeaveBalance;
        }

        public async Task<LeaveBalance?> GetLeaveBalanceByIdAsync(int id)
        {
            var leaveBalance = await _leaveBalanceRepository.GetLeaveBalanceByIdAsync(id);
            if (leaveBalance == null)
            {
                return null;
            }
            return leaveBalance;
        }

        public async Task<IEnumerable<LeaveBalance?>> GetLeaveBalancesByUserIdAsync(int userId)
        {
            var leaveBalances = await _leaveBalanceRepository.GetLeaveBalancesByUserIdAsync(userId);
            if (leaveBalances == null)
            {
                return null;
            }
            return leaveBalances;
        }

        public async Task<LeaveBalance?> UpdateLeaveBalanceAsync(LeaveBalance leaveBalance)
        {
            var updatedLeavebalance = await _leaveBalanceRepository.UpdateLeaveBalanceAsync(leaveBalance);
            return updatedLeavebalance;
        }
    }
}