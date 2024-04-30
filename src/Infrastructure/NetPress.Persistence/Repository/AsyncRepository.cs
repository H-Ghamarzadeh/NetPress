using Microsoft.EntityFrameworkCore;
using NetPress.Application.Contracts.Persistence;
using NetPress.Domain.Common;

namespace NetPress.Persistence.Repository
{
    public class AsyncRepository<T>(NetPressDbContext dbContext) : IAsyncRepository<T>
        where T : BaseEntity
    {
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(p=> p.Id == id);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task UpdateAsync(int id, T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                dbContext.Set<T>().Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }

        public virtual IQueryable<T> GetAsQueryable()
        {
            return dbContext.Set<T>().AsNoTracking();
        }
    }
}
