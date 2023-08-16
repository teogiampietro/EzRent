using EzRent.Domain.Repository;
using EzRent.Service.Category.Command;
using MediatR;

namespace EzRent.Service.Category.CommandHandler;

public class UpdateCategoryCommandHandler : INotificationHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _repository;

    public UpdateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCategoryCommand notification, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(notification.CategoryId, cancellationToken);

        if (category == null) throw new Exception("Category not found");

        category.Description = notification.Description;
        category.Name = notification.Name;

        await _repository.UpdateAsync(category, cancellationToken);
    }
}