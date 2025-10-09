using AutoMapper;
using Blogy.Business.DTOS.CategoryDtos;
using Blogy.Entities.Concrete;

namespace Blogy.Business.AutoMapper;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
    }
}
