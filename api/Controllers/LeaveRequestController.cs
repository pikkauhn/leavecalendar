using api.Dtos.LeaveRequest;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;
        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }
        [HttpGet]
        public async Task<ActionResult<LeaveRequestDto>> GetAll()
        {
            var leaveRequests = await _leaveRequestService.GetAllLeaveRequestsAsync();
            return Ok(leaveRequests);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> GetById(int id)
        {
            var leaveRequest = await _leaveRequestService.GetLeaveRequestByIdAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            return Ok(leaveRequest);
        }
        [HttpPost]
        public async Task<ActionResult<LeaveRequestDto>> Create(CreateLeaveRequestDto createLeaveRequestDto)
        {
            var leaveRequestDto = new LeaveRequestDto{
                Id = 0,
                UserId = createLeaveRequestDto.UserId,
                Reason = createLeaveRequestDto.Reason,
                StartDate = createLeaveRequestDto.StartDate,
                EndDate = createLeaveRequestDto.EndDate,
                LeaveType = createLeaveRequestDto.LeaveType,
                Status = (int)LeaveStatus.Pending,
                Comment = null,
                ResponseByUserId = 0
            };
            var createdLeaveRequest = await _leaveRequestService.CreateLeaveRequestAsync(leaveRequestDto);
            return CreatedAtAction("GetById", new { id = createdLeaveRequest.UserId }, createdLeaveRequest);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LeaveRequestDto updatedLeaveRequest)
        {
            var existingLeaveRequest = await _leaveRequestService.UpdateLeaveRequestAsync(id, updatedLeaveRequest);
            if (existingLeaveRequest == null)
            {
                return NotFound();
            }            
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _leaveRequestService.DeleteLeaveRequestAsync(id);       
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
        
        [HttpGet]
        [Route("userRequest/{userId}")]
        public async Task<ActionResult<LeaveRequest>> GetByUserId(int userId)
        {
            var leaveRequest = await _leaveRequestService.GetLeaveRequestByUserIdAsync(userId);
            
            return Ok(leaveRequest);
        }
    }
}