using System.Net.Http;
using System.Web.Http;

namespace ElasticsearchWorkshop.Web.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        [Route]
        [HttpGet]
        public HttpResponseMessage Get(string query)
        {
            return Request.CreateResponse("Getting products");
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