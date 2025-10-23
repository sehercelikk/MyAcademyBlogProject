﻿using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Controllers;

public class BlogController(IBlogService _blogService, ICategoryService _categoryService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> GetBlogsByCategory(int id)
    {
        var result= await _blogService.GetBlogByCategoryIdAsync(id);
        var category= await _categoryService.GetCategoryByIdAsync(id);
        ViewBag.CategoryName = category.Name;
        return View(result);
    }
}
