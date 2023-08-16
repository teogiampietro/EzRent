using EzRent.Domain.Repository;
using EzRent.Service.Category.Command;
using MediatR;

namespace EzRent.Service.Category.CommandHandler;

public class CategoryCommandHandler : INotificationHandler<CategoryCommand>
{
    private readonly ICategoryRepository _repository;

    public CategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CategoryCommand notification, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(notification, cancellationToken);
    }
}