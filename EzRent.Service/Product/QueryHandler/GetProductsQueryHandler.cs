using EzRent.Domain.Repository;
using EzRent.Service.Product.Query;
using MediatR;

namespace EzRent.Service.Product.QueryHandler;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Domain.Entities.Product>>
{
    private readonly IProductRepository _repository;

    public GetProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Domain.Entities.Product>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        return (await _repository.GetAllAsync(cancellationToken)).ToList() ??
               throw new Exception(nameof(GetProductsQueryHandler));
    }
}