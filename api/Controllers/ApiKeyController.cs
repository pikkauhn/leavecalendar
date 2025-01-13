using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ApiKeyController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ApiKeyController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("generate")]
        public IActionResult GenerateApiKey()
        {
            string apiKey = KeyGen.GenerateApiKey(32);
            
            return Ok(apiKey);
        }
    }
}