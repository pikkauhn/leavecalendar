using api.Dtos.Department;
using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return departments;
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return null;
            }
            return department;
        }

        public async Task<Department?> GetDepartmentByNameAsync(string name)
        {
            var department = await _departmentRepository.GetDepartmentByNameAsync(name);
            if (department == null)
            {
                return null;
            }
            return department;
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {            
            var createdDepartment = await _departmentRepository.CreateDepartmentAsync(department);
            return createdDepartment;
        }
        public async Task<Department?> DeleteDepartmentAsync(int id)
        {
            return await _departmentRepository.DeleteDepartmentAsync(id);
        }

        public async Task<Department?> UpdateDepartmentAsync(int id, Department department)
        {
            var updatedDepartment = await _departmentRepository.UpdateDepartmentAsync(id, department);
            return updatedDepartment;
        }
    }
}
