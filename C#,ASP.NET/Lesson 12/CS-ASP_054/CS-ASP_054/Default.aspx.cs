using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_054
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string result = "";
            int switchExpression = 4;

            switch (switchExpression)
            {
                case 0:
                case 1:
                    result += "Case 0 or 1<br />";
                    break;
                case 2:
                    result += "Case 2<br />";
                    goto case 1;
                //return;
                //result += "Unreachable";
                case 7 - 4:
                    result += "Case 3<br />";
                    break;
                case 4:
                    result += "Case 4<br />";
                    throw new Exception();
                default:
                    result += "Default (Optional)<br />";
                    break;
            }
            */

            var hero = new Character();
            hero.Name = "Elric";
            hero.Type = CharacterType.Fighter;

            string result = "";

            switch (hero.Type)
            {
                case CharacterType.Wizard:
                    result += "Wizard";
                    break;
                case CharacterType.Fighter:
                    result += "Fighter";
                    break;
                case CharacterType.Monster:
                    result += "Monster";
                    break;
                default:
                    break;
            }

            resultLabel.Text = result;
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public CharacterType Type { get; set; }
    }

    public enum CharacterType
    {
        Wizard,
        Fighter,
        Monster
    }
}