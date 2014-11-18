using System;
using System.Net.Http;
using System.Web.Http;
using Nest;

namespace ElasticsearchWorkshop.Web.Controllers
{
    public class BaseController : ApiController
    {
        protected ElasticClient _indexer;

        public BaseController()
        {
            _indexer = CreateIndexer();
        }

        private ElasticClient CreateIndexer()
        {
            IConnectionSettingsValues settings = new ConnectionSettings(new Uri("http://192.168.50.69:9200"),
                "elasticworkshop");
            return new ElasticClient(settings);
        }
    }

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