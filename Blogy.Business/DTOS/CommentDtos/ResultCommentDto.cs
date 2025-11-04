using Blogy.Business.DTOS.BlogDtos;
using Blogy.Business.DTOS.UserDtos;
using Blogy.Entities.Concrete;

namespace Blogy.Business.DTOS.CommentDtos;

public class ResultCommentDto
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public int BlogId { get; set; }
    public ResultBlogDto Blog { get; set; }
    public int UserId { get; set; }
    public ResultUserDto User { get; set; }
}
