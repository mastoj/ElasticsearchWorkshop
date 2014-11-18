using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using ElasticsearchWorkshop.Web.Extensions;
using ElasticsearchWorkshop.Web.Models;

namespace ElasticsearchWorkshop.Web.Controllers
{
    [RoutePrefix("api/index")]
    public class IndexController : BaseController
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
