using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_017
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                myTextBox.Text = "Some value";
                myCalendar.SelectedDate = DateTime.Now.Date.AddDays(2);
            }
        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = myTextBox.Text + " - " 
                + myCalendar.SelectedDate.ToShortDateString();
        }
    }
}