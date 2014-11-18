using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using ElasticsearchWorkshop.Web.Models;
using Nest;

namespace ElasticsearchWorkshop.Web.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : BaseController
    {
        [Route]
        [HttpGet]
        public HttpResponseMessage Get(string query)
        {
            var result = _indexer.Search<Product>(ss => ss
                .QueryString(query)
                .Aggregations(aggs => aggs
                    .Terms("categories", s => s
                        .Field(f => f.Category.Name)
                        .Aggregations(s2 => s2 
                            .Terms("categoryid", s3 => s3.Field(p2=> p2.Category.Id))))));
            var productQueryViewModel = new ProductQueryViewModel(result.Documents, result.Aggregations);
            return Request.CreateResponse(productQueryViewModel);
        }

        [Route]
        [HttpPost]
        public HttpResponseMessage Post(string query)
        {
            return Request.CreateResponse("Getting products");
        }

        [Route]
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            return Request.CreateResponse("Deleting product with id: " + id);
        }
    }

    public class ProductQueryViewModel
    {
        public IEnumerable<Product> Documents { get; set; }
        public IDictionary<string, IAggregation> Aggregations { get; set; }

        public ProductQueryViewModel(IEnumerable<Product> documents, IDictionary<string, IAggregation> aggregations)
        {
            Documents = documents;
            Aggregations = aggregations;
        }
    }
}