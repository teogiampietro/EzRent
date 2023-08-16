using AutoMapper;
using EzRent.Domain.Entities;
using EzRent.Service.Category.Command;
using EzRent.Shared;

namespace EzRent.Api.Mapper;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, CategoryCommand>();
        CreateMap<CategoryDto, UpdateCategoryCommand>();
    }
}