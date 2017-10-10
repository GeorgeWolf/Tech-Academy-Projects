using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssignment
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                previousDateCalendar.SelectedDate = DateTime.Now.Date;
                startDateCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
                endDateCalendar.SelectedDate = DateTime.Now.Date.AddDays(21);
                startDateCalendar.VisibleDate = startDateCalendar.SelectedDate;
                endDateCalendar.VisibleDate = endDateCalendar.SelectedDate;
            }
            //Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void assignButton_Click(object sender, EventArgs e)
        {
            string spyName = spyTextBox.Text;
            string assignmentName = assignmentTextBox.Text;

            TimeSpan spyHolidayDays = startDateCalendar.SelectedDate
                .Subtract(previousDateCalendar.SelectedDate);

            // Spy salary $500 per day
            TimeSpan totalAssignmentDays = endDateCalendar.SelectedDate
                .Subtract(startDateCalendar.SelectedDate);
            double spySalary = totalAssignmentDays.TotalDays * 500;

            // If the assignment > 21 days, add $1000
            spySalary = (totalAssignmentDays.TotalDays > 21) 
                ? spySalary + 1000 : spySalary;

            resultLabel.Text = String.Format("Assignment of {0} " +
                "to assignment {1} is authorized. " +
                "Budget total: {2:C}", 
                spyName, 
                assignmentName, 
                spySalary);

            if (spyHolidayDays.TotalDays < 14)
            {
                resultLabel.Text = "Error: Must allow at least two weeks " +
                    "between previous assignment and new assignment.";

                startDateCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
                startDateCalendar.VisibleDate = startDateCalendar.SelectedDate;
            }
            
        }
    }
}