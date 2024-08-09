using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.LeaveRequest;
using api.Interfaces;
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
        public async Task<ActionResult<LeaveRequestDto>> Create(LeaveRequestDto leaveRequestDto)
        {
            var createdLeaveRequest = await _leaveRequestService.CreateLeaveRequestAsync(leaveRequestDto);
            return CreatedAtAction("GetById", new { id = createdLeaveRequest.UserId }, createdLeaveRequest);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LeaveRequestDto updatedLeaveRequest)
        {
            await _leaveRequestService.UpdateLeaveRequestAsync(id, updatedLeaveRequest);
            
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _leaveRequestService.DeleteLeaveRequestAsync(id);       
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}