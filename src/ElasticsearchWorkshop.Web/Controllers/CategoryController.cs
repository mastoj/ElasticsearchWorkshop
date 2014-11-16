using System.Net.Http;
using System.Web.Http;

namespace ElasticsearchWorkshop.Web.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
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
            return Request.CreateResponse("Deleting category with id: " + id);
        }
    }
}