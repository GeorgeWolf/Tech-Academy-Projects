using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    public class HelloModel
    {
        public static List<Car> GetCars()
        {
            List<Car> cars = new List<Car>()
            {
                new Car { Id = 1, Make = "BMW", Model = "528i" },
                new Car { Id = 2, Make = "Hyundai", Model = "Elantra" },
                new Car { Id = 3, Make = "Toyota", Model = "4Runner" }
            };
            return cars;
        }
    }

    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}