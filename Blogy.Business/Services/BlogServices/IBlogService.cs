using Blogy.Business.DTOS.BlogDtos;
using Blogy.Business.Services.GenericService;
using Blogy.Entities.Concrete;

namespace Blogy.Business.Services.BlogServices;

public interface IBlogService : IGenericService<ResultBlogDto,UpdateBlogDto,CreateBlogDto>
{
    Task<List<ResultBlogDto>> GetBlogWithCategoryAsync();
    Task<List<ResultBlogDto>> GetBlogByCategoryIdAsync(int catId);
    Task<List<ResultBlogDto>> GetLast3BlogsAsync();
}
