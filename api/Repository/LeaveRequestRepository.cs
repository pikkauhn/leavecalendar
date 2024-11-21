using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.LeaveRequest;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDBContext _context;

        public LeaveRequestRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<LeaveRequest> CreateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            try
            {
                _context.LeaveRequests.Add(leaveRequest);
                await _context.SaveChangesAsync();
                return leaveRequest;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating a leave request.", ex);
            }
        }

        public async Task<LeaveRequest?> DeleteLeaveRequestAsync(int id)
        {
            try
            {
                var existingLeaveRequest = await _context.LeaveRequests.FindAsync(id);
                if (existingLeaveRequest == null)
                {
                    return null;
                }
                _context.LeaveRequests.Remove(existingLeaveRequest);
                await _context.SaveChangesAsync();
                return existingLeaveRequest;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting a leave request with id: {id}", ex);
            }
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequestsAsync()
        {
            try
            {
                return await _context.LeaveRequests.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all leave requests.", ex);
            }
        }

        public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id)
        {
            try
            {
                return await _context.LeaveRequests.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving a leave request with id: {id}", ex);
            }
        }

        public async Task<List<LeaveRequest>?> GetLeaveRequestByUserIdAsync(int userId)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (existingUser == null)
                {
                    return null;
                }
                var leaveRequests = await _context.LeaveRequests
                                                    .Where(lr => lr.UserId == userId)
                                                    .ToListAsync();

                return leaveRequests;

            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving leave requests with userId: {userId}", ex);
            }
        }

        public async Task<LeaveRequest?> UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            try
            {
                var existingLeaveRequest = await _context.LeaveRequests.FindAsync(leaveRequest.Id);
                if (existingLeaveRequest == null)
                {
                    return null;
                }
                _context.Entry(existingLeaveRequest).CurrentValues.SetValues(leaveRequest);
                await _context.SaveChangesAsync();
                return leaveRequest;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating a leave request with id: {leaveRequest.Id}", ex);
            }
        }
    }
}