using Dingfang.TaskManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dingfang.TaskManagementSystem.Core.RepositoryInterfaces
{
    public interface ITaskRepository:IAsyncRepository<TaskEntity>
    {
    }
}
