using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class TransactionController : Controller
{
    private readonly ITransactionService _transactionsrv;

    public TransactionController(ITransactionService transactionsrv)
    {
        _transactionsrv = transactionsrv;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Search()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
    public IActionResult Update()
    {
        return View();
    }
    public IActionResult GetAll()
    {
        return View();
    }
        public IActionResult GetById()
    {
        return View();
    }
    
    [HttpGet]
    public JsonResult ShowAllTransactions()
    {
        var transactions=_transactionsrv.GetAllTransaction();
        return Json(transactions);
    }

    [HttpGet]
    public JsonResult GetTransactionById(int id){
        var transaction=_transactionsrv.GetTransactionById(id);
        return Json(transaction);
    }
    
    [HttpPost]
    [Route("transactions/inserttransaction")]
     public JsonResult InsertTransaction([FromBody] Transaction transaction)
     {
        Console.WriteLine(transaction);
        bool status=_transactionsrv.InsertTransaction(transaction);
        return Json(status);
    }

    [HttpPut]
    public JsonResult UpdateTransaction([FromBody] Transaction transaction)
    {
        Console.WriteLine(transaction);
        bool result = _transactionsrv.UpdateTransaction(transaction);
        return Json(result);
    }

    [HttpDelete]
    public JsonResult DeleteTransaction(int id)
    {
        Console.WriteLine(id);
        bool supplier = _transactionsrv.DeleteTransaction(id);
        return Json(supplier);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}