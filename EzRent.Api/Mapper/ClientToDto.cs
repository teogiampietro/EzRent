using AutoMapper;
using EzRent.Service.Client.Command;
using EzRent.Service.Property.Command;
using EzRent.Shared;

namespace EzRent.Api.Mapper;

public class ClientToDto: Profile
{
    public ClientToDto()
    {
        CreateMap<Domain.Entities.Client, ClientDto>();
        CreateMap<ClientDto,ClientCommand>();
        CreateMap<ClientDto,UpdateClientCommand>();
    }
}