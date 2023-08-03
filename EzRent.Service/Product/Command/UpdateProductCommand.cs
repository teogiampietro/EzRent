using MediatR;

namespace EzRent.Service.Product.Command;

public class UpdateProductCommand : Domain.Entities.Product, INotification
{

}