using NetPress.Domain.Common;
using System.Linq.Expressions;

namespace NetPress.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[]? includes);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        IQueryable<T> GetAsQueryable();
    }
}
