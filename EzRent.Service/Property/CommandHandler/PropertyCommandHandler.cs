using EzRent.Domain.Repository;
using EzRent.Service.Property.Command;
using MediatR;

namespace EzRent.Service.Property.CommandHandler;

public class PropertyCommandHandler : INotificationHandler<PropertyCommand>
{
    private readonly IPropertyRepository _repository;

    public PropertyCommandHandler(IPropertyRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(PropertyCommand notification, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(notification, cancellationToken);
    }
}