using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Department;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBContext _context;
        public DepartmentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            try
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return department;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating a department", ex);
            }
        }

        public async Task<Department?> DeleteDepartmentAsync(int id)
        {
            try
            {
                var existingDepartment = await _context.Departments.FindAsync(id);
                if (existingDepartment == null)
                {
                    return null;
                }
                _context.Departments.Remove(existingDepartment);
                await _context.SaveChangesAsync();
                return existingDepartment;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting a department with id: {id}", ex);
            }
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            try
            {
                return await _context.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all departments", ex);
            }
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            try
            {
                var existingDepartment = await _context.Departments.FindAsync(id);
                if (existingDepartment == null)
                {
                    return null;
                }
                return existingDepartment;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving a department by id: {id}", ex);
            }
        }

        public async Task<Department?> GetDepartmentByNameAsync(string name)
        {
            try
            {
                return await _context.Departments.FirstOrDefaultAsync(d => d.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving a department by name: {name}", ex);
            }
        }

        public async Task<Department?> UpdateDepartmentAsync(int id, Department department)
        {
            try
            {
                var existingDepartment = await _context.Departments.FindAsync(id);
                if (existingDepartment == null)
                {
                    return null;
                }
                _context.Entry(existingDepartment).CurrentValues.SetValues(department);
                await _context.SaveChangesAsync();
                return existingDepartment;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating a department with id: {id}", ex);
            }
        }
    }
}