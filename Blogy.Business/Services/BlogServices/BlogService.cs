using AutoMapper;
using Blogy.Business.DTOS.BlogDtos;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.Entities.Concrete;

namespace Blogy.Business.Services.BlogServices;

public class BlogService(IBlogRepository _blog,IMapper _mapper) : IBlogService
{
    public async Task CreateAsync(CreateBlogDto createDto)
    {
        var result = _mapper.Map<Blog>(createDto);
        await _blog.AddAsync(result);
    }

    public async Task DeleteAsync(int id)
    {
        await _blog.DeleteAsync(id);
    }

    public async Task<ResultBlogDto> GetSingleIdAsync(int id)
    {
        var findEntity= await _blog.GetByIdAsync(id);
        return _mapper.Map<ResultBlogDto>(findEntity);
    }

    public async Task<List<ResultBlogDto>> GetAllAsync()
    {
        var result= await _blog.GetAllAsync();
        return _mapper.Map<List<ResultBlogDto>>(result);
    }

    public async Task<List<ResultBlogDto>> GetBlogByCategoryIdAsync(int catId)
    {
        var result = await _blog.GetAllAsync(a => a.CategoryId == catId);
        return _mapper.Map<List<ResultBlogDto>>(result);
    }

    public async Task<List<ResultBlogDto>> GetBlogWithCategoryAsync()
    {
        var result=await _blog.GetBlogWithCategoryAsync();
        return _mapper.Map<List<ResultBlogDto>>(result);
    }

    public async Task<UpdateBlogDto> GetByIdAsync(int id)
    {
        var result= await _blog.GetByIdAsync(id);
        return _mapper.Map<UpdateBlogDto>(result);

    }

    public async Task<List<ResultBlogDto>> GetLast3BlogsAsync()
    {
        var result= await _blog.GetLast3BlogsAsync();
        return _mapper.Map<List<ResultBlogDto>>(result);
    }

    public async Task UpdateAsync(UpdateBlogDto updateDto)
    {
       await _blog.UpdateAsync(_mapper.Map<Blog>(updateDto));
    }
}
