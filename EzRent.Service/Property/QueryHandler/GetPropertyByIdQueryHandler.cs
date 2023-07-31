using EzRent.Infrastructure.Repository.Properties;
using EzRent.Service.Property.Queries;
using MediatR;

namespace EzRent.Service.Property.QueryHandler;

public class GetPropertyByIdQueryHandler :  IRequestHandler<GetPropertyByIdQuery, Domain.Entities.Property>
{
    private readonly IPropertyRepository _repository;

    public GetPropertyByIdQueryHandler(IPropertyRepository repository)
    {
        _repository = repository;
    }
    public async Task<Domain.Entities.Property> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id, cancellationToken) ??
               throw new Exception(nameof(GetPropertiesQueryHandler));
    }
}