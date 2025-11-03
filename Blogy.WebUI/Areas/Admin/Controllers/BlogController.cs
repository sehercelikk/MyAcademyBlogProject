using Blogy.Business.DTOS.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area(Roles.Admin)]
[Authorize(Roles=Roles.Admin)]
public class BlogController : Controller
{
    private readonly IBlogService _blogService;
    private readonly ICategoryService _categoryService;
    public BlogController(IBlogService blogService, ICategoryService categoryService)
    {
        _blogService = blogService;
        _categoryService = categoryService;
    }

    private async Task GetCategories()
    {
        var categories =await _categoryService.GetAllCategoryAsync();
        ViewBag.Categories = (from category in categories
                              select new SelectListItem
                              {
                                  Text = category.Name,
                                  Value = category.Id.ToString()
                              }).ToList();
    }

    public async Task<IActionResult> Index()
    {
        var result = await _blogService.GetBlogWithCategoryAsync();
        return View(result);
    }

    public async Task<IActionResult> CreateBlog()
    {
        await GetCategories();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogDto model)
    {
        if(!ModelState.IsValid)
        {
            await GetCategories();
            return View(model);
        }
        await _blogService.CreateAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> UpdateBlog(int id)
    {
        await GetCategories();
        var blog = await _blogService.GetByIdAsync(id);
        return View(blog);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBlog(UpdateBlogDto model)
    {
        if(!ModelState.IsValid)
        {
            await GetCategories();
            return View(model);
        }
        await _blogService.UpdateAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteBlog(int id)
    {
        await _blogService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
