using AutoMapper;
using Blogy.Business.DTOS.CommentDtos;
using Blogy.Entities.Concrete;

namespace Blogy.Business.AutoMapper;

public class CommentMapping : Profile
{
    public CommentMapping()
    {
        CreateMap<ResultCommentDto,Comment>().ReverseMap();
        CreateMap<CreateCommentDto,Comment>().ReverseMap();
        CreateMap<UpdateCommentDto,Comment>().ReverseMap();
    }
}
