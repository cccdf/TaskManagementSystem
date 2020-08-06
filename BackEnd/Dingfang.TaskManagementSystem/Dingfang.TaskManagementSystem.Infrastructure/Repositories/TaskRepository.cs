using Dingfang.TaskManagementSystem.Core.Entities;
using Dingfang.TaskManagementSystem.Core.RepositoryInterfaces;
using Dingfang.TaskManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dingfang.TaskManagementSystem.Infrastructure.Repositories
{
    public class TaskRepository:EFRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(TaskDbContext dbContext) : base(dbContext)
        {

        }
    }
}
