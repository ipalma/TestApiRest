using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiRest.ViewModels
{
    public class ProductModelViewModel : IViewModel<ProductModel>
    {
        #region Properties
        public int ProductModelID { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescription { get; set; }
        #endregion Properties

        #region IViewModel<ProductModel> Methods
        public void FromDataBase(ProductModel model)
        {
            ProductModelID = ProductModelID;
            Name = Name;
            CatalogDescription = CatalogDescription;
            rowguid = rowguid;
            ModifiedDate = ModifiedDate;
            try
            {
                Product = model.Product.Select(x => new Models.Product()
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
                ProductModelProductDescription = model.ProductModelProductDescription.Select(x => new ProductModelProductDescription()
                {
                    ProductModelID = x.ProductModelID,
                    ProductDescriptionID = x.ProductDescriptionID,
                    Culture = x.Culture,
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
            return new[] { ProductModelID };
        }

        public ProductModel ToDataBase()
        {
            var data = new ProductModel()
            {
                ProductModelID = ProductModelID,
                Name = Name,
                CatalogDescription = CatalogDescription,
                rowguid = rowguid,
                ModifiedDate = ModifiedDate
            };
            return data;
        }

        public void UpdateDataBase(ProductModel model)
        {
            ProductModelID = ProductModelID;
            Name = Name;
            CatalogDescription = CatalogDescription;
            rowguid = rowguid;
            ModifiedDate = ModifiedDate;
        }
        #endregion IViewModel<ProductModel> Methods

    }
}