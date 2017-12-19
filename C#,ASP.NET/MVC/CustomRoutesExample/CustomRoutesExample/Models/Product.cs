using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomRoutesExample.Models
{
    public class ProductManager
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            products.Add(new Product { ProductId = 123, Name = "Foo", Price = 12.95M, Category = "Widgets" });
            products.Add(new Product { ProductId = 234, Name = "Bar", Price = 13.50M, Category = "Gadgets" });
            products.Add(new Product { ProductId = 345, Name = "Baz", Price = 16.95M, Category = "Widgets" });
            products.Add(new Product { ProductId = 456, Name = "Quirk", Price = 21.95M, Category = "Gadgets" });

            return products;
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}