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
    public class TaskHistoryService:ITaskHistoryService
    {
        private readonly ITaskHistoryRepository _taskHistoryRepository;
        public TaskHistoryService(ITaskHistoryRepository taskHistoryRepository)
        {
            _taskHistoryRepository = taskHistoryRepository;
        }

        public async Task<TaskHistory> AddTaskHistory(TaskHistory taskHistory)
        {
            
            return await _taskHistoryRepository.AddAsync(taskHistory);
        }

        public async Task DeleteTaskHistory(TaskHistoryRequestModel taskHistoryRequest)
        {
            var thDb = await _taskHistoryRepository.GetByIdAsync(taskHistoryRequest.TaskId);
            await _taskHistoryRepository.DeleteAsync(thDb);
        }

        public async Task<IEnumerable<TaskHistory>> GetAllTaskHistories()
        {
            return await _taskHistoryRepository.ListAllAsync();
        }

        public async Task<TaskHistory> UpdateTaskHistory(TaskHistoryRequestModel taskHistoryRequest)
        {
            var thDb = await _taskHistoryRepository.GetByIdAsync(taskHistoryRequest.TaskId);
            thDb.UserId = taskHistoryRequest.UserId;
            thDb.Title = taskHistoryRequest.Title;
            thDb.Description = taskHistoryRequest.Description;
            thDb.DueDate = taskHistoryRequest.DueDate;
            thDb.Completed = taskHistoryRequest.Completed;
            thDb.Remarks = taskHistoryRequest.Remarks;
            return await _taskHistoryRepository.UpdateAsync(thDb);
        }
    }
}
