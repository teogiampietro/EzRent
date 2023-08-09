using EzRent.Domain.Repository;
using EzRent.Service.Product.Command;
using MediatR;

namespace EzRent.Service.Product.CommandHandler;

public class UpdateProductStockCommandHandler : INotificationHandler<UpdateProductStockCommand>
{
    private readonly IProductRepository _repository;

    public UpdateProductStockCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateProductStockCommand notification, CancellationToken cancellationToken)
    {
        var productsIds = notification.ProductsToUpdate.Select(x => x.ProductId).ToList();
        
        var productsToUpdate = await _repository.GetAsync(predicate: x => productsIds.Contains(x.ProductId),
            cancellationToken);

        foreach (var product in productsToUpdate)
        {
            var productUpdated = notification.ProductsToUpdate.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (productUpdated == null) break;

            product.Quantity = productUpdated.Quantity;
        }

        await _repository.UpdateListAsync(productsToUpdate, cancellationToken);
    }
}