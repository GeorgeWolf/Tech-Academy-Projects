using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeDaysBetweenDates
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            DateTime firstDate = firstCalendar.SelectedDate;
            DateTime secondDate = secondCalendar.SelectedDate;

            if (secondDate >= firstDate)
            {
                TimeSpan secondMinusFirst = secondDate.Subtract(firstDate);
                resultLabel.Text = secondMinusFirst.Days.ToString();
            }
            else
            {
                TimeSpan firstMinusSecond = firstDate.Subtract(secondDate);
                resultLabel.Text = firstMinusSecond.Days.ToString();
            }
        }
    }
}