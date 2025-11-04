using AutoMapper;
using Blogy.Business.DTOS.CommentDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CommentService;
using Blogy.Entities.Concrete;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area(Roles.Admin)]
[Authorize(Roles = Roles.Admin)]
public class CommentController(ICommentService _commentService,IBlogService _blogService,UserManager<AppUser> _userManager) : Controller
{
    private async Task GetBlogs()
    {
        var result= await _blogService.GetAllAsync();
        ViewBag.Blogs(from blog in result
                      select new SelectListItem
                      {
                          Text = blog.Title,
                          Value = blog.Id.ToString()
                      }).ToList();
    }

    public async Task<IActionResult> Index()
    {
        var comments = await _commentService.GetAllAsync();
        return View(comments);
    }

    public async Task<IActionResult> CreateComment()
    {
        await GetBlogs();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(CreateCommentDto model)
    {
        var user= await _userManager.FindByNameAsync(User.Identity.Name);
        model.UserId= user.Id;
        await _commentService.CreateAsync(model);
        return RedirectToAction(nameof(Index));
    }
}
