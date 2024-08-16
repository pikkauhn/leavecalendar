using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Department;
using api.Models;

namespace api.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department?> GetDepartmentByNameAsync(string name);
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department?> UpdateDepartmentAsync(int id, Department department);
        Task<Department?> DeleteDepartmentAsync(int id);
    }

    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department?> GetDepartmentByNameAsync(string name);
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department?> UpdateDepartmentAsync(int id, Department department);
        Task<Department?> DeleteDepartmentAsync(int id);
    }
        public interface IDepartmentMapper
    {
        DepartmentDto MapToDepartmentDto(Department department);
        Department MapToDepartment(DepartmentDto departmentDto);
    }
}