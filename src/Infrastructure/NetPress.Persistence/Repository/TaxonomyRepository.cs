using Microsoft.EntityFrameworkCore;
using NetPress.Application.Contracts.Persistence;
using NetPress.Domain.Entities;

namespace NetPress.Persistence.Repository
{
    public class TaxonomyRepository(NetPressDbContext dbContext) : AsyncRepository<Taxonomy>(dbContext), ITaxonomyRepository
    {
        public override async Task<Taxonomy?> GetByIdAsync(int id)
        {
            return await GetAsQueryable().Where(p => p.Id == id)
                                         .Include(p => p.TaxonomyMetaData)
                                         .Include(p => p.TaxonomyPictures)
                                         .ThenInclude(p => p.Picture)
                                         .ThenInclude(p => p.PictureMetaData)
                                         .FirstOrDefaultAsync();
        }
    }
}
