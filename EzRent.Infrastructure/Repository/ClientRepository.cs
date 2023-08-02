using EzRent.Domain.Entities;
using EzRent.Domain.Repository;
using EzRent.Infrastructure.Context;

namespace EzRent.Infrastructure.Repository;

public class ClientRepository : RepositoryBase<Client>, IClientRepository
{
    public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}