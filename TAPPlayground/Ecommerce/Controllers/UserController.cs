using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class UserController : Controller
{
    private readonly IUserService _usersrv;

    public UserController(IUserService usersrv)
    {
        _usersrv = usersrv;
    }

    public IActionResult UserMockUpScreen()
    {
        return View();
    }


    public JsonResult ShowAllUser()
    {
        var details = _usersrv.GetAllUser();
        return Json(details);
    }
}