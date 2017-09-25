using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace SelfHosted.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PulseController : ControllerBase
    {
        [HttpGet]
        [Route("IsAlive")]
        [SwaggerOperation("Pulse_IsAlive")]
        public bool IsAlive()
        {
            return true;
        }
    }
}
