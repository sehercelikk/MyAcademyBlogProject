﻿using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers;

public class UILayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
