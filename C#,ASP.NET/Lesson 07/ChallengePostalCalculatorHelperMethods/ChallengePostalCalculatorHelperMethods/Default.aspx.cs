using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostageCalculatorHelperMethods
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            resultLabel.Text = "";
        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void groundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Ground: .15 multiplier
            calculatePostalPrice(.15);
            resultText();
        }

        protected void airRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Air: .25 multiplier
            calculatePostalPrice(.25);
            resultText();
        }

        protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Next Day: .45 multiplier
            calculatePostalPrice(.45);
            resultText();
        }

        private double calculatePackageSize()
        {
            double sizeOfPackage = 0.0;
            double sizeOfWidth = 0.0;
            double sizeOfHeight = 0.0;
            double sizeOfLength = 0.0;
            if (!Double.TryParse(widthTextBox.Text, out sizeOfWidth))
                return sizeOfPackage;

            if (!Double.TryParse(heightTextBox.Text, out sizeOfHeight))
                return sizeOfPackage;

            if (!Double.TryParse(lengthTextBox.Text, out sizeOfLength))
                sizeOfLength = 1.0;

            sizeOfPackage = sizeOfWidth * sizeOfHeight * sizeOfLength;

            return sizeOfPackage;
        }

        private void calculatePostalPrice(double multiplyPackageSize)
        {
            double priceOfPackage = calculatePackageSize() * multiplyPackageSize;

            resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", priceOfPackage);
        }
        
        private void resultText()
        {
            if ((widthTextBox.Text.Trim() == "0")
                || (heightTextBox.Text.Trim() == "0")
                || (lengthTextBox.Text.Trim() == "0"))
                resultLabel.Text = "You have to provide a value other than 0.";
            
            else if (!(widthTextBox.Text.Trim().Length == 0) 
                && !(heightTextBox.Text.Trim().Length == 0)) { }

            else
                resultLabel.Text = "You must provide both the Width and the Height of the Item to be shipped.";
        }
    }
}