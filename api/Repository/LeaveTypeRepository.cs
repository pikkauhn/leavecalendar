using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDBContext _context;
        public LeaveTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<LeaveType> CreateLeaveTypeAsync(LeaveType leaveType)
        {
            try
            {
                await _context.LeaveTypes.AddAsync(leaveType);
                await _context.SaveChangesAsync();
                return leaveType;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred when creating a new leave type", ex);
            }
        }

        public async Task<LeaveType?> DeleteLeaveTypeAsync(int id)
        {
            try
            {
                var leaveType = await _context.LeaveTypes.FindAsync(id);
                if (leaveType != null)
                {
                    _context.LeaveTypes.Remove(leaveType);
                    await _context.SaveChangesAsync();
                }
                return leaveType;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred deleting leave type with id: {id}", ex);
            }
        }

        public async Task<IEnumerable<LeaveType>> GetAllLeaveTypesAsync()
        {
            try
            {
                return await _context.LeaveTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred retrieving all leave types", ex);
            }
        }

        public async Task<LeaveType?> GetLeaveTypeByIdAsync(int id)
        {
            try
            {
                return await _context.LeaveTypes.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred retrieving leave type with id: {id}", ex);
            }
        }

        public async Task<LeaveType?> UpdateLeaveTypeAsync(LeaveType leaveType)
        {
            try
            {
                _context.Entry(leaveType).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return leaveType;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred updating leave type with id: {leaveType.Id}", ex);
            }
        }
    }
}