using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dingfang.TaskManagementSystem.Core.Models.Request;
using Dingfang.TaskManagementSystem.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dingfang.TaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddTask([FromBody] TaskRequestModel taskRequest)
        {
           var taskAdded = await _taskService.AddTask(taskRequest);
            return Ok(taskAdded);
        }

        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateTask([FromBody] TaskRequestModel taskRequest)
        {
            var taskUpdated = await _taskService.UpdateTask(taskRequest);
            return Ok(taskUpdated);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteTask([FromBody] TaskRequestModel taskRequest)
        {
            await _taskService.DeleteTask(taskRequest);
            return Ok();
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("tasks/user/{userId}")]

        public async Task<IActionResult> GetTasksByUserId(int userId)
        {
            var tasks = await _taskService.GetTasksByUserId(userId);
            return Ok(tasks);
        }
    }
}
