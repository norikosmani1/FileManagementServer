using FileManagementServer.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementServer.Infrastructure.Data.Repositories
{
    public abstract class GenericRepository
    {
        private readonly FileManagementDBContext _ctx;

        public GenericRepository(FileManagementDBContext ctx)
        {
            _ctx = ctx;
        }

        public virtual async Task<T> InsertAsync<T>(T entity) where T : class
        {
            await _ctx.Set<T>().AddAsync(entity);

            return entity;
        }

        public virtual async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CountAsync<T>() where T : class
        {
            return await _ctx.Set<T>().CountAsync();
        }

        public virtual async Task<ICollection<T>> GetAllAsync<T>() where T : class
        {
            return await _ctx.Set<T>().ToListAsync();
        }
    }
}
