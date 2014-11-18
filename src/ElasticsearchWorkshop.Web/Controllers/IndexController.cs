using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
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
        private ElasticClient _indexer;

        public IndexController()
        {
            _indexer = CreateIndexer();
        }

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

                _indexer.DeleteIndex(s => s.Index("elasticworkshop"));
                customers.ForEach(c => _indexer.Index(c));
                products.ForEach(p => _indexer.Index(p));
                orders.ForEach(o => _indexer.Index(o));

                return Request.CreateResponse(indexModel);
            }
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage Get(string query = null)
        {
            var result = _indexer.Search<object>(s => s
                .Types(typeof (Product), typeof (Order), typeof (Customer))
                .QueryString(query));

            return Request.CreateResponse(result.Documents);
        }

        private ElasticClient CreateIndexer()
        {
            IConnectionSettingsValues settings = new ConnectionSettings(new Uri("http://192.168.50.69:9200"),
                "elasticworkshop");
            return new ElasticClient(settings);
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
