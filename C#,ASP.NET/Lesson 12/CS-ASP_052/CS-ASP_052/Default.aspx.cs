using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_052
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // http://en.wikipedia.org/wiki/Globally_unique_identifier

            //var myGuid = Guid.NewGuid();
            //resultLabel.Text = myGuid.ToString();

            // Parsing a string into a Guid
            // var myOtherGuid = Guid.Parse("6d8786be-3bbb-4506-a900-aacb5614542d");

            Guid myOtherGuid;
            if (Guid.TryParse("6d8786be-3bbb-4506-a900-aacb5614542d", out myOtherGuid))
            {
                resultLabel.Text = myOtherGuid.ToString();
            }

        }
    }
}