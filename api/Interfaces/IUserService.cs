using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUserService
    {
    Task<List<User>> GetAllUsersAsync();
    Task<User?>? GetUserByIdAsync(int id);
    Task<User?>? GetUserByUsernameAsync(string username);
    bool CreateUserAsync(User user);
    bool UpdateUserAsync(User user);
    bool DeleteUserAsync(int id);
    }

    public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User> CreateUserAsync(User user);
    Task<User?> UpdateUserAsync(User user);
    Task<User?> DeleteUserAsync(int id);
}
}