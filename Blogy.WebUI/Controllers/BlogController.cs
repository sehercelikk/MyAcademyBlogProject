using Blogy.Business.DTOS.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Blogy.WebUI.Controllers;

public class BlogController(IBlogService _blogService, ICategoryService _categoryService) : Controller
{
    public async Task<IActionResult> Index(int page=1, int pageSize=2)
    {
        var blogs = await _blogService.GetAllAsync();
        var values = new PagedList<ResultBlogDto>(blogs.AsQueryable(), page, pageSize);
        return View(values);
    }
    public async Task<IActionResult> GetBlogsByCategory(int id)
    {
        var result= await _blogService.GetBlogByCategoryIdAsync(id);
        var category= await _categoryService.GetCategoryByIdAsync(id);
        ViewBag.CategoryName = category.Name;
        return View(result);
    }
}
