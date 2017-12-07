using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_028
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void fromCupsRadio_CheckedChanged(object sender, EventArgs e)
        {
            calculateCups();

            /*
            if (quantityTextBox.Text.Trim().Length == 0)
                return;

            double quantity = 0.0;
            if (!Double.TryParse(quantityTextBox.Text, out quantity))
                return;

            resultLabel.Text = "The number of cups: " + quantity.ToString();
            */
        }

        protected void fromPintsRadio_CheckedChanged(object sender, EventArgs e)
        {
            calculateCups();

            /*
            if (quantityTextBox.Text.Trim().Length == 0)
                return;

            double quantity = 0.0;
            if (!Double.TryParse(quantityTextBox.Text, out quantity))
                return;

            double cups = quantity * 2.0;
            resultLabel.Text = "The number of cups: " + cups.ToString();
            */
        }

        protected void fromQuartsRadio_CheckedChanged(object sender, EventArgs e)
        {
            calculateCups();

            /*
            if (quantityTextBox.Text.Trim().Length == 0)
                return;

            double quantity = 0.0;
            if (!Double.TryParse(quantityTextBox.Text, out quantity))
                return;

            double cups = quantity * 4.0;
            resultLabel.Text = "The number of cups: " + cups.ToString();
            */
        }

        protected void fromGallonsRadio_CheckedChanged(object sender, EventArgs e)
        {
            calculateCups();

            /*
            if (quantityTextBox.Text.Trim().Length == 0)
                return;

            double quantity = 0.0;
            if (!Double.TryParse(quantityTextBox.Text, out quantity))
                return;

            double cups = quantity * 16.0;
            resultLabel.Text = "The number of cups: " + cups.ToString();
            */
        }

        protected void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            calculateCups();
        }

        private void calculateCups()
        {
            if (quantityTextBox.Text.Trim().Length == 0)
                return;

            double quantity = 0.0;
            if (!Double.TryParse(quantityTextBox.Text, out quantity))
                return;

            double cups = 0.0;

            if (fromCupsRadio.Checked) cups = quantity;
            else if (fromPintsRadio.Checked) cups = quantity * 2;
            else if (fromQuartsRadio.Checked) cups = quantity * 4;
            else if (fromGallonsRadio.Checked) cups = quantity * 16;

            resultLabel.Text = "The number of cups: " + cups.ToString();
        }
    }
}