using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public bool CreateUserAsync(User user)
        {
            try
            {
                _userRepository.CreateUserAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write($"Error creating users: {ex.Message}");
                return false;
            }
        }

        public bool DeleteUserAsync(int id)
        {
            try
            {
                _userRepository.DeleteUserAsync(id);
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

        public Task<User?>? GetUserByIdAsync(int id)
        {
            var user = _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return _userRepository.GetUserByIdAsync(id);
        }

        public Task<User?>? GetUserByUsernameAsync(string username)
        {
            var user = _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return null;
            }
            return _userRepository.GetUserByUsernameAsync(username);
        }

        public bool UpdateUserAsync(User user)
        {
            try
            {
                _userRepository.UpdateUserAsync(user);
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