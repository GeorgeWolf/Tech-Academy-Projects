using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_032
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int heroHealth = 100;
            int monsterHealth = 100;

            displayBattleHeader();

            // Hero gets bonus first attack
            monsterHealth = performAttack(monsterHealth, 20, "Hero", "Monster");

            while (heroHealth > 0 && monsterHealth > 0)
            {
                displayRoundHeader();

                // Perform battle here!
                heroHealth = performAttack(heroHealth, 20, "Monster", "Hero");
                monsterHealth = performAttack(monsterHealth, 20, "Hero", "Monster");

                //monsterHealth = performAttack(heroHealth, 20, "Monster", "Hero", .2, 10);
            }

            displayResult(heroHealth, monsterHealth);

        }


        private void displayBattleHeader()
        {
            resultLabel.Text += "<h3>Battle Between the Hero (you) and the Monster (bad guy)</h3>";
        }

        private void displayRoundHeader()
        {
            resultLabel.Text += "<hr /><p>Round begins ...</p>";
        }

        Random random = new Random();
        private int performAttack(
            int defenderHealth, 
            int attackerDamageMax, 
            string attackerName, 
            string defenderName,
            double criticalHitChance = .1,
            double defenderArmorBonus = 5)
        {
            int damage = random.Next(1, attackerDamageMax);
            defenderHealth -= damage;

            describeRound(attackerName, defenderName, defenderHealth);
            return defenderHealth;
        }

        private void describeRound(string attackerName, string defenderName, int defenderHealth)
        {
            if (defenderHealth <= 0)
                resultLabel.Text += String.Format("<br />{0} attacks {1} and vanquishes the {2}.", attackerName, defenderName, defenderName);
            else
                resultLabel.Text += String.Format("<br />{0} attacks {1}, leaving {2} with {3} health.", attackerName, defenderName, defenderName, defenderHealth);
        }

        private void displayResult(int heroHealth, int monsterHealth)
        {
            if (heroHealth <= 0)
                resultLabel.Text += "<h3>Monster wins!</h3>";
            else if (monsterHealth <= 0)
                resultLabel.Text += "<h3>Hero wins!</h3>";
            else
                resultLabel.Text += "<h3>They are both losers!</h3>";
        }
    }
}