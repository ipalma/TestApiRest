using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApiRest.ViewModels;

namespace TestApiRest.Controllers
{
    public class ProductModelProductDescriptionController : ApiController
    {
        private readonly IRepository<ProductModelProductDescription, ProductModelProductDescriptionViewModel> _productModelProductDescription;
        public ProductModelProductDescriptionController(IRepository<ProductModelProductDescription, ProductModelProductDescriptionViewModel> productModelProductDescription)
        {
            _productModelProductDescription = productModelProductDescription;
        }

        public ICollection<ProductModelProductDescriptionViewModel> GetProductModelProductDescriptions()
        {
            return _productModelProductDescription.Get();
        }

        [HttpGet]
        public ProductModelProductDescriptionViewModel GetProductModelProductDescription(int id)
        {
            return _productModelProductDescription.Get(id);
        }

        public ProductModelProductDescriptionViewModel GetProductModelProductDescriptionByProductModelID(int id)
        {
            return _productModelProductDescription.Get(x => x.ProductModelID == id).FirstOrDefault();
        }
    }
}
