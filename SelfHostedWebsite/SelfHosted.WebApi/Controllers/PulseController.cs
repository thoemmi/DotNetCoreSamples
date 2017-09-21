using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfHosted.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PulseController : ControllerBase
    {
        [HttpGet]
        [Route("IsAlive")]
        public bool IsAlive()
        {
            return true;
        }
    }
}
