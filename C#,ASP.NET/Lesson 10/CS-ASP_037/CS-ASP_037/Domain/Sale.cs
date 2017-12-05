using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_037
{
    public class Sale
    {
        public Automobile Automobile { get; set; }
        public Salesman Salesman { get; set; }
        public Customer Customer { get; set; }
        public double TotalSaleAmount { get; set; }

        public void SellCar() { }
    }
}