using Blogy.Business.DTOS.CategoryDtos;
using Blogy.Entities.Concrete;

namespace Blogy.Business.DTOS.BlogDtos;

public class ResultBlogDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? CoverImage { get; set; }
    public string? BlogImage1 { get; set; }
    public string? BlogImage2 { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CategoryId { get; set; }
    public ResultCategoryDto Category { get; set; }
}
