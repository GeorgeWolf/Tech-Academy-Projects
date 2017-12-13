using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Replace magic numbers, magic strings, etc. w/ constants!

/* From: https://msdn.microsoft.com/en-us/library/e6w8fe1b.aspx
 * Constant fields and locals aren't variables
 * and may not be modified. Constants can be numbers,
 * Boolean values, strings, or a null reference.
 * Don't create a constant to represent information
 * that you expect to change at any time. For example,
 * don't use a constant field to store the price of
 * a service, a product version number, or the brand
 * name of a company. These values can change over time,
 * and because compilers propagate constants,
 * other code compiled with your libraries will
 * have to be recompiled to see the changes.
*/

namespace CS_ASP_053b
{
    public partial class Default : System.Web.UI.Page
    {
        const string fileExtension = ".html";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            // Constant Locals
            const int hoursPerDay = 24;

            // Calculate a constant
            const double daysPerWeek = (double)Calendar.days / (double)Calendar.weeks;

            //daysPerWeek = 7;
            string result = "";

            for (int i = 1; i <= daysPerWeek; i++)
            {
                for (int j = 0; j < hoursPerDay; j++)
                {
                    result += String.Format("<p><a href='report-{0}-{1}.{2}'>Day: {0} -- Hour: {1}</a></p>", i, j, fileExtension);
                }
            }

            resultLabel.Text = result;

        }
    }
}