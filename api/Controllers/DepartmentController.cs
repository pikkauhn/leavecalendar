using api.Data;
using api.Dtos.Department;
using api.Interfaces;
using api.Mappers;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            var departmentDto = _mapper.Map<List<DepartmentDto>>(departments);
            return Ok(departmentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentDto departmentDto)
        {
            var existingDepartment = await _departmentService.GetDepartmentByNameAsync(departmentDto.Name);
            if (existingDepartment != null)
            {
                return BadRequest("Department already exists.");
            }

            var department = _mapper.Map<Department>(departmentDto);
            await _departmentService.CreateDepartmentAsync(department);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Department department)
        {
            var existingDepartment = await _departmentService.UpdateDepartmentAsync(id, department);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DepartmentDto>(department));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentService.DeleteDepartmentAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}