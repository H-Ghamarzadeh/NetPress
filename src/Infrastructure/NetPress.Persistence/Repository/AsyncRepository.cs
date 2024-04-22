using Microsoft.EntityFrameworkCore;
using NetPress.Application.Contracts.Persistence;

namespace NetPress.Persistence.Repository
{
    public class AsyncRepository<T>(NetPressDbContext dbContext) : IAsyncRepository<T>
        where T : class
    {
        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                dbContext.Set<T>().Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }

        public IQueryable<T> GetAsQueryable()
        {
            return dbContext.Set<T>();
        }
    }
}
