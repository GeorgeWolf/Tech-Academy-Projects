using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_037
{
    public class Maintenance
    {
        public bool HasBeenDetailed { get; set; }
        public string DetailedServiceHistory { get; set; }

        public void SendCarToDetailer() { }
        public void AddToServiceHistory() { }
    }
}