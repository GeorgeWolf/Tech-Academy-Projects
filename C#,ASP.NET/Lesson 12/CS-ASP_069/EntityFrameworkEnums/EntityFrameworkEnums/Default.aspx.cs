using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntityFrameworkEnums
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new FakeDecksEntities();
            var products = db.Products;

            string result = "";

            foreach (var product in products)
            {
                result += String.Format("<p>{0} {1} {2}</p>", 
                    product.Name, 
                    product.ProductType, 
                    product.Color);
            }

            resultLabel.Text = result;
        }
    }

    /*
    public enum Color
    {
        Black,
        Red,
        Silver
    }
    */

    public enum ProductType
    {
        Longboard,
        Skateboard,
        Helmet
    }
}