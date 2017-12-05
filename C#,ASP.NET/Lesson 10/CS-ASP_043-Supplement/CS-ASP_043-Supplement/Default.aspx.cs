using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_043_Supplement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            printDetails(car);

            Car car2 = new Car("Sports Package");
            printDetails(car2);

            Car car3 = new Car("Sports Package", "Yellow");
            printDetails(car3);
        }

        private void printDetails(Car car)
        {
            resultLabel.Text += String.Format("<p>{0} {1} {2} {3} {4} {5:C}</p>", car.Make, car.Model, car.Year, car.Color, car.OptionsPackage, car.RetailPrice);
        }
    }
}