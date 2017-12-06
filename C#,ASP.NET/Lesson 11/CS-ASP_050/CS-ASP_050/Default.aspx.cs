using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_050
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = "";

            List<Car> cars = new List<Car>() {
                new Car { Make = "BMW", Model = "528i", Year = 2010, Color = "White" },
                new Car { Make = "BMW", Model = "745li", Year = 2005, Color = "Black" },
                new Car { Make = "Ford", Model = "Escape", Year = 2008, Color = "White" }
            };

            /*
            for (int i = 0; i < cars.Count; i++)
            {
                result += cars.ElementAt(i).FormatDetailsForDisplay();
            }
            */

            foreach (Car car in cars)
            {
                result += car.FormatDetailsForDisplay();
            }

            resultLabel.Text = result;
        }
    }
}