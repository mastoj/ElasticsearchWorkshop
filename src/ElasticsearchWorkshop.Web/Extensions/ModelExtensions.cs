using System.Collections.Generic;
using System.Linq;
using ElasticsearchWorkshop.Web.Models;

namespace ElasticsearchWorkshop.Web.Extensions
{
    public static class ModelExtensions
    {
        public static IEnumerable<Customer> ToDocuments(this IEnumerable<Customers> dbCustomers)
        {
            return dbCustomers.Select(y => y.ToDocument());
        }

        public static Customer ToDocument(this Customers dbCustomer)
        {
            return new Customer
            {
                Id = dbCustomer.CustomerID,
                Country = dbCustomer.Country,
                CompanyName = dbCustomer.CompanyName,
                City = dbCustomer.City,
                Address = dbCustomer.Address,
                Region = dbCustomer.Region,
                ContactName = dbCustomer.ContactName
            };
        }

        public static IEnumerable<Product> ToDocuments(this IEnumerable<Products> dbProducts)
        {
            return dbProducts.Select(y => y.ToDocument());
        }

        public static Product ToDocument(this Products dbProduct)
        {

            return new Product()
            {
                Id = dbProduct.ProductID,
                Category = dbProduct.Categories.ToDocument(),
                Name = dbProduct.ProductName,
                Price = dbProduct.UnitPrice
            };
        }

        public static Category ToDocument(this Categories dbCategory)
        {
            return new Category()
            {
                Name = dbCategory.CategoryName,
                Description = dbCategory.Description,
                Id = dbCategory.CategoryID
            };
        }

        public static IEnumerable<Order> ToDocuments(this IEnumerable<Orders> dbOrders)
        {
            return dbOrders.Select(y => y.ToDocument());
        }

        public static Order ToDocument(this Orders dbOrder)
        {
            return new Order()
            {
                CustomerId = dbOrder.CustomerID,
                Id = dbOrder.OrderID,
                OrderDate = dbOrder.OrderDate,
                OrderLines = dbOrder.Order_Details.ToDocuments()
            };
        }

        public static IEnumerable<OrderLine> ToDocuments(this IEnumerable<Order_Details> dbOrderLines)
        {
            return dbOrderLines.Select(y => y.ToDocument());
        }

        public static OrderLine ToDocument(this Order_Details dbOrderLine)
        {
            return new OrderLine()
            {
                Quantity = dbOrderLine.Quantity,
                UnitPrice = dbOrderLine.UnitPrice,
                ProductName = dbOrderLine.Products.ProductName,
                ProductId = dbOrderLine.Products.ProductID
            };
        }
    }
}