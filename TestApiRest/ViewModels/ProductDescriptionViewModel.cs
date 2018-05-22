using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiRest.ViewModels
{
    public class ProductDescriptionViewModel : IViewModel<ProductDescription>
    {
        #region Properties
        public int ProductDescriptionID { get; set; }
        public string Description { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescription { get; set; }
        #endregion Properties

        #region IViewModel<ProductDescription> Methods
        public void FromDataBase(ProductDescription model)
        {
            ProductDescriptionID = model.ProductDescriptionID;
            Description = model.Description;
            rowguid = model.rowguid;
            ModifiedDate = model.ModifiedDate;

            try
            {
                ProductModelProductDescription = model.ProductModelProductDescription.Select(x => new Models.ProductModelProductDescription()
                {
                    ProductModelID = x.ProductModelID,
                    ProductDescriptionID = x.ProductDescriptionID,
                    Culture = x.Culture,
                    rowguid = x.rowguid,
                    ModifiedDate = x.ModifiedDate
                }).ToList();
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
            return new[] { ProductDescriptionID };
        }

        public ProductDescription ToDataBase()
        {
            var data = new ProductDescription()
            {
                ProductDescriptionID = ProductDescriptionID,
                Description = Description,
                rowguid = rowguid,
                ModifiedDate = ModifiedDate
            };
            return data;
        }

        public void UpdateDataBase(ProductDescription model)
        {
            model.ProductDescriptionID = ProductDescriptionID;
            model.Description = Description;
            model.rowguid = rowguid;
            model.ModifiedDate = ModifiedDate;
        }
        #endregion IViewModel<ProductDescription> Methods

    }
}