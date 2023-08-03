using EzRent.Domain.Repository;
using EzRent.Service.Product.Command;
using MediatR;

namespace EzRent.Service.Product.CommandHandler;

public class ProductCommandHandler : INotificationHandler<ProductCommand>
{
    private readonly IProductRepository _repository;

    public ProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(ProductCommand notification, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(notification, cancellationToken);
    }
}