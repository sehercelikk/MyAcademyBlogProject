using Blogy.Business.DTOS.CommentDtos;
using Blogy.Business.Services.GenericService;

namespace Blogy.Business.Services.CommentService;

public interface ICommentService : IGenericService<ResultCommentDto,UpdateCommentDto,CreateCommentDto>
{
}
