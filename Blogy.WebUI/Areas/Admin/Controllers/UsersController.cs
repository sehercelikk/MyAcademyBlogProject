using AutoMapper;
using Blogy.Business.DTOS.UserDtos;
using Blogy.Entities.Concrete;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area(Roles.Admin)]
[Authorize]

public class UsersController(UserManager<AppUser> _userManager, IMapper _mapper, RoleManager<AppRole> _roleManager) : Controller
{
    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        var mapUser = _mapper.Map<List<ResultUserDto>>(users);
        foreach (var user in users)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            mapUser.Find(a => a.Id == user.Id).Roles = userRoles;
        }

        return View(mapUser);
    }

    public async Task<IActionResult> AssignRole(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        ViewBag.FullName = user.FirstName + " " + user.LastName;
        var roles = await _roleManager.Roles.ToListAsync();
        var userRoles = await _userManager.GetRolesAsync(user);
        var assignRoleList = new List<AssignRoleDto>();

        foreach (var role in roles)
        {
            assignRoleList.Add(new AssignRoleDto
            {
                RoleId = role.Id,
                RoleName = role.Name,
                UserId = user.Id,
                RoleExists = userRoles.Contains(role.Name)
            });
        }
        return View(assignRoleList);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRole(List<AssignRoleDto> model)
    {
        var userId = model.Select(a => a.UserId).FirstOrDefault();
        var user = await _userManager.FindByIdAsync(userId.ToString());
        foreach (var role in model)
        {
            if (role.RoleExists)
            {
                await _userManager.AddToRoleAsync(user, role.RoleName);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
        }
        return RedirectToAction("Index");
    }
}
