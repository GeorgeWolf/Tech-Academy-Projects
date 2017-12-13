using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalExceptionHandling
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            HelperMethods.SomeMethod();
        }

        protected void argumentOutOfRangeButton_Click(object sender, EventArgs e)
        {
            // Ideally there would be other code here
            // but I'm just simulating some exception.

            throw new ArgumentOutOfRangeException();
        }

        public class HelperMethods
        {
            public static void SomeMethod()
            {
                throw new Exception("I told you not to do it!");
            }
        }
    }
}