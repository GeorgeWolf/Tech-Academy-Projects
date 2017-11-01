using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] asset = new string[0];
                double[] rigged = new double[0];
                double[] subterfuge = new double[0];

                ViewState.Add("Asset", asset);
                ViewState.Add("Rigged", rigged);
                ViewState.Add("Subterfuge", subterfuge);
            }
        }

        protected void addAssetButton_Click(object sender, EventArgs e)
        {
            string[] asset = (string[])ViewState["Asset"];
            double[] rigged = (double[])ViewState["Rigged"];
            double[] subterfuge = (double[])ViewState["Subterfuge"];

            Array.Resize(ref asset, asset.Length + 1);
            Array.Resize(ref rigged, rigged.Length + 1);
            Array.Resize(ref subterfuge, subterfuge.Length + 1);

            int newestItemAsset = asset.GetUpperBound(0);
            int newestItemRigged = rigged.GetUpperBound(0);
            int newestItemSubterfuge = subterfuge.GetUpperBound(0);

            asset[newestItemAsset] = assetTextBox.Text;
            rigged[newestItemRigged] = double.Parse(riggedTextBox.Text);
            subterfuge[newestItemSubterfuge] = double.Parse(subterfugeTextBox.Text);

            ViewState["Asset"] = asset;
            ViewState["Rigged"] = rigged;
            ViewState["Subterfuge"] = subterfuge;

            resultLabel.Text = String.Format("Total Elections Rigged: {0}<br />Average Acts of Subterfuge per Asset: {1:N2}<br />(Last Asset you Added: {2})",
                rigged.Sum(),
                subterfuge.Average(),
                asset.Last());

            assetTextBox.Text = "";
            riggedTextBox.Text = "";
            subterfugeTextBox.Text = "";
        }
    }
}