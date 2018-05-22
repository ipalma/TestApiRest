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
    public class ProductModelController : ApiController
    {
        private readonly IRepository<ProductModel, ProductModelViewModel> _productModel;
        public ProductModelController(IRepository<ProductModel, ProductModelViewModel> productModel)
        {
            _productModel = productModel;
        }

        public ICollection<ProductModelViewModel> GetProductModels()
        {
            return _productModel.Get();
        }

        [HttpGet]
        public ProductModelViewModel GetProductModel(int id)
        {
            return _productModel.Get(id);
        }
    }
}
