using AutoMapper;
using EzRent.Domain.Entities;
using EzRent.Service.Product.Command;
using EzRent.Shared;

namespace EzRent.Api.Mapper;

public class ProductToDto : Profile
{
    public ProductToDto()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto,ProductCommand>();
        CreateMap<ProductDto,UpdateProductCommand>();
    }
}