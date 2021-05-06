using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Surzor.Application.Contracts.Persistence.Repositories
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<List<T>> GetAllData(CancellationToken cancellationToken);
        Task<List<T>> GetAllData(CancellationToken cancellationToken, params string[] includes);
        Task<T> GetSingleDataById(string id, CancellationToken token);
        Task<T> GetSingleDataById(string id, CancellationToken token, params string[] includes);
        Task<T> GetSingleDataByCustomFilter(Expression<Func<T, bool>> source, CancellationToken token);
        Task<T> GetSingleDataByCustomFilter(Expression<Func<T, bool>> source, CancellationToken token, params string[] includes);
        Task<bool> InsertInstance(T instance, CancellationToken token);
        Task<bool> DeleteInstanceById(string id, CancellationToken token);
        Task<bool> UpdateInstance(T instance, CancellationToken token);
    }
}
