using EzRent.Domain.Repository;
using EzRent.Service.Category.Query;
using MediatR;

namespace EzRent.Service.Category.QueryHandler;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Domain.Entities.Category>>
{
    private readonly ICategoryRepository _repository;

    public GetCategoriesQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Domain.Entities.Category>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        return (await _repository.GetAllAsync(cancellationToken)).ToList() ??
               throw new Exception(nameof(GetCategoriesQueryHandler));
    }
}