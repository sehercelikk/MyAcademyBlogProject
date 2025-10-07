using AutoMapper;
using Blogy.Business.DTOS.CategoryDtos;
using Blogy.DataAccess.Repositories.CategoryRepositories;
using Blogy.Entities.Concrete;

namespace Blogy.Business.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _category;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository category, IMapper mapper)
    {
        _category = category;
        _mapper = mapper;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var mapCategory = _mapper.Map<Category>(createCategoryDto);
        await _category.AddAsync(mapCategory);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _category.DeleteAsync(id);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        var categories = await _category.GetAllAsync();
        return _mapper.Map<List<ResultCategoryDto>>(categories);
    }

    public async Task<UpdateCategoryDto> GetCategoryByIdAsync(int id)
    {
        var category =await _category.GetByIdAsync(id);
        return _mapper.Map<UpdateCategoryDto>(category);
    }

    public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var mapCategory = _mapper.Map<Category>(updateCategoryDto);
        return _category.UpdateAsync(mapCategory);
    }
}
