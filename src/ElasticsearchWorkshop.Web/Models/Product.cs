namespace ElasticsearchWorkshop.Web.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public Category Category { get; set; }
    }
}