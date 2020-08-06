using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dingfang.TaskManagementSystem.Core.Entities;
using Dingfang.TaskManagementSystem.Core.Models.Request;
using Dingfang.TaskManagementSystem.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dingfang.TaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddUser([FromBody] UserRequestModel userRequestModel)
        {
            var user = new User
            {
                Email = userRequestModel.Email,
                Password = userRequestModel.Password,
                Fullname = userRequestModel.Fullname,
                Mobileno = userRequestModel.Mobileno
            };
            var userCreated = await _userService.AddUser(user);
            return Ok(userCreated);
        }
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRequestModel userRequestModel)
        {
            var userUpdated = await _userService.UpdateUser(userRequestModel);
            return Ok(userUpdated);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] UserRequestModel userRequestModel)
        {
            await _userService.DeleteUser(userRequestModel);
            return Ok();
        }
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
