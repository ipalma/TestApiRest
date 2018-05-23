using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiRest.ViewModels
{
    public class ProductViewModel : IViewModel<Product>
    {
        #region Properties
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<int> ProductCategoryID { get; set; }
        public Nullable<int> ProductModelID { get; set; }
        public System.DateTime SellStartDate { get; set; }
        public Nullable<System.DateTime> SellEndDate { get; set; }
        public Nullable<System.DateTime> DiscontinuedDate { get; set; }
        public byte[] ThumbNailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
        #endregion Properties

        #region IViewModel<Product> Methods
        public void FromDataBase(Product model)
        {
            ProductID = model.ProductID;
            Name = model.Name;
            ProductNumber = model.ProductNumber;
            Color = model.Color;
            StandardCost = model.StandardCost;
            ListPrice = model.ListPrice;
            Size = model.Size;
            Weight = model.Weight;
            ProductCategoryID = model.ProductCategoryID;
            ProductModelID = model.ProductModelID;
            SellStartDate = model.SellStartDate;
            SellEndDate = model.SellEndDate;
            DiscontinuedDate = model.DiscontinuedDate;
            ThumbNailPhoto = model.ThumbNailPhoto;
            ThumbnailPhotoFileName = model.ThumbnailPhotoFileName;
            rowguid = model.rowguid;
            ModifiedDate = model.ModifiedDate;
            try
            {
                ProductCategory = new ProductCategory()
                {
                    ProductCategoryID = model.ProductCategory.ProductCategoryID,
                    ParentProductCategoryID = model.ProductCategory.ParentProductCategoryID,
                    Name = model.ProductCategory.Name,
                    rowguid = model.ProductCategory.rowguid,
                    ModifiedDate = model.ProductCategory.ModifiedDate
                    
                };
                ProductModel = new ProductModel()
                {
                    ProductModelID = model.ProductModel.ProductModelID,
                    Name = model.ProductModel.Name,
                    CatalogDescription = model.ProductModel.CatalogDescription,
                    rowguid = model.ProductModel.rowguid,
                    ModifiedDate = model.ProductModel.ModifiedDate,
                    ProductModelProductDescription = model.ProductModel.ProductModelProductDescription.Select(x => new ProductModelProductDescription()
                    {
                        ProductModelID = x.ProductModelID,
                        ProductDescriptionID = x.ProductDescriptionID,
                        ProductDescription = new ProductDescription() {
                            ProductDescriptionID = x.ProductDescription.ProductDescriptionID,
                            Description = x.ProductDescription.Description,
                            rowguid = x.ProductDescription.rowguid,
                            ModifiedDate = x.ProductDescription.ModifiedDate
                        },
                        Culture = x.Culture,
                        rowguid = x.rowguid,
                        ModifiedDate = x.ModifiedDate

                    }).ToList()
                    
                };
                ;
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
            catch(Exception ex)
            {
                ProductCategory = new ProductCategory();
                ProductModel = new ProductModel();
                SalesOrderDetail = new HashSet<SalesOrderDetail>();
            }
        }

        public Guid[] GetGuids()
        {
            return new[] { rowguid };
        }

        public int[] GetKeys()
        {
            return new[] { ProductID };
        }

        public Product ToDataBase()
        {
            var data = new Product()
            {
                ProductID = ProductID,
                Name = Name,
                ProductNumber = ProductNumber,
                Color = Color,
                StandardCost = StandardCost,
                ListPrice = ListPrice,
                Size = Size,
                Weight = Weight,
                ProductCategoryID = ProductCategoryID,
                ProductModelID = ProductModelID,
                SellStartDate = SellStartDate,
                SellEndDate = SellEndDate,
                DiscontinuedDate = DiscontinuedDate,
                ThumbNailPhoto = ThumbNailPhoto,
                ThumbnailPhotoFileName = ThumbnailPhotoFileName,
                rowguid = rowguid,
                ModifiedDate = ModifiedDate
            };
            return data;
        }

        public void UpdateDataBase(Product model)
        {
            model.ProductID = ProductID;
            model.Name = Name;
            model.ProductNumber = ProductNumber;
            model.Color = Color;
            model.StandardCost = StandardCost;
            model.ListPrice = ListPrice;
            model.Size = Size;
            model.Weight = Weight;
            model.ProductCategoryID = ProductCategoryID;
            model.ProductModelID = ProductModelID;
            model.SellStartDate = SellStartDate;
            model.SellEndDate = SellEndDate;
            model.DiscontinuedDate = DiscontinuedDate;
            model.ThumbNailPhoto = ThumbNailPhoto;
            model.ThumbnailPhotoFileName = ThumbnailPhotoFileName;
            model.rowguid = rowguid;
            model.ModifiedDate = ModifiedDate;
        }
        #endregion IViewModel<Product> Methods
  
    }
}