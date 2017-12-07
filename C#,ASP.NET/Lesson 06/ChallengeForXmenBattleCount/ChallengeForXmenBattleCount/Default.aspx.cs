using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeForXmenBattleCount
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Wolverine fewest battles
            //Phoenix most battles

            string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Phoenix", "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus" };
            int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13 };

            string result = "";

            // Solution 1
            /*
            int maxIndex = 0;
            int minIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] > numbers[maxIndex])
                {
                    maxIndex = i;
                }

                if(numbers[i] < numbers[minIndex])
                {
                    minIndex = i;
                }
            }

            result = String.Format("Most battles belong to: {0} (Value: {1})" +
                "<br />Least battles belong to: {2} (Value: {3})",
                names[maxIndex],
                numbers[maxIndex],
                names[minIndex],
                numbers[minIndex]);
            */

            // Solution 2
            int maxIndex = numbers.ToList().IndexOf(numbers.Max());
            int minIndex = numbers.ToList().IndexOf(numbers.Min());

            result = String.Format("Most battles belong to: {0} (Value: {1})" +
                "<br />Least battles belong to: {2} (Value: {3})",
                names[maxIndex],
                numbers[maxIndex],
                names[minIndex],
                numbers[minIndex]);
            

            resultLabel.Text = result;
        }
    }
}