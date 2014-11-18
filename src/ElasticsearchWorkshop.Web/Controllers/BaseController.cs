using System;
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

        protected static string _indexBaseName = "elasticworkshop";
        protected static int _indexVersion = 0;

        protected static string GetIndexName(string name, int version)
        {
            return string.Format("{0}_{1}", name, version);
        }

        protected static string GetCurrentIndexName()
        {
            return GetIndexName(_indexBaseName, _indexVersion);
        }
    }
}