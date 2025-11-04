using AutoMapper;
using Blogy.Business.DTOS.UserDtos;
using Blogy.Entities.Concrete;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


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

    [HttpPost]
    public async Task<IActionResult> Index(EditProfileDto model)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var passwordCorrect = await _userManager.CheckPasswordAsync(user,model.CurrentPassword);
        if (!passwordCorrect)
        {
            ModelState.AddModelError("","Şifre hatalı");
            return View(model);
        }
        if(model.ImageFile != null)
        {
            var currentDirectory = Directory.GetCurrentDirectory(); //Projenin olduğu Dizin
            var extension = Path.GetExtension(model.ImageFile.FileName); // Dosyanın uzantısı
            var imageName = Guid.NewGuid()+extension; // Resim Dosyasının ismi
            var saveLocation = Path.Combine(currentDirectory, "wwwroot/images",imageName); // Kayıt lokasyonu
            using var stream = new FileStream(saveLocation, FileMode.Create); // Akış oluşturuldu. işlem bitince kendi kapatsın diye using kullandık.
            await model.ImageFile.CopyToAsync(stream); // kopyala ve akış üzerine kaydet
            user.ImageUrl = "/images/" + imageName; // Url bilgisi atandı
        }
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;
        user.PhoneNumber = model.PhoneNumber;
        user.UserName = model.UserName;
        user.Title=model.Title;

        var result = await _userManager.UpdateAsync(user);
        if(!result.Succeeded)
        {
            ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştur.");
            return View(model);
        }
        return RedirectToAction("Index", "Blog", new {area=Roles.Admin});
    }

}
