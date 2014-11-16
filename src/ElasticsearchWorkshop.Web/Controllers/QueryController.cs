using System.Net.Http;
using System.Web.Http;

namespace ElasticsearchWorkshop.Web.Controllers
{
    [RoutePrefix("api/query")]
    public class QueryController : ApiController
    {
        [Route]
        [HttpGet]
        public HttpResponseMessage Get(string query)
        {
            return Request.CreateResponse("Querying");
        }
    }
}