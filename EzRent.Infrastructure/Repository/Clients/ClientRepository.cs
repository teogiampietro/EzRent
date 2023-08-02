using EzRent.Domain.Entities;
using EzRent.Infrastructure.Context;

namespace EzRent.Infrastructure.Repository.Clients;

public class ClientRepository : RepositoryBase<Client>, IClientRepository
{
    public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}