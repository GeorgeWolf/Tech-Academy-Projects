using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACME.Accounting;
using ACME.Marketing;

using Administration = ACME.Accounting.Administration;

namespace CS_ASP_040_Suppliment
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            Administration a = new Administration();
            resultLabel.Text = a.FormatMessage();
        }
    }
}