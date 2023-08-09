using MediatR;

namespace EzRent.Service.Product.Command;

public class UpdateProductStockCommand : INotification
{
    public UpdateProductStockCommand(List<Domain.Entities.Product> _products)
    {
        ProductsToUpdate = _products;
    }

    public List<Domain.Entities.Product> ProductsToUpdate { get; set; }
}