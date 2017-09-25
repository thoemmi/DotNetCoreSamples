using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using SelfHosted.Models.Domain;
using SelfHosted.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfHosted.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            this._userRepository = userRepository;
            this._logger = logger;
        }

        [HttpPost]
        [Route("Create")]
        [SwaggerOperation("User_CreateUser")]
        public async Task<User> Create(string firstname, string lastname, string email, string businessUnit)
        {
            var user = new User()
            {
                BusinessUnit = businessUnit,
                Email = email,
                Firstname = firstname,
                LastName = lastname
            };

            var result =  await _userRepository.Create(user);

            _logger.LogInformation($"user with id {result.UserId} created.");

            return result;
        }

        [HttpPost]
        [Route("Remove")]
        [SwaggerOperation("User_RemoveUser")]
        public async Task<bool> Remove(int userId)
        {
            var user = await GetUserById(userId);
            var result = await _userRepository.Remove(user);

            if(result == true)
                _logger.LogInformation($"user with id {user.UserId} deleted.");
            else
                _logger.LogInformation($"cant remove user with id {user.UserId}.");

            return result;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        [SwaggerOperation("User_GetAllUsers")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.Get(null);
        }

        [HttpGet]
        [Route("GetUserById")]
        [SwaggerOperation("User_GetUserById")]
        public async Task<User> GetUserById(int userId)
        {
            return (await _userRepository.Get(m => m.UserId == userId))?.FirstOrDefault();
        }

    }
}
