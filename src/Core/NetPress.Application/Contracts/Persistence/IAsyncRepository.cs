namespace NetPress.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(Guid id, T entity);
        Task DeleteAsync(Guid id);
        IQueryable<T> GetAsQueryable();
    }
}
