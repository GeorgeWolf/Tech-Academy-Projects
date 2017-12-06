using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_049
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = "";

            /*
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            cars.Add("V1", new Car { Make = "BMW", Model = "528i", Year = 2010, Color = "Black" });
            cars.Add("V2", new Car { Make = "BMW", Model = "745li", Year = 2005, Color = "Black" });
            cars.Add("V3", new Car { Make = "Ford", Model = "Escape", Year = 2008, Color = "While" });
            */

            Dictionary<string, Car> cars = new Dictionary<string, Car>() {
                { "V1", new Car { Make = "BMW", Model = "528i", Year = 2010, Color = "Black" } },
                { "V2", new Car { Make = "BMW", Model = "745li", Year = 2005, Color = "Black" } },
                { "V3", new Car { Make = "Ford", Model = "Escape", Year = 2008, Color = "While" } }
            };

            if (cars.Remove("V1"))
                result += "Successfully removed V1<br/>";

            for (int i = 0; i < cars.Count; i++)
            {
                result += "<h2>" + cars.ElementAt(i).Key + "</h2>" 
                    + cars.ElementAt(i).Value.FormatDetailsForDisplay();
            }
            

            /*
            Car v2;
            if (cars.TryGetValue("V2", out v2))
                result += v2.FormatDetailsForDisplay();
            */

            resultLabel.Text = result;
        }
    }
}