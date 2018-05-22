using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiRest.ViewModels
{
    public class ProductModelProductDescriptionViewModel : IViewModel<ProductModelProductDescription>
    {
        #region Properties
        public int ProductModelID { get; set; }
        public int ProductDescriptionID { get; set; }
        public string Culture { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ProductDescription ProductDescription { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        #endregion Properties

        #region IViewModel<ProductModelProductDescription> Methods
        public void FromDataBase(ProductModelProductDescription model)
        {
            ProductModelID = model.ProductModelID;
            ProductDescriptionID = model.ProductDescriptionID;
            Culture = model.Culture;
            rowguid = model.rowguid;
            ModifiedDate = model.ModifiedDate;

            try
            {
                ProductDescription = new ProductDescription()
                {
                    ProductDescriptionID = model.ProductDescription.ProductDescriptionID,
                    Description = model.ProductDescription.Description,
                    rowguid = model.ProductDescription.rowguid,
                    ModifiedDate = model.ProductDescription.ModifiedDate
                };

                ProductModel = new ProductModel()
                {
                    ProductModelID = model.ProductModel.ProductModelID,
                    Name = model.ProductModel.Name,
                    CatalogDescription = model.ProductModel.CatalogDescription,
                    rowguid = model.ProductModel.rowguid,
                    ModifiedDate = model.ProductModel.ModifiedDate
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
            return new[] { ProductModelID };
        }

        public ProductModelProductDescription ToDataBase()
        {
            var data = new ProductModelProductDescription()
            {
                ProductModelID = ProductModelID,
                ProductDescriptionID = ProductDescriptionID,
                Culture = Culture,
                rowguid = rowguid,
                ModifiedDate = ModifiedDate
            };
            return data;
        }

        public void UpdateDataBase(ProductModelProductDescription model)
        {
            model.ProductModelID = ProductModelID;
            model.ProductDescriptionID = ProductDescriptionID;
            model.Culture = Culture;
            model.rowguid = rowguid;
            model.ModifiedDate = ModifiedDate;
        }
        #endregion IViewModel<ProductModelProductDescription> Methods

    }
}