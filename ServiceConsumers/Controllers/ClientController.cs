using Microsoft.AspNetCore.Mvc;
using ServiceConsumers.Services;

namespace ServiceConsumers.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            string requestId = await _clientService.Create();
            return Ok(requestId);
        }

        [HttpGet("status")]
        public async Task<IActionResult> Status(string requestId)
        {
            string status = await _clientService.GetStatus(requestId);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }
    }
}
