using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalExceptionHandling
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            if (ex != null)
            {
                resultLabel.Text = "Error: " + ex.InnerException.Message;
            }
            else
            {
                resultLabel.Text = "Something went horribly wrong, but it wasn't your fault.";
            }
        }
    }
}