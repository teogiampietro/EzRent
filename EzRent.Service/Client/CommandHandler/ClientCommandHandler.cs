using EzRent.Infrastructure.Repository.Clients;
using EzRent.Service.Client.Command;
using MediatR;

namespace EzRent.Service.Client.CommandHandler;

public class ClientCommandHandler : INotificationHandler<ClientCommand>
{
    private readonly IClientRepository _repository;

    public ClientCommandHandler(IClientRepository repository)
    {
        _repository = repository;
    }

    
    public async Task Handle(ClientCommand notification, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(notification, cancellationToken);
    }
}