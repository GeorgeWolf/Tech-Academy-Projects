using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_018
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // FYI ... I would never do this, but the fact
            // that you *can* is remarkable:
            myTextBox.Text = 500.ToString();
        }

        protected void okButton_Click(object sender, EventArgs e)
        {

            // Random Business Rule 1: You must select a date in 
            // secondCalendar that is at least 14 days from
            // the selected date in firstCalendar. Otherwise
            // show the user an error in the resultLabel.

            // Random Business Rule 2: The resultLabel should be
            // the sum of the TextBox and the TimeSpan.TotalDays
            // between the two calendars times 100.

            if (firstCalendar.SelectedDate.AddDays(15) >= secondCalendar.SelectedDate)
            {
                TimeSpan elapsedDays = firstCalendar.SelectedDate.Subtract(secondCalendar.SelectedDate);
                double userValue = double.Parse(myTextBox.Text);
                double days = elapsedDays.TotalDays;
                double sum = userValue * days + 100;
                resultLabel.Text = sum.ToString();
            }
            else
            {
                resultLabel.Text = "Error. You must choose a date at least 14 days apart.";
            }

        }
    }
}