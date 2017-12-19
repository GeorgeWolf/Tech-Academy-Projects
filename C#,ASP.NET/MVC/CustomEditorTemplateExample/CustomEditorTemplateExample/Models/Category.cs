using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomDisplayTemplateExample.Models
{
    public class CategoryManager 
    {
        public static List<Category> GetCategories() 
        {
            var categories = new List<Category>();

            categories.Add(new Category { CategoryId=1, Name="Widgets", Items = 3 });
            categories.Add(new Category { CategoryId=2, Name="Gadgets", Items = 4 });
            categories.Add(new Category { CategoryId=3, Name="Poppycock", Items = 10 });
            categories.Add(new Category { CategoryId=4, Name="Balderdash", Items = 9 });

            return categories;
        }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Items { get; set; }
    }
}