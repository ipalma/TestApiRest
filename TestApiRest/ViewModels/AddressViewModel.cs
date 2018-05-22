using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiRest.ViewModels
{
    public class AddressViewModel:IViewModel<Address>
    {
        #region Properties
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeader1 { get; set; }
        #endregion Properties

        #region IViewModel<Address> Methods
        public void FromDataBase(Address model)
        {
            AddressID = model.AddressID;
            AddressLine1 = model.AddressLine1;
            AddressLine2 = model.AddressLine2;
            City = model.City;
            StateProvince = model.StateProvince;
            CountryRegion = model.CountryRegion;
            PostalCode = model.PostalCode;
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
                    ModifiedDate = x.ModifiedDate


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
            return new[] { AddressID };
        }

        public Address ToDataBase()
        {
            var data = new Address()
            {
                AddressID = AddressID,
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                City = City,
                StateProvince = StateProvince,
                CountryRegion = CountryRegion,
                PostalCode = PostalCode,
                rowguid = rowguid,
                ModifiedDate = ModifiedDate
            };
            return data;
        }

        public void UpdateDataBase(Address model)
        {
            model.AddressID = AddressID;
            model.AddressLine1 = AddressLine1;
            model.AddressLine2 = AddressLine2;
            model.City = City;
            model.StateProvince = StateProvince;
            model.CountryRegion = CountryRegion;
            model.PostalCode = PostalCode;
            model.rowguid = rowguid;
            model.ModifiedDate = ModifiedDate;
        }
        #endregion IViewModel<Address> Methods
  
    }
}