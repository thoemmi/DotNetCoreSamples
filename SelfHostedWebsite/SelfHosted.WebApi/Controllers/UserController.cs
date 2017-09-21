using Microsoft.AspNetCore.Mvc;
using SelfHosted.Models.Domain;
using SelfHosted.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHosted.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<User> Create(string firstname, string lastname, string email, string businessUnit)
        {
            var user = new User()
            {
                BusinessUnit = businessUnit,
                Email = email,
                Firstname = firstname,
                LastName = lastname
            };

            return await _userRepository.Create(user);
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<bool> Remove(int userId)
        {
            var user = await GetUserById(userId);
            return await _userRepository.Remove(user);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.Get(null);
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<User> GetUserById(int userId)
        {
            return (await _userRepository.Get(m => m.UserId == userId))?.FirstOrDefault();
        }

    }
}
