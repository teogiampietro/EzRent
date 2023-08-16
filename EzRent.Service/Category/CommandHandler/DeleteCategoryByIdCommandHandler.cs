using EzRent.Domain.Repository;
using EzRent.Service.Category.Command;
using MediatR;

namespace EzRent.Service.Category.CommandHandler;

public class DeleteCategoryByIdCommandHandler : INotificationHandler<DeleteCategoryByIdCommand>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryByIdCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteCategoryByIdCommand notification, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(notification.CategoryId, cancellationToken);
        
        if (category == null) throw new Exception("Category not found");

        await _repository.DeleteAsync(category, cancellationToken);
    }
}