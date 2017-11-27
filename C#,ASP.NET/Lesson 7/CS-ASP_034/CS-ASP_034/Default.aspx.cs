using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_034
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int heroHealth = 100;
            int monsterHealth = 100;

            displayBattleHeader();

            while (heroHealth > 0 && monsterHealth > 0)
            {
                displayRoundHeader();

                // Perform battle here!
                if (defeatEnemy(monsterHealth, 20, "Hero", "Monster", out monsterHealth))
                    lootEnemy();

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
        private bool defeatEnemy(int defenderHealth,
            int attackerDamageMax,
            string attackerName,
            string defenderName,
            out int remainingDefenderHealth)
        {
            int damage = random.Next(1, attackerDamageMax);
            remainingDefenderHealth = defenderHealth - damage;

            if (remainingDefenderHealth <= 0) return true;
            else return false;
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

        private void lootEnemy()
        {
            resultLabel.Text += "<p style='color:red;'>A magic sword and 20 gold pieces are collected from corpse.</p>";
        }

    }
}