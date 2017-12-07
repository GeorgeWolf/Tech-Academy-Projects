using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostalCalculatorHelperMethodsDRY
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            resultLabel.Text = "";
        }

        protected void handleChange(object sender, EventArgs e)
        {
            performCalculation();
        }

        private void performCalculation()
        {
            // Check for the values in the TextBoxes & CheckBoxes
            if (!valuesExist()) return;

            // What is the volume
            double volume = 0.0;
            if (!tryGetVolume(out volume)) return;

            // What is the multiplier
            double postageMultiplier = getPostageMultiplier();

            // Determine the cost
            double cost = volume * postageMultiplier;

            // Show the result
            resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", cost);
        }

        private bool valuesExist()
        {
            if (!airRadioButton.Checked
                && !groundRadioButton.Checked
                && !nextDayRadioButton.Checked)
                return false;

            if (widthTextBox.Text.Trim().Length == 0
                || heightTextBox.Text.Trim().Length == 0)
                return false;

            return true;
        }

        private bool tryGetVolume(out double volume)
        {
            volume = 0.0;
            double width = 0.0;
            double height = 0.0;
            double length = 0.0;

            if (!double.TryParse(widthTextBox.Text.Trim(), out width)) return false;
            if (!double.TryParse(heightTextBox.Text.Trim(), out height)) return false;
            if (!double.TryParse(lengthTextBox.Text.Trim(), out length)) length = 1.0;

            volume = width * height * length;
            return true;
        }

        private double getPostageMultiplier()
        {
            if (groundRadioButton.Checked) return .15;
            else if (airRadioButton.Checked) return .25;
            else if (nextDayRadioButton.Checked) return .45;
            else return 0;
        }
    }
}