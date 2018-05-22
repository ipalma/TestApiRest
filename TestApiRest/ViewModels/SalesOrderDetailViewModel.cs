using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiRest.ViewModels
{
    public class SalesOrderDetailViewModel : IViewModel<SalesOrderDetail>
    {
        #region Properties
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual SalesOrderHeader SalesOrderHeader { get; set; }
        #endregion Properties

        #region IViewModel<SalesOrderDetail> Methods
        public void FromDataBase(SalesOrderDetail model)
        {
            SalesOrderID = model.SalesOrderID;
            SalesOrderDetailID = model.SalesOrderDetailID;
            OrderQty = model.OrderQty;
            ProductID = model.ProductID;
            UnitPrice = model.UnitPrice;
            UnitPriceDiscount = model.UnitPriceDiscount;
            LineTotal = model.LineTotal;
            rowguid = model.rowguid;
            ModifiedDate = model.ModifiedDate;
            try
            {
                Product = new Product()
                {
                    ProductID = model.Product.ProductID,
                    Name = model.Product.Name,
                    ProductNumber = model.Product.ProductNumber,
                    Color = model.Product.Color,
                    StandardCost = model.Product.StandardCost,
                    ListPrice = model.Product.ListPrice,
                    Size = model.Product.Size,
                    Weight = model.Product.Weight,
                    ProductCategoryID = model.Product.ProductCategoryID,
                    ProductModelID = model.Product.ProductModelID,
                    SellStartDate = model.Product.SellStartDate,
                    SellEndDate = model.Product.SellEndDate,
                    DiscontinuedDate = model.Product.DiscontinuedDate,
                    ThumbNailPhoto = model.Product.ThumbNailPhoto,
                    ThumbnailPhotoFileName = model.Product.ThumbnailPhotoFileName,
                    rowguid = model.Product.rowguid,
                    ModifiedDate = model.Product.ModifiedDate
                };
                SalesOrderHeader = new SalesOrderHeader()
                {
                    SalesOrderID = model.SalesOrderHeader.SalesOrderID,
                    RevisionNumber = model.SalesOrderHeader.RevisionNumber,
                    OrderDate = model.SalesOrderHeader.OrderDate,
                    DueDate = model.SalesOrderHeader.DueDate,
                    ShipDate = model.SalesOrderHeader.ShipDate,
                    Status = model.SalesOrderHeader.Status,
                    OnlineOrderFlag = model.SalesOrderHeader.OnlineOrderFlag,
                    SalesOrderNumber = model.SalesOrderHeader.SalesOrderNumber,
                    PurchaseOrderNumber = model.SalesOrderHeader.PurchaseOrderNumber,
                    AccountNumber = model.SalesOrderHeader.AccountNumber,
                    CustomerID = model.SalesOrderHeader.CustomerID,
                    ShipToAddressID = model.SalesOrderHeader.ShipToAddressID,
                    BillToAddressID = model.SalesOrderHeader.BillToAddressID,
                    ShipMethod = model.SalesOrderHeader.ShipMethod,
                    CreditCardApprovalCode = model.SalesOrderHeader.CreditCardApprovalCode,
                    SubTotal = model.SalesOrderHeader.SubTotal,
                    TaxAmt = model.SalesOrderHeader.TaxAmt,
                    Freight = model.SalesOrderHeader.Freight,
                    TotalDue = model.SalesOrderHeader.TotalDue,
                    Comment = model.SalesOrderHeader.Comment,
                    rowguid = model.SalesOrderHeader.rowguid,
                    ModifiedDate = model.SalesOrderHeader.ModifiedDate
                };
            }
            catch (Exception ex)
            {

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

        public SalesOrderDetail ToDataBase()
        {
            var data = new SalesOrderDetail()
            {
                SalesOrderID = SalesOrderID,
                SalesOrderDetailID = SalesOrderDetailID,
                OrderQty = OrderQty,
                ProductID = ProductID,
                UnitPrice = UnitPrice,
                UnitPriceDiscount = UnitPriceDiscount,
                LineTotal = LineTotal,
                rowguid = rowguid,
                ModifiedDate = ModifiedDate
            };
            return data;
        }

        public void UpdateDataBase(SalesOrderDetail model)
        {
            model.SalesOrderID = SalesOrderID;
            model.SalesOrderDetailID = SalesOrderDetailID;
            model.OrderQty = OrderQty;
            model.ProductID = ProductID;
            model.UnitPrice = UnitPrice;
            model.UnitPriceDiscount = UnitPriceDiscount;
            model.LineTotal = LineTotal;
            model.rowguid = rowguid;
            model.ModifiedDate = ModifiedDate;
        }
        #endregion IViewModel<SalesOrderDetail> Methods

    }
}