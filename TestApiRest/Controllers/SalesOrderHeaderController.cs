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
    public class SalesOrderHeaderController : ApiController
    {
        private readonly IRepository<SalesOrderHeader, SalesOrderHeaderViewModel> _salesOrderHeader;
        public SalesOrderHeaderController(IRepository<SalesOrderHeader, SalesOrderHeaderViewModel> salesOrderHeader)
        {
            _salesOrderHeader = salesOrderHeader;
        }

        public ICollection<SalesOrderHeaderViewModel> GetSalesOrderHeaders()
        {
            return _salesOrderHeader.Get();
        }

        [HttpGet]
        public SalesOrderHeaderViewModel GetSalesOrderHeader(int id)
        {
            return _salesOrderHeader.Get(id);
        }
    }
}
