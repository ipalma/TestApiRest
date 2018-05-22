using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiRest.ViewModels
{
    public class ProductCategoryViewModel: IViewModel<ProductCategory>
    {
        #region Properties
        public int ProductCategoryID { get; set; }
        public Nullable<int> ParentProductCategoryID { get; set; }
        public string Name { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory1 { get; set; }
        public virtual ProductCategory ProductCategory2 { get; set; }
        #endregion Properties

        #region IViewModel<ProductCategory> Methods
        public void FromDataBase(ProductCategory model)
        {
            ProductCategoryID = model.ProductCategoryID;
            ParentProductCategoryID = model.ParentProductCategoryID;
            Name = model.Name;
            rowguid = model.rowguid;
            ModifiedDate = model.ModifiedDate;
            try
            {
                Product = model.Product.Select(x => new Product()
                {
                    ProductID = x.ProductID,
                    Name = x.Name,
                    ProductNumber = x.ProductNumber,
                    Color = x.Color,
                    StandardCost = x.StandardCost,
                    ListPrice = x.ListPrice,
                    Size = x.Size,
                    Weight = x.Weight,
                    ProductCategoryID = x.ProductCategoryID,
                    ProductModelID = x.ProductModelID,
                    SellStartDate = x.SellStartDate,
                    SellEndDate = x.SellEndDate,
                    DiscontinuedDate = x.DiscontinuedDate,
                    ThumbNailPhoto = x.ThumbNailPhoto,
                    ThumbnailPhotoFileName = x.ThumbnailPhotoFileName,
                    rowguid = x.rowguid,
                    ModifiedDate = x.ModifiedDate
                }).ToList();

                ProductCategory1 = model.ProductCategory1.Select(x => new ProductCategory()
                {
                    ProductCategoryID = x.ProductCategoryID,
                    ParentProductCategoryID = x.ParentProductCategoryID,
                    Name = x.Name,
                    rowguid = x.rowguid,
                    ModifiedDate = x.ModifiedDate
                }).ToList();
                ProductCategory2 = new ProductCategory()
                {
                    ProductCategoryID = model.ProductCategory2.ProductCategoryID,
                    ParentProductCategoryID = model.ProductCategory2.ParentProductCategoryID,
                    Name = model.ProductCategory2.Name,
                    rowguid = model.ProductCategory2.rowguid,
                    ModifiedDate = model.ProductCategory2.ModifiedDate
                };
                    
            }
            catch(Exception ex)
            {

            }

        }

        public Guid[] GetGuids()
        {
            return new[] { rowguid };
        }

        public int[] GetKeys()
        {
            return new[] { ProductCategoryID };
        }

        public ProductCategory ToDataBase()
        {
            var data = new ProductCategory()
            {
                ProductCategoryID = ProductCategoryID,
                ParentProductCategoryID = ParentProductCategoryID,
                Name = Name,
                rowguid = rowguid,
                ModifiedDate = ModifiedDate
               
            };
            return data;
        }

        public void UpdateDataBase(ProductCategory model)
        {
            model.ProductCategoryID = ProductCategoryID;
            model.ParentProductCategoryID = ParentProductCategoryID;
            model.Name = Name;
            model.rowguid = rowguid;
            model.ModifiedDate = ModifiedDate;
        }
        #endregion IViewModel<ProductCategory> Methods

    }
}