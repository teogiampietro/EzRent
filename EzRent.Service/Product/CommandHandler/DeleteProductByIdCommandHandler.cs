using EzRent.Domain.Repository;
using EzRent.Service.Product.Command;
using MediatR;

namespace EzRent.Service.Product.CommandHandler;

public class DeleteProductByIdCommandHandler : INotificationHandler<DeleteProductByIdCommand>
{
    private readonly IProductRepository _repository;

    public DeleteProductByIdCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteProductByIdCommand notification, CancellationToken cancellationToken)
    {
        var property = await _repository.GetByIdAsync(notification.ProductId, cancellationToken);

        if (property == null) throw new Exception("Product not found");
        
        await _repository.DeleteAsync(property, cancellationToken);
    }
}