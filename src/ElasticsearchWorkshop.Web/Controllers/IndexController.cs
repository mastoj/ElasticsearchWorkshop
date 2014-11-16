using System.Net.Http;
using System.Web.Http;

namespace ElasticsearchWorkshop.Web.Controllers
{
    [RoutePrefix("api/index")]
    public class IndexController : ApiController
    {
        [Route]
        [HttpPost]
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse("Indexing");
        }
    }
}
