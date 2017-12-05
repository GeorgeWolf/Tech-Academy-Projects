using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_044
{
    public class Hero
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _hitPoints;
        public int HitPoints
        {
            get { return _hitPoints; }
            set { _hitPoints = value; }
        }

        public Hero(string name, int hitPoints)
        {
            _name = name;
            _hitPoints = hitPoints;
        }
    }
}