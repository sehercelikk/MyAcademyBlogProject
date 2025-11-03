using Blogy.Business.DTOS.UserDtos;
using Blogy.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Controllers;

public class LoginController(SignInManager<AppUser> _signInManager) : Controller
{
    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(LoginDto model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,false,false);
        if(!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty,"Kullanıcı Adı Veya Şifre Hatalı");
            return View(model);
        }
        return RedirectToAction("Index", "Blog",new {Area="Admin"});
    }
}
