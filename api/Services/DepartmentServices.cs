using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllDepartmentsAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(id);
        }

        public async Task<Department?> GetDepartmentByNameAsync(string name)
        {
            return await _departmentRepository.GetDepartmentByNameAsync(name);
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            return await _departmentRepository.CreateDepartmentAsync(department);
        }
        public async Task<Department?> DeleteDepartmentAsync(int id)
        {
            return await _departmentRepository.DeleteDepartmentAsync(id);
        }

        public async Task<Department?> UpdateDepartmentAsync(int id, Department department)
        {
            return await _departmentRepository.UpdateDepartmentAsync(id, department);
        }
    }
}
