using EzRent.Domain.Repository;
using EzRent.Service.Client.Query;
using MediatR;

namespace EzRent.Service.Client.QueryHandler;

public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Domain.Entities.Client>
{
    private readonly IClientRepository _repository;

    public GetClientByIdQueryHandler(IClientRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<Domain.Entities.Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id, cancellationToken) ??
               throw new Exception(nameof(GetClientByIdQueryHandler));
    }
}