using MediatR;

namespace EzRent.Service.Product.Query;

public class GetProductByIdQuery : IRequest<Domain.Entities.Product>
{
    public GetProductByIdQuery(int Id)
    {
        this.Id = Id;
    }
    public int Id { get; set; }
}