using MediatR;

namespace EzRent.Service.Property.Command;

public class DeletePropertyByIdCommand : Domain.Entities.Property, INotification
{
    public DeletePropertyByIdCommand(int id)
    {
        this.PropertyId = id;
    }
}