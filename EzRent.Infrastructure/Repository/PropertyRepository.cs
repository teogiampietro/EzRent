using EzRent.Domain.Entities;
using EzRent.Domain.Repository;
using EzRent.Infrastructure.Context;

namespace EzRent.Infrastructure.Repository;

public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
{
    public PropertyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}