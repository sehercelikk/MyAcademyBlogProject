using AutoMapper;
using Blogy.Business.DTOS.UserDtos;
using Blogy.Entities.Concrete;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area(Roles.Admin)]
public class UsersController(UserManager<AppUser> _userManager, IMapper _mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        var mapUser = _mapper.Map<List<ResultUserDto>>(users);
        foreach (var user in users)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var roles in mapUser)
            {
                roles.Roles = userRoles;
            }
        }

        return View(mapUser);
    }
}
