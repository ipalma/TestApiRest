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
    public class SalesOrderDetailController : ApiController
    {
        private readonly IRepository<SalesOrderDetail, SalesOrderDetailViewModel> _salesOrderDetail;
        public SalesOrderDetailController(IRepository<SalesOrderDetail, SalesOrderDetailViewModel> salesOrderDetail)
        {
            _salesOrderDetail = salesOrderDetail;
        }

        public ICollection<SalesOrderDetailViewModel> GetSalesOrderDetails()
        {
            return _salesOrderDetail.Get();
        }

        [HttpGet]
        public SalesOrderDetailViewModel GetSalesOrderDetail(int id)
        {
            return _salesOrderDetail.Get(id);
        }
    }
}
