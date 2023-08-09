using AutoMapper;
using EzRent.Domain.Entities;
using EzRent.Service.Product.Command;
using EzRent.Shared;

namespace EzRent.Api.Mapper;

public class ProductToDto : Profile
{
    private readonly IMapper _mapper;

    public ProductToDto(IMapper mapper)
    {
        _mapper = mapper;
    }
    public ProductToDto()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto,ProductCommand>();
        CreateMap<ProductDto,UpdateProductCommand>();
        
        CreateMap<StockUpdateDto, Product>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Price, opt => opt.Ignore())
            .ForMember(dest => dest.ItemsPerBox, opt => opt.Ignore());
    }
}