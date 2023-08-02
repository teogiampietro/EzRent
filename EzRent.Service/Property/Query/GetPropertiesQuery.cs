using MediatR;

namespace EzRent.Service.Property.Query;

public class GetPropertiesQuery : IRequest<List<Domain.Entities.Property>>
{
}