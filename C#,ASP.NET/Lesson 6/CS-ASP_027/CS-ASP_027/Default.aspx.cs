using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_027
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random random = new Random();

            int heroHealth = 30;
            int monsterHealth = 30;

            string result = "";

            // Hero gets bonus first attack 
            monsterHealth -= random.Next(1, 100);

            int round = 0;
            result += "<br />Round: " + round;
            result += String.Format("<br />Hero attacks first, leaving monster with {0} health.",
                monsterHealth);


            // Need battle logic here!

            /*
            while (heroHealth > 0 && monsterHealth > 0)
            {
                int heroDamage = random.Next(1, 10);
                int monsterDamage = random.Next(1, 20);

                monsterHealth -= heroDamage;
                heroHealth -= monsterDamage;

                result += "<br />Round: " + ++round;
                result += String.Format("<br />Hero causes {0} damage, leaving monster with {1} health.", heroDamage, monsterHealth);
                result += String.Format("<br />Monster causes {0} damage, leaving hero with {1} health.", monsterDamage, heroHealth);
            }
            */

            do
            {
                int heroDamage = random.Next(1, 10);
                int monsterDamage = random.Next(1, 20);

                monsterHealth -= heroDamage;
                heroHealth -= monsterDamage;

                result += "<br />Round: " + ++round;
                result += String.Format("<br />Hero causes {0} damage, leaving monster with {1} health.", heroDamage, monsterHealth);
                result += String.Format("<br />Monster causes {0} damage, leaving hero with {1} health.", monsterDamage, heroHealth);
            } while (heroHealth > 0 && monsterHealth > 0);

            if (heroHealth > 0)
            {
                result += "<br />Hero wins!";
            }
            else
            {
                result += "<br /> Monster wins!";
            }


            resultLabel.Text = result;
        }
    }
}