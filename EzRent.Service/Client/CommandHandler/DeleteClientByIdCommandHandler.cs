using EzRent.Infrastructure.Repository.Clients;
using EzRent.Service.Client.Command;
using MediatR;

namespace EzRent.Service.Client.CommandHandler;

public class DeleteClientByIdCommandHandler : INotificationHandler<DeleteClientByIdCommand>
{
    private readonly IClientRepository _repository;

    public DeleteClientByIdCommandHandler(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteClientByIdCommand notification, CancellationToken cancellationToken)
    {
        var client = await _repository.GetByIdAsync(notification.ClientId, cancellationToken);

        if (client == null) throw new Exception("Client not found");
        
        await _repository.DeleteAsync(client, cancellationToken);
    }
}