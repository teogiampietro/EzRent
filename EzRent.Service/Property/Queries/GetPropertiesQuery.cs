using MediatR;

namespace EzRent.Service.Property.Queries;

public class GetPropertiesQuery : IRequest<List<Domain.Entities.Property>>
{
    public string Name { get; set; }
}