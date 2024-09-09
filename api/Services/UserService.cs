using api.Dtos.User;
using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {                
                user.Role = UserRole.standard;
                await _userRepository.CreateUserAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write($"Error creating users: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {                
                await _userRepository.DeleteUserAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write($"Error deleteing user: {ex.Message}");
                return false;
            }
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            try
            {                
                return _userRepository.GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                Console.Write($"Error getting users: {ex.Message}");
                throw new Exception($"Failed to retrieve data: {ex.Message}");
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public Task<User?> GetUserByUsernameAsync(string username)
        {
            return _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserRequestDto userDto)
        {
            try
            {
                await _userRepository.UpdateUserAsync(id, userDto);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write($"Error updating user: {ex.Message}");
                return false;
            }
        }
    }
}