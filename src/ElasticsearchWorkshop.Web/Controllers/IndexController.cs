using System.Collections.Generic;
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

                var newIndexVersion = _indexVersion + 1;
                var newIndexName = GetIndexName(_indexBaseName, newIndexVersion);

                _indexer.Bulk(bs => bs
                    .CreateMany(customers)
                    .CreateMany(products)
                    .CreateMany(orders));

                var oldIndexes = _indexer.GetIndicesPointingToAlias(_indexBaseName);
                var result =_indexer.Alias(y =>
                {
                    var x = y
                        .Add(add => add.Index(newIndexName).Alias(_indexBaseName));
                    if (oldIndexes.Any())
                    {
                        oldIndexes.ForEach(oi => x = x.Remove(rem => rem.Index(oi).Alias(_indexBaseName)));
                    }
                    return x;
                });
                _indexVersion = newIndexVersion;
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
