using AutoMapper;
using Blogy.Business.DTOS.UserDtos;
using Blogy.Entities.Concrete;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area(Roles.Admin)]
[Authorize(Roles=Roles.Admin)]
public class ProfileController(UserManager<AppUser> _userManager,IMapper _mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var editUser=_mapper.Map<EditProfileDto>(user);
        return View(editUser);
    }


}
