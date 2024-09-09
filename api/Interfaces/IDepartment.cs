using api.Models;

namespace api.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department?> GetDepartmentByNameAsync(string name);
        Task<Department> CreateDepartmentAsync(Department Department);
        Task<Department?> UpdateDepartmentAsync(int id, Department Department);
        Task<Department?> DeleteDepartmentAsync(int id);
    }

    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department?> GetDepartmentByNameAsync(string name);
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department?> UpdateDepartmentAsync(int id, Department Department);
        Task<Department?> DeleteDepartmentAsync(int id);
    }
}