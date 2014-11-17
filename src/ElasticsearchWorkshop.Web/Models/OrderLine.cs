namespace ElasticsearchWorkshop.Web.Models
{
    public class OrderLine
    {
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
    }
}