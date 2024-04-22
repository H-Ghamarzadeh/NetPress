using NetPress.Domain.Entities;

namespace NetPress.Application.Contracts.Persistence
{
    public interface ICategoryRepository: IAsyncRepository<Category>
    {
    }
}
