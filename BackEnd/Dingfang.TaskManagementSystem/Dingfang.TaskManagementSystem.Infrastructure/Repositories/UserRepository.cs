using Dingfang.TaskManagementSystem.Core.Entities;
using Dingfang.TaskManagementSystem.Core.RepositoryInterfaces;
using Dingfang.TaskManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dingfang.TaskManagementSystem.Infrastructure.Repositories
{
    public class UserRepository:EFRepository<User>,IUserRepository
    {
        public UserRepository(TaskDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            return user;
        }
    }
}
