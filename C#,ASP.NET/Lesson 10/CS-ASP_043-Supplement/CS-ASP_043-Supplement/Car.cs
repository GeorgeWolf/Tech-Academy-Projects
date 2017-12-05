using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_043_Supplement
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public double RetailPrice { get; set; }
        public string OptionsPackage { get; set; }

        public Car()
        {
            Make = "Tabor Robomotives";
            Model = "3002";
            Year = 2024;
            Color = "Black";
            RetailPrice = 70000.0;
            OptionsPackage = "";
        }

        public Car(string optionsPackage) : this()
        {
            /*
            Make = "Tabor Robomotives";
            Model = "3001";
            Year = 2023;
            Color = "Black";
            OptionsPackage = optionsPackage;
            */

            if (optionsPackage == "Offroad Package")
                RetailPrice = 75000.0;
            else if (optionsPackage == "Sports Package")
                RetailPrice = 82000.0;
            else if (optionsPackage == "Touring Package")
                RetailPrice = 85000.0;
        }

        public Car(string optionsPackage, string color) : this(optionsPackage)
        {
            /*
            Make = "Tabor Robomotives";
            Model = "3001";
            Year = 2023;
            Color = "Black";
            OptionsPackage = optionsPackage;
            */
            /*
            if (optionsPackage == "Offroad Package")
                RetailPrice = 75000.0;
            else if (optionsPackage == "Sports Package")
                RetailPrice = 82000.0;
            else if (optionsPackage == "Touring Package")
                RetailPrice = 85000.0;
            */

            if (color != "Black" && color != "White")
            {
                Color = "Custom";
                RetailPrice += 20000.0;
            }

        }
    }
}