using MediatR;

namespace EzRent.Service.Client.Command;

public class DeleteClientByIdCommand : Domain.Entities.Client, INotification
{
    public DeleteClientByIdCommand(int id)
    {
        ClientId = id;
    }
}