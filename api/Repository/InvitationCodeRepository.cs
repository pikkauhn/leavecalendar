using api.Data;
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
            try
            {
            _context.InvitationCodes.Add(invitationCode);
            await _context.SaveChangesAsync();
            return invitationCode;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating an invitation code", ex);
            }
        }

        public async Task<InvitationCode?> DeleteInvitationCodeAsync(int id)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting an invitation code with id: {id}", ex);
            }
        }

        public async Task<List<InvitationCode>> GetAllInvitationCodesAsync()
        {
            try
            {
            return await _context.InvitationCodes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all invitation codes", ex);
            }
        }

        public async Task<InvitationCode?> GetInvitationCodeByCodeAsync(string code)
        {
            try
            {
            return await _context.InvitationCodes.FirstOrDefaultAsync(ic => ic.Code == code);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving an invitation code with code: {code}", ex);
            }
        }

        public async Task<InvitationCode?> GetInvitationCodeByIdAsync(int id)
        {            
            try 
            {
            return await _context.InvitationCodes.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving an invitation code with id: {id}", ex);
            }
        }

        public async Task<InvitationCode?> UpdateInvitationCodeAsync(int id, InvitationCodeChangeDto invitationCodeChangeDto)
        {
            try
            {
            var existingInvitationCode = await _context.InvitationCodes
                .FirstOrDefaultAsync(ic => ic.idInvitationCode == id);

            if (existingInvitationCode == null)
            {
                return null;
            }

            _context.Entry(existingInvitationCode).CurrentValues.SetValues(invitationCodeChangeDto);
            await _context.SaveChangesAsync();
            return existingInvitationCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating an invitation code with id: {id}", ex);
            }
        }
    }
}