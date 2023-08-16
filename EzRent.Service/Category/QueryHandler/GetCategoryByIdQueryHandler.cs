using EzRent.Domain.Repository;
using EzRent.Service.Category.Query;
using MediatR;

namespace EzRent.Service.Category.QueryHandler;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Domain.Entities.Category>
{
    private readonly ICategoryRepository _repository;

    public GetCategoryByIdQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Category> Handle(GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id, cancellationToken) ??
               throw new Exception(nameof(GetCategoryByIdQuery));
    }
}