using EzRent.Domain.Repository;
using EzRent.Service.Product.Command;
using MediatR;

namespace EzRent.Service.Product.CommandHandler;

public class UpdateProductCommandHandler : INotificationHandler<UpdateProductCommand>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
        
    }
    public async Task Handle(UpdateProductCommand notification, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(notification.ProductId, cancellationToken);

        if (product == null) throw new Exception("Product not found");
        
        product.Description = notification.Description;
        product.ItemsPerBox = notification.ItemsPerBox;
        product.Price = notification.Price;
        product.Quantity = notification.Quantity;
        
        await _repository.UpdateAsync(product, cancellationToken);
    }
}