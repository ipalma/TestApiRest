using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApiRest.ViewModels;

namespace TestApiRest.Controllers
{
    public class AddressController : ApiController
    {
        private readonly IRepository<Address, AddressViewModel> _address;
        private readonly IRepository<CustomerAddress, CustomerAddressViewModel> _customerAddress;

        public AddressController(IRepository<Address,AddressViewModel> address, IRepository<CustomerAddress, CustomerAddressViewModel> customerAddress)
        {
            _address = address;
            _customerAddress = customerAddress;
        }

        public ICollection<AddressViewModel> GetAddresses()
        {
            return _address.Get();
        }

        [HttpGet]
        public AddressViewModel GetAddress(int id)
        {
            return _address.Get(id);
        }

        [HttpGet]
        public ICollection<AddressViewModel> GetAddressByStreet(string street)
        {
            return _address.Get(x => x.AddressLine1.Contains(street));
        }

        [HttpGet]
        public ICollection<AddressViewModel> GetAddressByCity(string city)
        {
            return _address.Get(x => x.City.Contains(city));
        }

        [HttpGet]
        public ICollection<AddressViewModel> GetAddressByCustomerId(int id)
        {
            var customerAddress = _customerAddress.Get(x => x.CustomerID == id);
            List<AddressViewModel> ListAddresses = new List<AddressViewModel>();

            foreach (var item in customerAddress)
            {
                ListAddresses.AddRange(_address.Get(x => x.AddressID == item.AddressID));
            }
            return ListAddresses;
        }

        [HttpPost]
        public AddressViewModel CreateAddress(AddressViewModel address)
        {
            return _address.Add(address);
        }

        [HttpPost]
        public int UpdateAddress(AddressViewModel address)
        {
            return _address.Update(address);
        }

        [HttpGet]
        public int DeleteAddress(int id)
        {
            return _address.Delete(x => x.AddressID == id);
        }

    }
}
