using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Controllers;

public class ShipperController : Controller
{
    private readonly IShipperService _shippersrv;

    public ShipperController(IShipperService shippersrv)
    {
        _shippersrv = shippersrv;
    }

   public IActionResult Home()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    public JsonResult GetAllShippers()
    {
        var shippers=_shippersrv.GetAllShippers();
        return Json(shippers);
    }



    [HttpGet]
    public JsonResult getShipperById (int id)
    {
        var shipper=_shippersrv.GetShipperById(id);
        return Json(shipper);
    }


  [HttpPost]

      [Route("shipper/insertshipper")]  
        public JsonResult InsertShipper([FromBody] Shipper shipper){
             Console.WriteLine(shipper.Email);
             Console.WriteLine(shipper.AccountNumber);
             bool status=_shippersrv.InsertShipper(shipper);
             return Json(status);
         
    }


    [HttpPut]
    public JsonResult UpdateShipper([FromBody]Shipper shipper)
    {
        System.Console.WriteLine(shipper);
        bool status=_shippersrv.UpdateShipper(shipper);
        return Json(status);  
         Console.WriteLine(shipper);


    }

   [HttpDelete]
    public JsonResult DeleteShipper(int id)
    {
        bool status=_shippersrv.DeleteShipper(id);
        return Json(status);
    }


    
 public IActionResult Search()
    {
        return View();
    }

public IActionResult Details()
    {
        return View();
    }

  
public IActionResult DeliveryList()
    {
        return View();
    }  

public IActionResult CancelList()
    {
        return View();
    } 

 public IActionResult ReturnList()
    {
        return View();
    }  
    
 public IActionResult ShippersList()
    {
        return View();
    }  

 public IActionResult Status()
    {
        return View();
    }      






    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

 
}