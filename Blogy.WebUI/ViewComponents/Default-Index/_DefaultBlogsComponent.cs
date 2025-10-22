using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.ViewComponents.Default_Index;

public class _DefaultBlogsComponent : ViewComponent
{
    private readonly ICategoryService _cateegoryService;

    public _DefaultBlogsComponent(ICategoryService cateegoryService)
    {
        _cateegoryService = cateegoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _cateegoryService.GetCategoryWithBlogsAsync();
        return View(result);
    }
}
