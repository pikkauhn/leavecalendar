using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Dtos.InvitationCode;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class InvitationCodeController : ControllerBase
    {
        private readonly IInvitationCodeService _invitationCodeService;

        public InvitationCodeController(IInvitationCodeService invitationCodeService)
        {
            _invitationCodeService = invitationCodeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvitationCodeDto>>> GetAll()
        {
            var invitationCodes = await _invitationCodeService.GetAllInvitationCodesAsync();
            return Ok(invitationCodes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InvitationCodeDto>> GetById(int id)
        {
            var invitationCode = await _invitationCodeService.GetInvitationCodeByIdAsync(id);
            if (invitationCode == null)
            {
                return NotFound();
            }
            return Ok(invitationCode);

        }
        [HttpPost]
        public async Task<ActionResult<InvitationCodeDto>> CreateInvitationCode(InvitationCodeDto invitationCodeDto)
        {
            var createdInvitationCode = await _invitationCodeService.CreateInvitationCodeAsync(invitationCodeDto);
            return CreatedAtAction("GetById", new { id = createdInvitationCode.Id}, createdInvitationCode);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InvitationCodeDto invitationCodeDto)
        {
            if (id != invitationCodeDto.Id)
            {
                return BadRequest();
            }
            var updatedInvitationCode = await _invitationCodeService.UpdateInvitationCodeAsync(id, invitationCodeDto);
            if (updatedInvitationCode == null)
            {
                return NotFound();
            }
            return Ok(updatedInvitationCode);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _invitationCodeService.DeleteInvitationCodeAsync(id);
            if (success == null)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}