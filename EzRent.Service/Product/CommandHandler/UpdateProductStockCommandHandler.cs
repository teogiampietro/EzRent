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
        var productsIdsToUpdate = notification.StockToUpdate.Select(x => x.ProductId).ToList();
        
        var productsToUpdate = await _repository.GetAllAsync(cancellationToken);
        
        productsToUpdate = productsToUpdate.Where(x => productsIdsToUpdate.Contains(x.ProductId)).ToList();
       
        foreach (var product in productsToUpdate)
        {
            var stockUpdate = notification.StockToUpdate.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (stockUpdate == null) return;

            product.Quantity = stockUpdate.Quantity;
            await _repository.UpdateAsync(product, cancellationToken);
        }

        //_repository.UpdateListAsync(productsToUpdate.ToList(), cancellationToken);
    }
}
