using MediatR;

namespace EzRent.Service.Category.Query;

public class GetCategoriesQuery: IRequest<List<Domain.Entities.Category>>
{
    
}