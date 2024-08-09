using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Department;
using api.Dtos.InvitationCode;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class InvitationCodeRepository : IInvitationCodeRepository
    {
        private readonly ApplicationDBContext _context;

        public InvitationCodeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<InvitationCode> CreateInvitationCodeAsync(InvitationCode invitationCode)
        {
            _context.InvitationCodes.Add(invitationCode);
            await _context.SaveChangesAsync();
            return invitationCode;
        }

        public async Task<InvitationCode?> DeleteInvitationCodeAsync(int id)
        {
            var invitationCode = await _context.InvitationCodes.FindAsync(id);
            if (invitationCode == null)
            {
                return null;
            }

            _context.InvitationCodes.Remove(invitationCode);
            await _context.SaveChangesAsync();
            return invitationCode;
        }

        public async Task<List<InvitationCode>> GetAllInvitationCodesAsync()
        {
            return await _context.InvitationCodes.ToListAsync();
        }

        public async Task<InvitationCode?> GetInvitationCodeByCodeAsync(string code)
        {
            return await _context.InvitationCodes.FirstOrDefaultAsync(ic => ic.Code == code);
        }

        public async Task<InvitationCode?> GetInvitationCodeByIdAsync(int id)
        {            
            return await _context.InvitationCodes.FindAsync(id);
        }

        public async Task<InvitationCode?> UpdateInvitationCodeAsync(int id, InvitationCodeDto invitationCodeDto)
        {
            var existingInvitationCode = await _context.InvitationCodes
                .FirstOrDefaultAsync(ic => ic.Id == id);

            if (existingInvitationCode == null)
            {
                return null;
            }

            _context.Entry(existingInvitationCode).CurrentValues.SetValues(invitationCodeDto);
            await _context.SaveChangesAsync();
            return existingInvitationCode;
        }
    }
}