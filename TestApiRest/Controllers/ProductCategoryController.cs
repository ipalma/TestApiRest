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
    public class ProductCategoryController : ApiController
    {
        private readonly IRepository<ProductCategory, ProductCategoryViewModel> _productCategory;
        public ProductCategoryController(IRepository<ProductCategory, ProductCategoryViewModel> productCategory)
        {
            _productCategory = productCategory;
        }

        public ICollection<ProductCategoryViewModel> GetProductCategores()
        {
            return _productCategory.Get();
        }

        [HttpGet]
        public ProductCategoryViewModel GetProductCategory(int id)
        {
            return _productCategory.Get(id);
        }
    }
}
