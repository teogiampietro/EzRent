using MediatR;

namespace EzRent.Service.Product.Query;

public class GetProductsQuery : IRequest<List<Domain.Entities.Product>>
{
}