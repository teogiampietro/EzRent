using MediatR;

namespace EzRent.Service.Category.Query;

public class GetCategoryByIdQuery : IRequest<Domain.Entities.Category>
{
    public GetCategoryByIdQuery(int Id)
    {
        this.Id = Id;
    }
    public int Id { get; set; }
}