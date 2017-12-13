using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace GlobalExceptionHandling
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        void Application_Error(object sender, EventArgs e)
        {
            // What just happened?
            Exception ex = Server.GetLastError();

            // ex will always be of type HttpUnhandledException
            // To get to the exception that CAUSED that to happen
            // you'll need to look at the ex.InnerException.
            var innerException = ex.InnerException;

            // Handle a specific type of error differently.
            if (innerException.GetType()
                == typeof(ArgumentOutOfRangeException))
            {
                Server.Transfer("Error.aspx");
            }

            Response.Write("<h2>Something bad happened ...</h2>");
            Response.Write("<p>" + innerException.Message + "<p>");

            // TODO: You might choose to implement logging here.


            // You must do this if you want to hide the
            // yellow page of death ... any existing exceptions
            // after this point will send the end user the
            // exception page.
            Server.ClearError();
        }
    }
}