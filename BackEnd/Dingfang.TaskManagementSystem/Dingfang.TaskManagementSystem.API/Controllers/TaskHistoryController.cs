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
    public class TaskHistoryController : ControllerBase
    {
        private readonly ITaskHistoryService _taskHistoryService;
        public TaskHistoryController(ITaskHistoryService taskHistoryService)
        {
            _taskHistoryService = taskHistoryService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddTaskHistory([FromBody] TaskHistory taskHistory)
        {
           var taskHistoryCreated = await _taskHistoryService.AddTaskHistory(taskHistory);
            return Ok(taskHistoryCreated);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateTaskHistory([FromBody] TaskHistoryRequestModel taskHistoryRequest )
        {
           var taskHistoryUpdated = await _taskHistoryService.UpdateTaskHistory(taskHistoryRequest);
            return Ok(taskHistoryUpdated);
        }

        [HttpGet]
        [Route("TaskHistories")]
        public async Task<IActionResult> GetAllTaskHistories()
        {
            var th = await _taskHistoryService.GetAllTaskHistories();
            return Ok(th);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteTaskHistory([FromBody] TaskHistoryRequestModel taskHistoryRequest)
        {
            await _taskHistoryService.DeleteTaskHistory(taskHistoryRequest);
            return Ok();
        }
    }
}
