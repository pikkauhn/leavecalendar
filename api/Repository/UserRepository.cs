using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            else {
                return null;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Username = user.Username;
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;
            existingUser.Role = user.Role;
            existingUser.DepartmentId = user.DepartmentId;
            existingUser.AvailableVacationDays = user.AvailableVacationDays;
            existingUser.AvailableSickDays = user.AvailableSickDays;

            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}