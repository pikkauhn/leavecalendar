using api.Dtos.Department;
using api.Models;

namespace api.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department?> GetDepartmentByNameAsync(string name);
        Task<Department> CreateDepartmentAsync(Department departmentDto);
        Task<Department?> UpdateDepartmentAsync(int id, Department departmentDto);
        Task<Department?> DeleteDepartmentAsync(int id);
    }

    public interface IDepartmentRepository
    {
        Task<List<DepartmentDto>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department?> GetDepartmentByNameAsync(string name);
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department?> UpdateDepartmentAsync(int id, Department departmentDto);
        Task<Department?> DeleteDepartmentAsync(int id);
    }
}