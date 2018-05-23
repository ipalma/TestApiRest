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

    public class CustomerController : ApiController
    {
        IRepository<Customer, CustomerViewModel> _customer;

        public CustomerController(IRepository<Customer, CustomerViewModel> customer)
        {
            _customer = customer;
        }

        public ICollection<CustomerViewModel> GetCustomers()
        {
            return _customer.Get();
        }

        [HttpGet]
        public CustomerViewModel GetCustomer(int? id)
        {
            return _customer.Get(id);
        }

    }
}
