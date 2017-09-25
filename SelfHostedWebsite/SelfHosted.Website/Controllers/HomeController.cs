using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SelfHosted.Models.Common;
using SelfHosted.WebApi.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelfHosted.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserClient _userClient;

        public HomeController(ILogger<HomeController> logger, IUserClient userClient)
        {
            _userClient = userClient;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index view loaded ...");

            var users = await _userClient.GetAllUsersAsync();

            return View();
        }

        public IActionResult Error()
        {
            _logger.LogInformation("Error view loaded ...");

            return View();
        }
    }
}
