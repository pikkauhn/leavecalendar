using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using api.Security;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
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
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAllUsersAsync();

            var userDto = users.Select(s => s.ToUserDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto UserDto)
        {
            var existingUser = await _userRepo.GetUserByUsernameAsync(UserDto.Username);
            if (existingUser != null)
            {
                return BadRequest("User already exists.");
            }

            var user = UserDto.ToUserFromCreateDTO();
            user.Password = PasswordHasher.HashPassword(UserDto.Password);
            await _userRepo.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user.ToUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            var userModel = await _userRepo.UpdateUserAsync(id, updateDto);
            if (userModel == null)
            {
                return NotFound();
            }

            updateDto.Password = PasswordHasher.HashPassword(updateDto.Password);
            await _userRepo.UpdateUserAsync(id, updateDto);
            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _userRepo.DeleteUserAsync(id);

            if (stockModel == null)
            {
                return NotFound();
            }

            return NoContent();

        }

        [Route("api/Verify")]
        [HttpPost]
        public async Task<IActionResult> GetUserByUsername(string username, string password)
        {
            var existingUser = await _userRepo.GetUserByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }
            var isPasswordValid = PasswordHasher.VerifyPassword(existingUser.Password, password);
            return Ok(isPasswordValid);
        }
    }
}