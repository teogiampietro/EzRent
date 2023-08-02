using EzRent.Domain.Repository;
using EzRent.Service.Client.Command;
using MediatR;

namespace EzRent.Service.Client.CommandHandler;

public class UpdateClientCommandHandler  : INotificationHandler<UpdateClientCommand>
{
    private readonly IClientRepository _repository;

    public UpdateClientCommandHandler(IClientRepository repository)
    {
        _repository = repository;
        
    }
    public async Task Handle(UpdateClientCommand notification, CancellationToken cancellationToken)
    {
        
        var client = await _repository.GetByIdAsync(notification.ClientId, cancellationToken);

        if (client == null) throw new Exception("Property not found");
        
        client.PersonalId = notification.PersonalId;
        client.Name = notification.Name;
        client.Surname = notification.Surname;
        client.Email = notification.Email;
        
        await _repository.UpdateAsync(client, cancellationToken);
    }
}