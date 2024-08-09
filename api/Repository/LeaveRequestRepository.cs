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

        public async Task<LeaveRequest?> DeleteLeaveRequestAsync(int id)
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

        public async Task<List<LeaveRequest>> GetAllLeaveRequestsAsync()
        {
            return await _context.LeaveRequests.ToListAsync();
            
        }

        public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task<LeaveRequest?> UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
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
    }
}