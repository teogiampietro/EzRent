using AutoMapper;
using EzRent.Domain.Entities;
using EzRent.Service.Property.Command;
using EzRent.Shared;

namespace EzRent.Api.Mapper;

public class PropertyToDto : Profile
{
    public PropertyToDto()
    {
        CreateMap<Property, PropertyDto>();
        CreateMap<PropertyDto,PropertyCommand>();
    }
}