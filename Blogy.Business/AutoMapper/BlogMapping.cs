using AutoMapper;
using Blogy.Business.DTOS.BlogDtos;
using Blogy.Entities.Concrete;

namespace Blogy.Business.AutoMapper;

public class BlogMapping : Profile
{
    public BlogMapping()
    {
        CreateMap<Blog, ResultBlogDto>().ReverseMap();
        CreateMap<Blog, UpdateBlogDto>().ReverseMap();
        CreateMap<Blog, CreateBlogDto>().ReverseMap();
    }
}
