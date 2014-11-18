using System.Net.Http;
using System.Web.Http;
using ElasticsearchWorkshop.Web.Models;

namespace ElasticsearchWorkshop.Web.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : BaseController
    {
        [Route]
        [HttpGet]
        public HttpResponseMessage Get(string query)
        {
            var result = _indexer.Search<Order>(ss => ss
                .QueryString(query));
            return Request.CreateResponse(result.Documents);
        }
    }
}