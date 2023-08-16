using MediatR;

namespace EzRent.Service.Category.Command;

public class DeleteCategoryByIdCommand : Domain.Entities.Category, INotification
{
    public DeleteCategoryByIdCommand(int CategoryId)
    {
        this.CategoryId = CategoryId;
    }
}