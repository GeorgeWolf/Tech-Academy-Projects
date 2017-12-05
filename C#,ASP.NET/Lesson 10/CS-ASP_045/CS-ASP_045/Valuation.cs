using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_ASP_045
{
    public static class Valuation
    {
        /*
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        */

        public static int PerformCalculation(int one, int two)
        {
            //return one + two;
            return handleSomePartOfTheCalculation(one, two);
        }

        private static int handleSomePartOfTheCalculation(int one, int two)
        {
            return one + two;
        }


    }
}