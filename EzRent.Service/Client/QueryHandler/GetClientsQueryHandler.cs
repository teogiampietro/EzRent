using EzRent.Infrastructure.Repository.Clients;
using EzRent.Service.Client.Query;
using MediatR;

namespace EzRent.Service.Client.QueryHandler;

public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<Domain.Entities.Client>>
{
    private readonly IClientRepository _repository;

    public GetClientsQueryHandler(IClientRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Domain.Entities.Client>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.GetAllAsync(cancellationToken)).ToList() ??
               throw new Exception(nameof(GetClientsQueryHandler));
    }
}