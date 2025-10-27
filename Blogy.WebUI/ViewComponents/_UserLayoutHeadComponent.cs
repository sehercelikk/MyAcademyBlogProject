using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents;

public class _UserLayoutHeadComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
