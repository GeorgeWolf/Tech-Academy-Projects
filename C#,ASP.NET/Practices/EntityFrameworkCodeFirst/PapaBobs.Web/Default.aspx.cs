using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapaBobs.DTO;
using PapaBobs.DTO.Enums;

namespace PapaBobs.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void recalculateTotalCost(object sender, EventArgs e)
        {
            if (sizeDropDownList.SelectedValue == String.Empty) return;
            if (crustDropDownList.SelectedValue == String.Empty) return;
            var order = buildOrder();

            try
            {
                totalLabel.Text = Domain.PizzaPriceManager.CalculateCost(order).ToString("C");
            }
            catch
            {
                // Swallow the error
            }
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                validationText("Please enter a name.");
                return;
            }

            if (addressTextBox.Text.Trim().Length == 0)
            {
                validationText("Please enter an address.");
                return;
            }

            if (zipTextBox.Text.Trim().Length == 0)
            {
                validationText("Please enter zip code.");
                return;
            }

            if (phoneTextBox.Text.Trim().Length == 0)
            {
                validationText("Please enter phone number.");
                return;
            }

            try
            {
                var order = buildOrder();
                Domain.OrderManager.CreateOrder(order);
                Response.Redirect("success.aspx");
            }
            catch (Exception ex)
            {
                validationText(ex.Message + "  this is it ");
                return;
            }

        }

        private SizeType determineSize()
        {
            SizeType size;
            if (!Enum.TryParse(sizeDropDownList.SelectedValue, out size))
                throw new Exception("Could not determine Pizza size.");

            return size;
        }

        private CrustType determineCrust()
        {
            CrustType crust;
            if (!Enum.TryParse(crustDropDownList.SelectedValue, out crust))
                throw new Exception("Could not determine Pizza crust.");

            return crust;
        }

        private PaymentType determinePaymentType()
        {
            PaymentType paymentType;
            if (cashRadioButton.Checked)
                paymentType = PaymentType.Cash;
            else
                paymentType = PaymentType.Credit;

            return paymentType;
        }

        private OrderDTO buildOrder()
        {
            var order = new OrderDTO();
            order.Size = determineSize();
            order.Crust = determineCrust();
            order.Sausage = sausageCheckBox.Checked;
            order.Pepperoni = pepperoniCheckBox.Checked;
            order.Onions = onionsCheckBox.Checked;
            order.GreenPeppers = greenPeppersCheckBox.Checked;
            order.Name = nameTextBox.Text;
            order.Address = addressTextBox.Text;
            order.Zip = zipTextBox.Text;
            order.Phone = phoneTextBox.Text;
            order.PaymentType = determinePaymentType();

            return order;
        }

        private void validationText(string text)
        {
            validationLabel.Text = text;
            validationLabel.Visible = true;
        }
    }
}