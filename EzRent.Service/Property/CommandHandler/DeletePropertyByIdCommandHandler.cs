using EzRent.Domain.Repository;
using EzRent.Service.Property.Command;
using MediatR;

namespace EzRent.Service.Property.CommandHandler;

public class DeletePropertyByIdCommandHandler : INotificationHandler<DeletePropertyByIdCommand>
{
    private readonly IPropertyRepository _repository;

    public DeletePropertyByIdCommandHandler(IPropertyRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeletePropertyByIdCommand notification, CancellationToken cancellationToken)
    {
        var property = await _repository.GetByIdAsync(notification.PropertyId, cancellationToken);

        if (property == null) throw new Exception("Property not found");
        
        await _repository.DeleteAsync(property, cancellationToken);
    }
}