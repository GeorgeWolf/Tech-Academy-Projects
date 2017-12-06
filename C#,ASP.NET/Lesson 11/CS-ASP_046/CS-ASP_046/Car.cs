using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_046
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car()
        {
            this.Make = "Undefined";
            this.Model = "Undefined";
            this.Year = 1980;
            this.Color = "Undefined";
        }

        //Overloaded constructor
        public Car(string make, string model, int year, string color)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Color = color;
        }


        public string FormatDetailsForDisplay()
        {
            return String.Format("Make: {0} - Model: {1} - Year: {2} - Color: {3}<br/>", this.Make, this.Model, this.Year.ToString(), this.Color);
        }
    }
}