using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempDataExample.Models
{
    public class ProductManager
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            products.Add(new Product { ProductId = 1, Name = "Foo", Price = 12.95M, ReleaseDate = new DateTime(2015, 11, 1) });
            products.Add(new Product { ProductId = 2, Name = "Bar", Price = 13.50M, ReleaseDate = new DateTime(2015, 11, 10) });
            products.Add(new Product { ProductId = 3, Name = "Baz", Price = 16.95M, ReleaseDate = new DateTime(2015, 11, 2) });
            products.Add(new Product { ProductId = 4, Name = "Quirk", Price = 21.95M, ReleaseDate = new DateTime(2015, 11, 20) });

            return products;
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}