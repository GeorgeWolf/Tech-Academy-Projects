using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeFirstPapaBobsWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void purchaseButton_Click(object sender, EventArgs e)
        {
            double totalAmount;

            if (babySizeRadioButton.Checked)
                totalAmount = 10;
            else if (mamaSizeRadioButton.Checked)
                totalAmount = 13;
            else
                totalAmount = 16;

            if (deepDishRadioButton.Checked)
                totalAmount += 2;

            totalAmount = (pepperoniCheckBox.Checked) ? totalAmount + 1.50 : totalAmount;
            totalAmount = (onionsCheckBox.Checked) ? totalAmount + 0.75 : totalAmount;
            totalAmount = (greenPeppersCheckBox.Checked) ? totalAmount + 0.5 : totalAmount;
            totalAmount = (redPeppersCheckBox.Checked) ? totalAmount + 0.75 : totalAmount;
            totalAmount = (anchoviesCheckBox.Checked) ? totalAmount + 2 : totalAmount;

            if ((pepperoniCheckBox.Checked
                && greenPeppersCheckBox.Checked
                && anchoviesCheckBox.Checked)
                || (pepperoniCheckBox.Checked
                && redPeppersCheckBox.Checked
                && onionsCheckBox.Checked))
                totalAmount -= 2;

            totalLabel.Text = "$" + totalAmount.ToString();
        }
    }
}