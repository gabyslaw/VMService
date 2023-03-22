using Microsoft.AspNetCore.Mvc;
using MockTestApi.Services;

namespace MockTestApi.Controllers
{
    [ApiController]
    [Route("api/vm")]
    public class VirtualMachineController : ControllerBase
    {
        private readonly IVMService _vMService;

        public VirtualMachineController(IVMService vMService)
        {
            _vMService = vMService;
        }

        [HttpPost("create")]
        public IActionResult CreateVirtualMachine()
        {
            string requestId = _vMService.Create();
            return Ok(requestId);
        }

        [HttpGet("status")]
        public IActionResult Status(string requestId)
        {
            string status = _vMService.GetStatus(requestId);
            if(status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }
    }
}
