using api.Dtos.User;
using api.Interfaces;
using api.Models;
using api.Security;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();

            var userDto = _mapper.Map<List<UserDto>>(users);

            return Ok(userDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
            var existingUser = await _userService.GetUserByUsernameAsync(userDto.Username);
            if (existingUser != null)
            {
                return BadRequest("User already exists.");
            }

            var user = _mapper.Map<User>(userDto);
            user.Password = PasswordHasher.HashPassword(userDto.Password);
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            var userModel = await _userService.UpdateUserAsync(id, updateDto);
            if (!userModel)
            {
                return NotFound();
            }
            return Ok(userModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _userService.DeleteUserAsync(id);

            if (!stockModel)
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpGet]
        [Route("username/{username}")]
        public async Task<IActionResult> GetUserByUsername( string username )
        {
            var existingUser = await _userService.GetUserByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }
            return Ok(existingUser);
        }

        [Route("Verify")]
        [HttpPost]
        public async Task<IActionResult> VerifyUserAccount(VerifyUserPassword user)
        {
            var existingUser = await _userService.GetUserByUsernameAsync(user.Username);
            if (existingUser == null)
            {
                return NotFound();
            }
            var isPasswordValid = PasswordHasher.VerifyPassword(existingUser.Password, user.Password);
            return Ok(isPasswordValid);
        }
    }
}