using api.Dtos.User;
using api.Interfaces;
using api.Models;
using AutoMapper;
using api.Utils;

namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    Console.Write("User not found");
                    return false;
                }

                foreach (var currentPropertyInfo in typeof(User).GetProperties())
                {
                    var currentPropertyName = currentPropertyInfo.Name;
                    var currentPropertyValue = currentPropertyInfo.GetValue(user);
                    Console.Write($"{currentPropertyName} : {currentPropertyValue} ");
                    var newPropertyInfo = typeof(UpdateUserRequestDto).GetProperty(currentPropertyName);
                    var newPropertyName = newPropertyInfo?.Name;
                    var newPropertyValue = newPropertyInfo?.GetValue(userDto);

                    if (newPropertyValue == null)
                    {
                        continue;
                    }
                    if (newPropertyName == null)
                    {
                        continue;
                    }

                    Console.Write($"{newPropertyName} : {newPropertyValue} ");

                    if (newPropertyValue?.Equals(currentPropertyValue) == true)
                    {
                        continue;
                    }

                    if (!Validation.isPropertyValid(userDto, newPropertyName))
                    {
                        currentPropertyInfo.SetValue(user, newPropertyValue);
                    }
                }

                Console.Write("Updated : " + user.Email);
                await _userRepository.UpdateUserAsync(user);
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