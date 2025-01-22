using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Models;
using api.Data;

namespace api.Repository
{
    public class LeaveBalanceRepository : ILeaveBalanceRepository
    {
        private readonly ApplicationDBContext _context;

        public LeaveBalanceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<LeaveBalance> CreateLeaveBalanceAsync(LeaveBalance leaveBalance)
        {
            try
            {
                await _context.LeaveBalances.AddAsync(leaveBalance);
                await _context.SaveChangesAsync();
                return leaveBalance;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating new leave balance.", ex);
            }
        }

        public async Task<LeaveBalance?> DeleteLeaveBalanceAsync(int id)
        {
            try
            {
                var leaveBalance = await _context.LeaveBalances.FindAsync(id);
                if (leaveBalance != null)
                {
                    _context.LeaveBalances.Remove(leaveBalance);
                    await _context.SaveChangesAsync();
                }
                return leaveBalance;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting leave balance with id: {id}", ex);
            }
        }

        public async Task<LeaveBalance?> GetLeaveBalanceByIdAsync(int id)
        {
            try
            {
                return await _context.LeaveBalances.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving leave balance with id: {id}", ex);
            }
        }

        public async Task<IEnumerable<LeaveBalance>> GetLeaveBalancesByUserIdAsync(int userId)
        {
            try
            {
                return await _context.LeaveBalances
                .Where(lb => lb.idUser == userId)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving leave balance for user with id: {userId}", ex);
            }
        }

        public async Task<LeaveBalance?> UpdateLeaveBalanceAsync(LeaveBalance leaveBalance)
        {
            try
            {
                _context.Entry(leaveBalance).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return leaveBalance;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating new leave balance.", ex);
            }
        }
    }
}