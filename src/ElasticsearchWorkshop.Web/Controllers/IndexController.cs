﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using ElasticsearchWorkshop.Web.Extensions;
using ElasticsearchWorkshop.Web.Models;
using Nest;
using WebGrease.Css.Extensions;

namespace ElasticsearchWorkshop.Web.Controllers
{
    [RoutePrefix("api/index")]
    public class IndexController : ApiController
    {
        [Route]
        [HttpPost]
        public HttpResponseMessage Post()
        {
            using (var context = new NORTHWNDEntities())
            {
                var customers = context.Customers.ToDocuments().ToList();
                var products = context.Products.ToDocuments().ToList();
                var orders = context.Orders.ToDocuments().ToList();
                var indexModel = new IndexModel(customers, products, orders);
                return Request.CreateResponse(indexModel);
            }
        }
    }

    public class IndexModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public IndexModel(IEnumerable<Customer> customers, IEnumerable<Product> products, IEnumerable<Order> orders)
        {
            Customers = customers;
            Products = products;
            Orders = orders;
        }
    }
}
