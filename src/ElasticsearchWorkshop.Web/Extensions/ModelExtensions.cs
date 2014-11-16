using System;
using System.Collections.Generic;
using System.Linq;

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

    public class OrderLine
    {
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
    }

    public class Order
    {
        public string CustomerId { get; set; }
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public IEnumerable<OrderLine> OrderLines { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public Category Category { get; set; }
    }

    public class Customer
    {
        public string Country { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string ContactName { get; set; }
        public string Id { get; set; }
    }
}