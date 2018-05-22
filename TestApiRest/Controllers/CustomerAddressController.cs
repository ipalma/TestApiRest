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
    public class CustomerAddressController : ApiController
    {
        private readonly IRepository<CustomerAddress, CustomerAddressViewModel> _customerAddress;

        public CustomerAddressController(IRepository<CustomerAddress, CustomerAddressViewModel> customerAddress)
        {
            _customerAddress = customerAddress;
        }

        public ICollection<CustomerAddressViewModel> GetCustomerAddresses()
        {
            return _customerAddress.Get();
        }

        [HttpGet]
        public CustomerAddressViewModel GetCustomerAddress(int id)
        {
            return _customerAddress.Get(id);
        }
    }
}
