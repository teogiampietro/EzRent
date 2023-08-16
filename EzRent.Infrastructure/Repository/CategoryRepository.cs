using EzRent.Domain.Entities;
using EzRent.Domain.Repository;
using EzRent.Infrastructure.Context;

namespace EzRent.Infrastructure.Repository;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}