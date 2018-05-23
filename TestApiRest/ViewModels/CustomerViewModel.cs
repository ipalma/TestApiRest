using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiRest.ViewModels
{
    public class CustomerViewModel: IViewModel<Customer>
    {
        #region Properties
        public int CustomerID { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string CompanyName { get; set; }
        public string SalesPerson { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
        #endregion Properties

        #region IViewModel<Customer> Methods
        public void FromDataBase(Customer model)
        {
            CustomerID = model.CustomerID;
            NameStyle = model.NameStyle;
            Title = model.Title;
            FirstName = model.FirstName;
            MiddleName = model.MiddleName;
            LastName = model.LastName;
            Suffix = model.Suffix;
            CompanyName = model.CompanyName;
            SalesPerson = model.SalesPerson;
            EmailAddress = model.EmailAddress;
            Phone = model.Phone;
            PasswordHash = model.PasswordHash;
            PasswordSalt = model.PasswordSalt;
            rowguid = model.rowguid;
            ModifiedDate = model.ModifiedDate;

            try
            {
                CustomerAddress = model.CustomerAddress.Select(x => new CustomerAddress()
                {
                    CustomerID = x.CustomerID,
                    AddressID = x.AddressID,
                    AddressType = x.AddressType,
                    rowguid = x.rowguid,
                    ModifiedDate = x.ModifiedDate,
                    Address = new Address()
                    {
                        AddressID = x.Address.AddressID,
                        AddressLine1 = x.Address.AddressLine1,
                        AddressLine2 = x.Address.AddressLine2,
                        City = x.Address.City,
                        StateProvince = x.Address.StateProvince,
                        CountryRegion = x.Address.CountryRegion,
                        PostalCode = x.Address.PostalCode,
                        rowguid = x.Address.rowguid,
                        ModifiedDate = x.Address.ModifiedDate
                    }
                }).ToList();

                SalesOrderHeader = model.SalesOrderHeader.Select(x => new Models.SalesOrderHeader()
                {
                    SalesOrderID = x.SalesOrderID,
                    RevisionNumber = x.RevisionNumber,
                    OrderDate = x.OrderDate,
                    DueDate = x.DueDate,
                    ShipDate = x.ShipDate,
                    Status = x.Status,
                    OnlineOrderFlag = x.OnlineOrderFlag,
                    SalesOrderNumber = x.SalesOrderNumber,
                    PurchaseOrderNumber = x.PurchaseOrderNumber,
                    AccountNumber = x.AccountNumber,
                    CustomerID = x.CustomerID,
                    ShipToAddressID = x.ShipToAddressID,
                    BillToAddressID = x.BillToAddressID,
                    ShipMethod = x.ShipMethod,
                    CreditCardApprovalCode = x.CreditCardApprovalCode,
                    SubTotal = x.SubTotal,
                    TaxAmt = x.TaxAmt,
                    Freight = x.Freight,
                    TotalDue = x.TotalDue,
                    Comment = x.Comment,
                    rowguid = x.rowguid,
                    ModifiedDate = x.ModifiedDate
                }).ToList();
            }
            catch(Exception ex)
            {
                CustomerAddress = new HashSet<CustomerAddress>();
                SalesOrderHeader = new HashSet<SalesOrderHeader>();
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

        public Customer ToDataBase()
        {
            var data = new Customer()
            {
                CustomerID = CustomerID,
                NameStyle = NameStyle,
                Title = Title,
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Suffix = Suffix,
                CompanyName = CompanyName,
                SalesPerson = SalesPerson,
                EmailAddress = EmailAddress,
                Phone = Phone,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt,
                rowguid = rowguid,
                ModifiedDate = ModifiedDate
            };
            return data;
        }

        public void UpdateDataBase(Customer model)
        {
            model.CustomerID = CustomerID;
            model.NameStyle = NameStyle;
            model.Title = Title;
            model.FirstName = FirstName;
            model.MiddleName = MiddleName;
            model.LastName = LastName;
            model.Suffix = Suffix;
            model.CompanyName = CompanyName;
            model.SalesPerson = SalesPerson;
            model.EmailAddress = EmailAddress;
            model.Phone = Phone;
            model.PasswordHash = PasswordHash;
            model.PasswordSalt = PasswordSalt;
            model.rowguid = rowguid;
            model.ModifiedDate = ModifiedDate;
        }
        #endregion IViewModel<Customer> Methods

    }
}