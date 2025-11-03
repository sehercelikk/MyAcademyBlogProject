using Blogy.Business.DTOS.CategoryDtos;
using Blogy.Business.Services.CategoryServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area(Roles.Admin)]
[Authorize(Roles = Roles.Admin)]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _categoryService.GetAllCategoryAsync();
        return View(result);
    }

    public IActionResult CreateCategory() => View();

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        await _categoryService.CreateCategoryAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> UpdateCategory(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        await _categoryService.UpdateCategoryAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
