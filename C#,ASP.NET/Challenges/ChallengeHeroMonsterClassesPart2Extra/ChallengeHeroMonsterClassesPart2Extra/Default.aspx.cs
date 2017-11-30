using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart2Extra
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Dice
            Dice dice = new Dice();

            // Hero
            Character hero = new Character();
            hero.Name = "Pradopte";
            hero.Health = 150;
            hero.DamageMaximum = 20;
            hero.AttackBonus = true;

            // Monster
            Character monster = new Character();
            monster.Name = "Chupacabra";
            monster.Health = 100;
            monster.DamageMaximum = 30;
            monster.AttackBonus = false;

            displayFirstEncounter(hero, monster);
            displayStats(hero);
            displayStats(monster);

            // Bonus Attack
            bonusAttack(hero, monster, dice);
            displayHealth(monster);

            // Battle
            while (hero.Health > 0 && monster.Health > 0)
            {
                // Hero Attack - Monster Defend
                characterBattle(monster, hero, dice); // characterBattle(defender, attacker, damage)
                displayHealth(monster);
                // Monster Attack - Hero Defend
                characterBattle(hero, monster, dice);
                displayHealth(hero);
            }

            // Result
            displayResult(hero, monster);
        }

        private void bonusAttack(Character hero, Character monster, Dice dice)
        {
            if (hero.AttackBonus)
                characterBattle(monster, hero, dice);
            if (monster.AttackBonus)
                characterBattle(hero, monster, dice);
        }

        private void characterBattle(Character opponent1, Character opponent2, Dice dice)
        {
            int attack = opponent2.Attack(dice);
            opponent1.Defend(attack);
            resultLabel.Text += String.Format("<p>{0} inflicted {1} damage on {2}.<br />{2} has the following stats remaining:</p>", opponent2.Name, attack, opponent1.Name);
        }

        // Display

        private void displayStats(Character character)
        {
            resultLabel.Text += String.Format("<p>Name: {0}<br />Health: {1}<br />DamageMaximum {2}<br />AttackBonus: {3}<br /><hr /></p>",
                character.Name,
                character.Health,
                character.DamageMaximum,
                character.AttackBonus);
        }

        private void displayFirstEncounter(Character opponent1, Character opponent2)
        {
            resultLabel.Text += String.Format("<p>{0} and {1} facing each other</p>", opponent1.Name, opponent2.Name);
        }

        private void displayHealth(Character character)
        {
            resultLabel.Text += String.Format("<p>Name: {0}<br />Health: {1}<hr /></p>", character.Name, character.Health);
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