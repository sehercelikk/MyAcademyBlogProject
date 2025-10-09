using Blogy.Business.DTOS.CategoryDtos;
using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
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
        if(!ModelState.IsValid)
        {
            return View(model);
        }
        await _categoryService.CreateCategoryAsync(model);
        return RedirectToAction(nameof(Index));
    }
}
