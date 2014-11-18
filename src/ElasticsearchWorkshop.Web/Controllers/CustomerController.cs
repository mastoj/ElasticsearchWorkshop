using System.Net.Http;
using System.Web.Http;
using ElasticsearchWorkshop.Web.Models;

namespace ElasticsearchWorkshop.Web.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : BaseController
    {
        [Route]
        [HttpGet]
        public HttpResponseMessage Get(string query)
        {
            var result = _indexer.Search<Customer>(ss => ss
                .QueryString(query));
            return Request.CreateResponse(result.Documents);
        }
    }
}