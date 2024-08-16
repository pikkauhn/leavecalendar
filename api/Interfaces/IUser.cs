using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?>? GetUserByIdAsync(int id);
        Task<User?>? GetUserByUsernameAsync(string username);
        bool CreateUserAsync(User user);
        bool UpdateUserAsync(int id, UpdateUserRequestDto userDto);
        bool DeleteUserAsync(int id);
    }

    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(User user);
        Task<User?> UpdateUserAsync(int id, UpdateUserRequestDto userDto);
        Task<User?> DeleteUserAsync(int id);
    }
    public interface IUserMapper
    {
        UserDto MapToUserDto(User user);
        User MapToUser(UserDto userDto);
    }
}