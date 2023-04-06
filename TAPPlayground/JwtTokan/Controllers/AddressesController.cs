using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase

    {
        private readonly IAddressService _addresssrv;
        public AddressesController(IAddressService addresssrv)
        {
            _addresssrv = addresssrv;
        }

        [HttpGet]
        [Route("/api/address/GetAlladdresses")]
        public IEnumerable<Address> GetAllAddress()
        {
            List<Address> addresses = _addresssrv.GetAll();
            return addresses;
        }

        [HttpGet]
        [Route("/api/address/Getaddress/{id}")]
        public Address GetById(int id)
        {
            Address address = _addresssrv.GetById(id);
            return address;
        }

        [Authorize(Roles = Role.Employee)]
        [HttpPut]
        [Route("/api/address/update/{id}")]
        public bool Update( int id,[FromBody] Address address)
        {
            Address oldAddress = _addresssrv.GetById(id);
            if(oldAddress.AddressId==0){
                return false;
            }
            address.AddressId=id;
            bool status = _addresssrv.Update(address);
            return status;
        }

        [Authorize(Roles = Role.Employee)]
        [HttpPost]
        [Route("/api/adress/InsertAddress/")]
        public bool Insert([FromBody] Address address)
        {
            bool status = _addresssrv.Insert(address);
            return status;
        }

        [Authorize(Roles = Role.Employee)]
        [HttpDelete]
        [Route("/api/address/delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _addresssrv.Delete(id);
            return status;
        }
    }
}