using System.Diagnostics;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace ECommerceApp.Controllers;
public class AccountsController : Controller
{
    private readonly IAccountService _accountserv;
    public AccountsController(IAccountService accountserv){
     _accountserv = accountserv;
    }
    [HttpGet]
    public JsonResult GetAllAccounts()
    {
        var accounts=_accountserv.GetAllAccounts();
        return Json(accounts);
    }
    [HttpGet]
    public JsonResult GetAccountById(int id)
    {
        var account=_accountserv.GetAccountById(id);
        return Json(account);
    }
[HttpGet]
    public IActionResult Index()
    {
        return View();
    }
     [HttpPost]
    public JsonResult InsertAccount([FromBody] Account account)
    {
        bool status=_accountserv.InsertAccount(account);
        return Json(status);
    }

      [HttpPut]
    public JsonResult UpdateAccount([FromBody] Account account)
    {
        Console.WriteLine(account.AccountNumber);
        bool status=_accountserv.UpdateAccount(account);
        return Json(status);
}
   [HttpDelete]
    public JsonResult DeleteAccount(Int32 id)
    {
        bool status=_accountserv.DeleteAccount(id);
        return Json(status);
}
}