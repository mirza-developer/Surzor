using Microsoft.EntityFrameworkCore;
using Surzor.Application.Contracts.Persistence.Repositories;
using Surzor.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Surzor.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        internal readonly SurzorDbContext Context;
        internal readonly DbSet<T> DbSet;

        public BaseRepository(SurzorDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();

        }
        public async Task<List<T>> GetAllData(CancellationToken cancellationToken) =>
            await DbSet.AsNoTracking().ToListAsync();

        public async Task<List<T>> GetAllData(CancellationToken cancellationToken, params string[] includes)
        {
            if (includes.Length == 0)
                return await GetAllData(cancellationToken);
            var result = DbSet.AsNoTracking();
            result = includes.Aggregate(result, (current, t) => current.Include(t));
            return await result.ToListAsync(cancellationToken);
        }

        public async Task<T> GetSingleDataById(string id, CancellationToken token) =>
            await DbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id.ToString().Equals(id), token);

        public async Task<T> GetSingleDataById(string id, CancellationToken token, params string[] includes)
        {
            if (includes.Length == 0)
                return await GetSingleDataById(id, token);
            var result = DbSet.AsNoTracking();
            result = includes.Aggregate(result, (current, t) => current.Include(t));
            return await result.FirstOrDefaultAsync(p => p.Id.ToString().Equals(id), token);
        }

        public async Task<T> GetSingleDataByCustomFilter(Expression<Func<T, bool>> source, CancellationToken token) =>
            await DbSet.AsNoTracking().FirstOrDefaultAsync(source, token);

        public async Task<T> GetSingleDataByCustomFilter(Expression<Func<T, bool>> source, CancellationToken token, params string[] includes)
        {
            if (includes.Length == 0)
                return await GetSingleDataByCustomFilter(source, token);
            var result = DbSet.AsNoTracking();
            result = includes.Aggregate(result, (current, t) => current.Include(t));
            return await result.FirstOrDefaultAsync(source, token);
        }

        public async Task<bool> InsertInstance(T instance, CancellationToken token)
        {
            await DbSet.AddAsync(instance, token);
            return await Context.SaveChangesAsync(token) == 1;
        }

        public async Task<bool> DeleteInstanceById(string id, CancellationToken token)
        {
            var entity = await DbSet.FirstOrDefaultAsync(p => p.Id.ToString().Equals(id), token);
            if (entity != null)
            {
                DbSet.Remove(entity);
                Context.Entry(entity).State = EntityState.Deleted;
                return await Context.SaveChangesAsync(token) == 1;
            }
            return false;
        }

        public async Task<bool> UpdateInstance(T instance, CancellationToken token)
        {
            DbSet.Update(instance);
            return await Context.SaveChangesAsync(token) == 1;
        }
    }
}
