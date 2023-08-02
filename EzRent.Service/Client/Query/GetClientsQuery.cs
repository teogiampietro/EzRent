using MediatR;

namespace EzRent.Service.Client.Query;

public class GetClientsQuery : IRequest<List<Domain.Entities.Client>>
{

}