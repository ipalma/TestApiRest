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
    public class ProductController : ApiController
    {
        private readonly IRepository<Product, ProductViewModel> _product;
        public ProductController(IRepository<Product,ProductViewModel> product)
        {
            _product = product;
        }

        public ICollection<ProductViewModel> GetProducts()
        {
            return _product.Get();
        }

        [HttpGet]
        public ProductViewModel GetProduct(int id)
        {
            return _product.Get(id); 
        }

    }
}
