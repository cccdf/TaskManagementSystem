﻿using Dingfang.TaskManagementSystem.Core.RepositoryInterfaces;
using Dingfang.TaskManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dingfang.TaskManagementSystem.Infrastructure.Repositories
{
    public class EFRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly TaskDbContext _dbContext;
        public EFRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();

        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
