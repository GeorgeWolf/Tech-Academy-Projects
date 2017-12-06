using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_048
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = "";

            /*
            Car car1 = new Car("BMW", "528i", 2010, "Black");
            Car car2 = new Car("BMW", "745li", 2005, "Black");
            Car car3 = new Car("Ford", "Escape", 2008, "White");

            List<Car> cars = new List<Car>();

            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            */

            /*
            List<Car> cars = new List<Car>();

            cars.Add(new Car { Make = "BMW", Model = "528i", Year = 2010, Color = "White" });
            cars.Add(new Car { Make = "BMW", Model = "745li", Year = 2005, Color = "Black" });
            cars.Add(new Car { Make = "Ford", Model = "Escape", Year = 2008, Color = "White" });
            */

            List<Car> cars = new List<Car>()
            {
                new Car{Make="BMW", Model="528i", Color="Black", Year=2010},
                new Car{Make="BMW", Model="745li", Color="Black", Year=2005},
                new Car{Make="Ford", Model="Escape", Color="White", Year=2008}
            };

            for (int i = 0; i < cars.Count; i++)
            {
                result += cars.ElementAt(i).FormatDetailsForDisplay();
            }


            resultLabel.Text = result;
        }
    }
}