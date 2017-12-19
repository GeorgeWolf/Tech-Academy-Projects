using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChildActionExample.Models
{
    public class ProductManager
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            products.Add(new Product { ProductId = 1, Name = "Foo", Price = 12.95M });
            products.Add(new Product { ProductId = 2, Name = "Bar", Price = 13.50M });
            products.Add(new Product { ProductId = 3, Name = "Baz", Price = 16.95M });
            products.Add(new Product { ProductId = 4, Name = "Quirk", Price = 21.95M });

            return products;
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}