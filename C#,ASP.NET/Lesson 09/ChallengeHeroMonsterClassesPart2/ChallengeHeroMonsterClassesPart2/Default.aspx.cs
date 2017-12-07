using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Dice
            Dice dice = new Dice();

            // Hero
            Character hero = new Character();
            hero.Name = "Pradopte (Hero)";
            hero.Health = 150;
            hero.DamageMaximum = 20;
            hero.AttackBonus = true;

            // Monster
            Character monster = new Character();
            monster.Name = "Chupacabra (Monster)";
            monster.Health = 100;
            monster.DamageMaximum = 30;
            monster.AttackBonus = false;

            // Bonus Attack
            if (hero.AttackBonus)
                monster.Defend(hero.Attack(dice));
            if (monster.AttackBonus)
                hero.Defend(monster.Attack(dice));

            // Battle
            while (hero.Health > 0 && monster.Health > 0)
            {
                monster.Defend(hero.Attack(dice));
                hero.Defend(monster.Attack(dice));

                displayStats(hero);
                displayStats(monster);
            }

            displayResult(hero, monster);
        }

        // Display

        private void displayStats(Character character)
        {
            resultLabel.Text += String.Format("<p>Name: {0}<br />Health: {1}<br />DamageMaximum {2}<br />AttackBonus: {3}<br /></p>",
                character.Name,
                character.Health,
                character.DamageMaximum,
                character.AttackBonus);
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.Health <= 0 && opponent2.Health <= 0)
                resultLabel.Text += String.Format("<p>Both {0} and {1} has fallen<p>", opponent1.Name, opponent2.Name);
            else if (opponent1.Health <= 0)
                resultLabel.Text += String.Format("{0} defeated {1}", opponent2.Name, opponent1.Name);
            else
                resultLabel.Text += String.Format("{0} defeated {1}", opponent1.Name, opponent2.Name);
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice dice)
        {
            dice.Sides = this.DamageMaximum;
            return dice.Roll();
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }

    class Dice
    {
        public int Sides { get; set; }

        Random random = new Random();
        public int Roll()
        {
            return random.Next(1, this.Sides + 1);
        }
    }
}