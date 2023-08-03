using EzRent.Domain.Repository;
using EzRent.Service.Product.Query;
using MediatR;

namespace EzRent.Service.Product.QueryHandler;

public class GetProductByIdQueryHandler :  IRequestHandler<GetProductByIdQuery, Domain.Entities.Product>
{
    private readonly IProductRepository _repository;

    public GetProductByIdQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<Domain.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id, cancellationToken) ??
               throw new Exception(nameof(GetProductByIdQuery));
    }
}