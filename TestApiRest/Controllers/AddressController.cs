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

        public AddressController(IRepository<Address,AddressViewModel> address)
        {
            _address = address;
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

    }
}
