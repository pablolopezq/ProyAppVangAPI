using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyAppVangAPI.Core.Entities;
using ProyAppVangAPI.Core.Enums;
using ProyAppVangAPI.Core.Interfaces;
using ProyAppVangAPI.Models;

namespace ProyAppVangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<UserDto> Create([FromBody] string username, [FromBody] string password)
        {
            var user = new User
            {
                Password = password,
                Username = username
            };

            if (!_userService.Check(user).Result)
            {
                return BadRequest("Usuario ya existe");
            }

            var serviceResult = _userService.Create(user);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            return Ok(new UserDto
            {
                Username = user.Username,
                Password = user.Password
            });
        }
    }
}
