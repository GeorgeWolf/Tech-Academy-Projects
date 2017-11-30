using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hero
            Character hero = new Character();
            hero.Name = "Pradopte";
            hero.Health = 200;
            hero.DamageMaximum = 20;
            hero.AttackBonus = true;

            // Monster
            Character monster = new Character();
            monster.Name = "Chupacabra";
            monster.Health = 100;
            monster.DamageMaximum = 30;
            monster.AttackBonus = false;

            // Battle
            int damage = hero.Attack();
            monster.Defend(damage);

            damage = monster.Attack();
            hero.Defend(damage);

            displayStats(hero);
            displayStats(monster);
        }

        private void displayStats(Character character)
        {
            resultLabel.Text += String.Format("<p>Name: {0}<br />Health: {1}<br />DamageMaximum {2}<br />AttackBonus: {3}<br /></p>",
                character.Name, 
                character.Health, 
                character.DamageMaximum, 
                character.AttackBonus);
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack()
        {
            Random random = new Random();
            int damage = random.Next(this.DamageMaximum);
            return damage;
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }
}