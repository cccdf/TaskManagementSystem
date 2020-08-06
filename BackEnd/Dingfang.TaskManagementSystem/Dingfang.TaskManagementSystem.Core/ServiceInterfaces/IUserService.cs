using Dingfang.TaskManagementSystem.Core.Entities;
using Dingfang.TaskManagementSystem.Core.Models.Request;
using Dingfang.TaskManagementSystem.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dingfang.TaskManagementSystem.Core.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<TaskEntity>> GetAllTasksByUser(int userId);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(UserRequestModel user);
        Task DeleteUser(UserRequestModel user);
        Task<IEnumerable<UserResponseModel>> GetAllUsers();
        
    }
}
