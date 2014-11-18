using System.Net.Http;
using System.Web.Http;
using ElasticsearchWorkshop.Web.Models;

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
                .QueryString(query));
            return Request.CreateResponse(result.Documents);
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
}