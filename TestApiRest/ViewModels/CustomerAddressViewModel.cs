using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiRest.ViewModels
{
    public class CustomerAddressViewModel : IViewModel<CustomerAddress>
    {
        #region Properties
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        public string AddressType { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        #endregion Properties

        #region IViewModel<CustomerAddress> Methods
        public void FromDataBase(CustomerAddress model)
        {
            CustomerID = model.CustomerID;
            AddressID = model.AddressID;
            AddressType = model.AddressType;
            rowguid = model.rowguid;
            ModifiedDate = model.ModifiedDate;
            try
            {
                Address = new Address()
                {
                    AddressID = model.Address.AddressID,
                    AddressLine1 = model.Address.AddressLine1,
                    AddressLine2 = model.Address.AddressLine2,
                    City = model.Address.City,
                    StateProvince = model.Address.StateProvince,
                    CountryRegion = model.Address.CountryRegion,
                    PostalCode = model.Address.PostalCode,
                    rowguid = model.Address.rowguid,
                    ModifiedDate = model.Address.ModifiedDate
                };

                Customer = new Customer()
                {
                    CustomerID = model.Customer.CustomerID,
                    NameStyle = model.Customer.NameStyle,
                    Title = model.Customer.Title,
                    FirstName = model.Customer.FirstName,
                    MiddleName = model.Customer.MiddleName,
                    LastName = model.Customer.LastName,
                    Suffix = model.Customer.Suffix,
                    CompanyName = model.Customer.CompanyName,
                    SalesPerson = model.Customer.SalesPerson,
                    EmailAddress = model.Customer.EmailAddress,
                    Phone = model.Customer.Phone,
                    PasswordHash = model.Customer.PasswordHash,
                    PasswordSalt = model.Customer.PasswordSalt,
                    rowguid = model.Customer.rowguid,
                    ModifiedDate = model.Customer.ModifiedDate
                }; 
            }
            catch(Exception ex)
            {
                Address = new Address();
                Customer = new Customer();
            }


        }

        public Guid[] GetGuids()
        {
            return new[] { rowguid };
        }

        public int[] GetKeys()
        {
            return new[] { CustomerID };
        }

        public CustomerAddress ToDataBase()
        {
            var data = new CustomerAddress()
            {
                CustomerID = CustomerID,
                AddressID = AddressID,
                AddressType = AddressType,
                rowguid = rowguid,
                ModifiedDate = ModifiedDate
            };
            return data;
        }

        public void UpdateDataBase(CustomerAddress model)
        {
            model.CustomerID = CustomerID;
            model.AddressID = AddressID;
            model.AddressType = AddressType;
            model.rowguid = rowguid;
            model.ModifiedDate = ModifiedDate;
        }
        #endregion IViewModel<CustomerAddress> Methods

    }
}