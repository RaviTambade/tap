using System.Collections.Generic;
using ECommerceApp.Entities;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ECommerceApp.Controllers{

    [ApiController]
    [Route("api/[Controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _ordersvc;
           public OrdersController(IOrderService ordersvc)
           {
            _ordersvc = ordersvc;
           } 

           [HttpGet]
           [Route("/api/orders/Getallorders")]
           public IEnumerable<Order> GetAllOrders()
           {
            List<Order> orders = _ordersvc.GetAll();
            return orders;
           }

        [HttpGet]
        [Route("/api/orders/getorderdetails/{id}")]
        public Order GetById(int id)
        {
            Order order = _ordersvc.GetById(id);
            return order;
        }

        [HttpPost]
        [Route("/api/orders/insert")]
        public bool Insert([FromBody] Order order)
        {
            bool status = _ordersvc.Insert(order);
            return status;
        }

        [Authorize(Roles= Role.Admin)]
        [HttpPut]
        [Route("/api/orders/update/{id}")]
        public bool Update(int id,[FromBody] Order order)
        {
        Order oldOrder = _ordersvc.GetById(id);
        if(oldOrder.OrderId==0)
        {
            return false;
        }
            order.OrderId =id;
            bool status = _ordersvc.Update(order);
            return status;
        }

        [HttpDelete]
        [Route("/api/orders/delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _ordersvc.Delete(id);
            return status;
        }

    }
}
