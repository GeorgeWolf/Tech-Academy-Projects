using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_045
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int myValue = Valuation.PerformCalculation(4, 5);

            /*
            Valuation myValuation = new Valuation();
            myValuation.MyProperty = 4;
            */
        }
    }
}