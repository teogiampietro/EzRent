using MediatR;

namespace EzRent.Service.Property.Queries;

public class GetPropertyByIdQuery : IRequest<Domain.Entities.Property>
{
    public GetPropertyByIdQuery(int Id)
    {
        this.Id = Id;
    }
    public int Id { get; set; }
}