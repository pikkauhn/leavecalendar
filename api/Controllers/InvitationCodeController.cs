using api.Interfaces;
using api.Dtos.InvitationCode;
using Microsoft.AspNetCore.Mvc;
using api.Models;

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
        [HttpGet("/api/[controller]/auth/{code}")]
        public async Task<ActionResult<InvitationCodeDto>> GetByCode(string code)
        {
            var invitationCode = await _invitationCodeService.GetInvitationCodeByCodeAsync(code);
            if (invitationCode == null)
            {
                return NotFound();
            }
            return Ok(invitationCode);

        }
        [HttpPost]
        public async Task<ActionResult<InvitationCodeDto>> CreateInvitationCode(InvitationCode invitationCode)
        {
            var createdInvitationCode = await _invitationCodeService.CreateInvitationCodeAsync(invitationCode);
            return CreatedAtAction("GetById", new { id = createdInvitationCode.idInvitationCode }, createdInvitationCode);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InvitationCodeChangeDto invitationCodeChangeDto)
        {
            if (id != invitationCodeChangeDto.Id)
            {
                return BadRequest();
            }
            var updatedInvitationCode = await _invitationCodeService.UpdateInvitationCodeAsync(id, invitationCodeChangeDto);
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