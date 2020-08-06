using Dingfang.TaskManagementSystem.Core.Entities;
using Dingfang.TaskManagementSystem.Core.Models.Request;
using Dingfang.TaskManagementSystem.Core.Models.Response;
using Dingfang.TaskManagementSystem.Core.RepositoryInterfaces;
using Dingfang.TaskManagementSystem.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dingfang.TaskManagementSystem.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;
        public UserService(IUserRepository userRepository, ITaskRepository taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }
        public async Task<User> AddUser(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task DeleteUser(UserRequestModel user)
        {
            var userDb = await _userRepository.GetUserByEmail(user.Email);
            await _userRepository.DeleteAsync(userDb);
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasksByUser(int userId)
        {
            return await _taskRepository.ListAsync(t => t.UserId == userId);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {

            var usersDb = await _userRepository.ListAllAsync();
            List<UserResponseModel> users = new List<UserResponseModel>();
            foreach (var user in usersDb)
            {
                var userRes = new UserResponseModel
                {
                    Email = user.Email,
                    Id = user.Id,
                    Fullname = user.Fullname,
                    Mobileno = user.Mobileno
                };
                users.Add(userRes);
            };
            return users;
        }


        public async Task<User> UpdateUser(UserRequestModel user)
        {
            var userDb = await _userRepository.GetUserByEmail(user.Email);
            userDb.Email = user.Email;
            userDb.Password = user.Password;
            userDb.Fullname = user.Fullname;
            userDb.Mobileno = user.Mobileno;
            return await _userRepository.UpdateAsync(userDb);
        }
    }
}
