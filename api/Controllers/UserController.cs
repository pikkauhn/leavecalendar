using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Repository;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepo;        

        public UserController(ApplicationDBContext context, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {            
            try
            {
            var users = await _userRepo.GetAllUsersAsync();            
            return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}