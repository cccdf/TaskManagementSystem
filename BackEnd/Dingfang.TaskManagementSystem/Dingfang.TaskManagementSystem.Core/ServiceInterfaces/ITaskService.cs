using Dingfang.TaskManagementSystem.Core.Entities;
using Dingfang.TaskManagementSystem.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Dingfang.TaskManagementSystem.Core.ServiceInterfaces
{
    public interface ITaskService
    {
        //Task<IEnumerable<TaskEntity>> 
        Task<TaskEntity> GetTaskById(int taskId);
        Task AssignTaskToUser(int taskId, int userId);
        Task<TaskEntity> AddTask(TaskRequestModel task);
        Task<TaskEntity> UpdateTask(TaskRequestModel task);
        Task DeleteTask(TaskRequestModel task);
        Task<IEnumerable<TaskEntity>> GetAllTasks();
        Task<IEnumerable<TaskEntity>> GetTasksByUserId(int userId);
    }
}
