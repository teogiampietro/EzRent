using EzRent.Infrastructure.Repository.Properties;
using EzRent.Service.Property.Query;
using MediatR;

namespace EzRent.Service.Property.QueryHandler;

public class GetPropertiesQueryHandler : IRequestHandler<GetPropertiesQuery, List<Domain.Entities.Property>>
{
    private readonly IPropertyRepository _repository;

    public GetPropertiesQueryHandler(IPropertyRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Domain.Entities.Property>> Handle(GetPropertiesQuery request,
        CancellationToken cancellationToken)
    {
        return (await _repository.GetAllAsync(cancellationToken)).ToList() ??
               throw new Exception(nameof(GetPropertiesQueryHandler));
    }
}