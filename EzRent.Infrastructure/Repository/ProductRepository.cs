using EzRent.Domain.Entities;
using EzRent.Domain.Repository;
using EzRent.Infrastructure.Context;

namespace EzRent.Infrastructure.Repository;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}