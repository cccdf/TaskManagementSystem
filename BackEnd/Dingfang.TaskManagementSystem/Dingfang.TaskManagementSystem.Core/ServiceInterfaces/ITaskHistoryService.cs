using Dingfang.TaskManagementSystem.Core.Entities;
using Dingfang.TaskManagementSystem.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dingfang.TaskManagementSystem.Core.ServiceInterfaces
{
    public interface ITaskHistoryService
    {
        Task<TaskHistory> AddTaskHistory(TaskHistory taskHistory);
        Task<TaskHistory> UpdateTaskHistory(TaskHistoryRequestModel taskHistoryRequest);
        Task DeleteTaskHistory(TaskHistoryRequestModel taskHistoryRequest);
        Task<IEnumerable<TaskHistory>> GetAllTaskHistories();
    }
}
