using Blogy.Business.DTOS.CategoryDtos;

namespace Blogy.Business.Services.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    Task<UpdateCategoryDto> GetCategoryByIdAsync(int id);
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategoryAsync(int id);
}
