using Blogy.Business.DTOS.BlogDtos;

namespace Blogy.Business.DTOS.CategoryDtos;

public class ResultCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ResultBlogDto> Blogs { get; set; }
}
