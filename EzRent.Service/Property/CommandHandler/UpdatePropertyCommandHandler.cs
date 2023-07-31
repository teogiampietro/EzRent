using EzRent.Infrastructure.Repository.Properties;
using EzRent.Service.Property.Command;
using MediatR;

namespace EzRent.Service.Property.CommandHandler;

public class UpdatePropertyCommandHandler : INotificationHandler<UpdatePropertyCommand>
{
    private readonly IPropertyRepository _repository;

    public UpdatePropertyCommandHandler(IPropertyRepository repository)
    {
        _repository = repository;
        
    }
    public async Task Handle(UpdatePropertyCommand notification, CancellationToken cancellationToken)
    {
        var property = await _repository.GetByIdAsync(notification.PropertyId, cancellationToken);

        if (property == null) throw new Exception("Property not found");
        
        property.Environments = notification.Environments;
        property.Price = notification.Price;
        property.RentPrice = notification.RentPrice;
        
        await _repository.UpdateAsync(property, cancellationToken);
    }
}