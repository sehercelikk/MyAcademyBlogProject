namespace Blogy.Business.DTOS.CommentDtos;

public class UpdateCommentDto
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public int BlogId { get; set; }
    public int UserId { get; set; }
}
