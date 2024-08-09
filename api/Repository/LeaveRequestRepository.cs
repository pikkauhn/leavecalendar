using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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
            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<bool> DeleteLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            var existingLeaveRequest = await _context.LeaveRequests.FindAsync(leaveRequest);
            if (existingLeaveRequest == null)
            {
                return false;
            }
            _context.LeaveRequests.Remove(leaveRequest);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequestsAsync()
        {
            return await _context.LeaveRequests.ToListAsync();
            
        }

        public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task<bool> UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            var existingLeaveRequest = await _context.LeaveRequests.FindAsync(leaveRequest.Id);
            if (existingLeaveRequest == null)
            {
                return false;
            }

            _context.Entry(existingLeaveRequest).CurrentValues.SetValues(leaveRequest);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}