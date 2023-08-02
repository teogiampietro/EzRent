using MediatR;

namespace EzRent.Service.Client.Query;

public class GetClientByIdQuery : IRequest<Domain.Entities.Client>
{
    public GetClientByIdQuery(int Id)
    {
        this.Id = Id;
    }
    public int Id { get; set; }
}