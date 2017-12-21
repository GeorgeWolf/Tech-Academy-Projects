using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobs.Web
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGridView();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            var value = row.Cells[1].Text.ToString();
            var orderId = Guid.Parse(value);

            Domain.OrderManager.FinishOrder(orderId);

            refreshGridView();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 8; i < 14; i++)
            {
                e.Row.Cells[i].Visible = false;
            }

        }

        private void refreshGridView()
        {
            var orders = Domain.OrderManager.GetOrders();
            GridView1.DataSource = orders;
            GridView1.DataBind();

        }
    }
}