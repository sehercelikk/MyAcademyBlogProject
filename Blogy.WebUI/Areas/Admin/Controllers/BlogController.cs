using Blogy.Business.DTOS.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class BlogController : Controller
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _blogService.GetBlogWithCategoryAsync();
        return View(result);
    }

    public IActionResult CreateBlog()=>View();

    [HttpPost]
    public IActionResult CreateBlog(CreateBlogDto model)
    {
        return View();
    }

    public IActionResult UpdateBlog(int id)
    {
        return View();
    }

    public IActionResult DeleteBlog(int id)
    {
        return View();
    }
}
