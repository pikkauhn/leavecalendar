using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Models;

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
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the user: ", ex);
            }
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting user with id: {id}", ex);
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all users: ", ex);
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving user with id: {id}", ex);
            }
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving user with username: {username}", ex);
            }
        }

        public async Task<User?> UpdateUserAsync(int id, UpdateUserRequestDto userDto)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (existingUser == null)
                {
                    return null;
                }
                _context.Entry(existingUser).CurrentValues.SetValues(userDto);
                await _context.SaveChangesAsync();
                return existingUser;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating user with id: {id}", ex);
            }
        }
    }
}