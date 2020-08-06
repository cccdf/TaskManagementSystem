using Dingfang.TaskManagementSystem.Core.Entities;
using Dingfang.TaskManagementSystem.Core.Models.Request;
using Dingfang.TaskManagementSystem.Core.RepositoryInterfaces;
using Dingfang.TaskManagementSystem.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dingfang.TaskManagementSystem.Infrastructure.Services
{
    public class TaskService:ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskEntity> AddTask(TaskRequestModel task)
        {
            var taskCreated = new TaskEntity
            {
                UserId = task.UserId,
                Title=task.Title,
                Description=task.Description,
                DueDate=task.DueDate,
                Priority=task.Priority,
                Remarks=task.Remarks
            };
            return await _taskRepository.AddAsync(taskCreated);
        }

        public Task AssignTaskToUser(int taskId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTask(TaskRequestModel task)
        {
            var taskDb = await _taskRepository.GetByIdAsync(task.Id);
            await _taskRepository.DeleteAsync(taskDb);
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasks()
        {
           return await _taskRepository.ListAllAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetTasksByUserId(int userId)
        {
            return await _taskRepository.ListAsync(t => t.UserId == userId);
        }

        public async Task<TaskEntity> UpdateTask(TaskRequestModel task)
        {
            var taskDb = await _taskRepository.GetByIdAsync(task.Id);
            taskDb.UserId = task.UserId;
            taskDb.Title = task.Title;
            taskDb.Description = task.Description;
            taskDb.DueDate = task.DueDate;
            taskDb.Priority = task.Priority;
            taskDb.Remarks = task.Remarks;

            var updatedTask = await _taskRepository.UpdateAsync(taskDb);
            return updatedTask;
        }
    }
}
