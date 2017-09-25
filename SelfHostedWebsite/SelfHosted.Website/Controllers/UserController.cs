using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfHosted.WebApi.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfHosted.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserClient _userClient;

        public UserController(ILogger<HomeController> logger, IUserClient userClient)
        {
            _userClient = userClient;
            _logger = logger;
        }

        public IActionResult Users()
        {
            return View();
        }


    }
}
