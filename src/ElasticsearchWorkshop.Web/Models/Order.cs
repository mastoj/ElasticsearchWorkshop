using System;
using System.Collections.Generic;

namespace ElasticsearchWorkshop.Web.Models
{
    public class Order
    {
        public string CustomerId { get; set; }
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public IEnumerable<OrderLine> OrderLines { get; set; }
    }
}