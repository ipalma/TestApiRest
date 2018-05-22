using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiRest.ViewModels
{
    public class SalesOrderHeaderViewModel : IViewModel<SalesOrderHeader>
    {
        #region Properties
        public int SalesOrderID { get; set; }
        public byte RevisionNumber { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime DueDate { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public byte Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerID { get; set; }
        public Nullable<int> ShipToAddressID { get; set; }
        public Nullable<int> BillToAddressID { get; set; }
        public string ShipMethod { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Address Address { get; set; }
        public virtual Address Address1 { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
        #endregion Properties

        #region IViewModel<SalesOrderHeader> Methods
        public void FromDataBase(SalesOrderHeader model)
        {
            SalesOrderID = model.SalesOrderID;
            RevisionNumber = model.RevisionNumber;
            OrderDate = model.OrderDate;
            DueDate = model.DueDate;
            ShipDate = model.ShipDate;
            Status = model.Status;
            OnlineOrderFlag = model.OnlineOrderFlag;
            SalesOrderNumber = model.SalesOrderNumber;
            PurchaseOrderNumber = model.PurchaseOrderNumber;
            AccountNumber = model.AccountNumber;
            CustomerID = model.CustomerID;
            ShipToAddressID = model.ShipToAddressID;
            BillToAddressID = model.BillToAddressID;
            ShipMethod = model.ShipMethod;
            CreditCardApprovalCode = model.CreditCardApprovalCode;
            SubTotal = model.SubTotal;
            TaxAmt = model.TaxAmt;
            Freight = model.Freight;
            TotalDue = model.TotalDue;
            Comment = model.Comment;
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
                Address1 = new Address()
                {
                    AddressID = model.Address1.AddressID,
                    AddressLine1 = model.Address1.AddressLine1,
                    AddressLine2 = model.Address1.AddressLine2,
                    City = model.Address1.City,
                    StateProvince = model.Address1.StateProvince,
                    CountryRegion = model.Address1.CountryRegion,
                    PostalCode = model.Address1.PostalCode,
                    rowguid = model.Address1.rowguid,
                    ModifiedDate = model.Address1.ModifiedDate
                };
                Customer = new Customer() { };
                SalesOrderDetail = model.SalesOrderDetail.Select(x => new SalesOrderDetail()
                {
                    SalesOrderID = x.SalesOrderID,
                    SalesOrderDetailID = x.SalesOrderDetailID,
                    OrderQty = x.OrderQty,
                    ProductID = x.ProductID,
                    UnitPrice = x.UnitPrice,
                    UnitPriceDiscount = x.UnitPriceDiscount,
                    LineTotal = x.LineTotal,
                    rowguid = x.rowguid,
                    ModifiedDate = x.ModifiedDate
                }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Guid[] GetGuids()
        {
           return new[] { rowguid };
        }

        public int[] GetKeys()
        {
            return new[] { SalesOrderID };
        }

        public SalesOrderHeader ToDataBase()
        {
            var data = new SalesOrderHeader()
            {
                SalesOrderID = SalesOrderID,
                RevisionNumber = RevisionNumber,
                OrderDate = OrderDate,
                DueDate = DueDate,
                ShipDate = ShipDate,
                Status = Status,
                OnlineOrderFlag = OnlineOrderFlag,
                SalesOrderNumber = SalesOrderNumber,
                PurchaseOrderNumber = PurchaseOrderNumber,
                AccountNumber = AccountNumber,
                CustomerID = CustomerID,
                ShipToAddressID = ShipToAddressID,
                BillToAddressID = BillToAddressID,
                ShipMethod = ShipMethod,
                CreditCardApprovalCode = CreditCardApprovalCode,
                SubTotal = SubTotal,
                TaxAmt = TaxAmt,
                Freight = Freight,
                TotalDue = TotalDue,
                Comment = Comment,
                rowguid = rowguid,
                ModifiedDate = ModifiedDate
            };
            return data;
        }

        public void UpdateDataBase(SalesOrderHeader model)
        {
            model.SalesOrderID = SalesOrderID;
            model.RevisionNumber = RevisionNumber;
            model.OrderDate = OrderDate;
            model.DueDate = DueDate;
            model.ShipDate = ShipDate;
            model.Status = Status;
            model.OnlineOrderFlag = OnlineOrderFlag;
            model.SalesOrderNumber = SalesOrderNumber;
            model.PurchaseOrderNumber = PurchaseOrderNumber;
            model.AccountNumber = AccountNumber;
            model.CustomerID = CustomerID;
            model.ShipToAddressID = ShipToAddressID;
            model.BillToAddressID = BillToAddressID;
            model.ShipMethod = ShipMethod;
            model.CreditCardApprovalCode = CreditCardApprovalCode;
            model.SubTotal = SubTotal;
            model.TaxAmt = TaxAmt;
            model.Freight = Freight;
            model.TotalDue = TotalDue;
            model.Comment = Comment;
            model.rowguid = rowguid;
            model.ModifiedDate = ModifiedDate;
        }
        #endregion IViewModel<SalesOrderHeader> Methods

    }
}