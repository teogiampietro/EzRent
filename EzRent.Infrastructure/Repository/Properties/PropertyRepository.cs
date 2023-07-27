using EzRent.Domain.Entities;
using EzRent.Infrastructure.Context;

namespace EzRent.Infrastructure.Repository.Properties;

public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
{
    public PropertyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}