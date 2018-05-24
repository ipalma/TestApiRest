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
        IRepository<CustomerAddress, CustomerAddressViewModel> _customerAddress;
        IRepository<Address, AddressViewModel> _address;

        public CustomerController(IRepository<Customer, CustomerViewModel> customer
            , IRepository<CustomerAddress, CustomerAddressViewModel> customerAddress
            , IRepository<Address, AddressViewModel> address)
        {
            _customer = customer;
            _customerAddress = customerAddress;
            _address = address;
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

        [HttpGet]
        public ICollection<CustomerViewModel> GetCustomerByFirstName(string FirstName)
        {
            return _customer.Get(x => x.FirstName.Contains(FirstName));
        }

        [HttpGet]
        public ICollection<CustomerViewModel> GetCustomerByLastName(string LastName)
        {
            return _customer.Get(x => x.LastName.Contains(LastName));
        }

        [HttpGet]
        public ICollection<CustomerViewModel> GetCustomerByCompanyName(string CompanyName)
        {
            return _customer.Get(x => x.CompanyName.Contains(CompanyName));
        }

        [HttpGet]
        public ICollection<CustomerViewModel> GetCustomerByEmailAddress(string EmailAddress)
        {
            return _customer.Get(x => x.EmailAddress.Contains(EmailAddress));
        }

        [HttpGet]
        public ICollection<CustomerViewModel> GetCustomerByFilter(string FirstName, string LastName, string CompanyName, string EmailAddress)
        {
            List<CustomerViewModel> customers = new List<CustomerViewModel>();

            customers.AddRange(_customer.Get(x => x.FirstName.Contains(FirstName ?? string.Empty) 
                && x.LastName.Contains(LastName??string.Empty) 
                && x.CompanyName.Contains(CompanyName ??string.Empty) 
                && x.EmailAddress.Contains(EmailAddress??string.Empty)));
            return customers;
        }

        [HttpGet]
        public ICollection<CustomerViewModel> GetCustomerByAddress(string Street)
        {
            var address = _address.Get(x => x.AddressLine1.Contains(Street));
            List<CustomerAddressViewModel> customerAddress = new List<CustomerAddressViewModel>();
            List<CustomerViewModel> customerList = new List<CustomerViewModel>();
            foreach (var addressItem in address)
            {
                customerAddress.AddRange(_customerAddress.Get(x => x.AddressID == addressItem.AddressID));
            }
            foreach (var customerAddressItem in customerAddress)
            {
                customerList.AddRange(_customer.Get(x => x.CustomerID == customerAddressItem.CustomerID));
            }
            return customerList;
        }

        [HttpPost]
        public CustomerViewModel CreateCustomer(CustomerViewModel customer)
        {
            try
            {
                return _customer.Add(customer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public int UpdateCustomer(CustomerViewModel customer)
        {
            try
            {
                return _customer.Update(customer);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
