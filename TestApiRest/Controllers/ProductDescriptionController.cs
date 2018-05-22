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
    public class ProductDescriptionController : ApiController
    {
        private readonly IRepository<ProductDescription, ProductDescriptionViewModel> _productDescription;
        public ProductDescriptionController(IRepository<ProductDescription, ProductDescriptionViewModel> productDescription)
        {
            _productDescription = productDescription;
        }

        public ICollection<ProductDescriptionViewModel> GetProductDescriptions()
        {
            return _productDescription.Get();
        }

        [HttpGet]
        public ProductDescriptionViewModel GetProductDescription(int id)
        {
            return _productDescription.Get(id);
        }
    }
}
