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

    }
}