using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomDisplayTemplateExample.Models
{
    public class ProductManager
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            products.Add(new Product { ProductId = 1, Name = "Foo", Price = 12.95M, ReleaseDate = new DateTime(2015, 11, 1), Description = "Lucas ipsum dolor sit amet nosaurian leia trandoshan plo phlog trioculus zuckuss billaba golda vader. Wilhuff lobot ferroans tarasin firmus jusik charal borsk. Tatooine even vagaari codru-ji subterrel. Kwi kir darth orus." });
            products.Add(new Product { ProductId = 2, Name = "Bar", Price = 13.50M, ReleaseDate = new DateTime(2015, 11, 10), Description = "Yuzzum tython h'nemthean sy garm crynyd. Wol gizka defel cornelius. Bespin jinn lumiya briqualon vebb rahn lars chirrpa calrissian. Solo klatooinian p'w'eck valorum. Taun saché jar lando ev-9d9 artaru illum nute. Defel moff -lom cad." });
            products.Add(new Product { ProductId = 3, Name = "Baz", Price = 16.95M, ReleaseDate = new DateTime(2015, 11, 2), Description = "Neimoidia gunray kor-uj durge windu. Noa darth jar unu. Rattatak valorum kor-uj xizor paploo maul. Kal jamillia fett shaddaa. Yoda caedus boba droopy kenobi antilles rattatak skywalker arvel." });
            products.Add(new Product { ProductId = 4, Name = "Quirk", Price = 21.95M, ReleaseDate = new DateTime(2015, 11, 20), Description = "Hutt shado kiffar quadrinaros kalarba besalisk borvo h'nemthean nas. Braxant quelli wroonian shimrra kushiban. Kal taun yavin jango chewbacca wyl. Jeremoch jobal hypori carnor mon bardan." });

            return products;
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public decimal Price { get; set; }

        [UIHint("DateTimePicker")]
        public DateTime ReleaseDate { get; set; }
    }

}