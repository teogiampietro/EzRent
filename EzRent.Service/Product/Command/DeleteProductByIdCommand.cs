using MediatR;

namespace EzRent.Service.Product.Command;

public class DeleteProductByIdCommand : Domain.Entities.Product, INotification
{
    public DeleteProductByIdCommand(int id)
    {
        this.ProductId = id;
    }
}