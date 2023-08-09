using MediatR;

namespace EzRent.Service.Product.Command;

public class UpdateProductStockCommand : INotification
{
    public UpdateProductStockCommand(List<Domain.Entities.Product> products)
    {
        StockToUpdate = products;
    }
    public List<Domain.Entities.Product> StockToUpdate { get; set; }
}