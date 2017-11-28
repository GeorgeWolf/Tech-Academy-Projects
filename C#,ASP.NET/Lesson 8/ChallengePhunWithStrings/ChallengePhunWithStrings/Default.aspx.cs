using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Reverse your name
            string name = "George Wolf";
            // In my case, the result would be:
            // floW egroeG
            
            string reversed1 = new string(name.ToCharArray().Reverse().ToArray());
            resultLabel1.Text = reversed1;
            
            // 2. Reverse this sequence:
            string names = "Luke,Leia,Han,Chewbacca";
            // When you're finished it should look like this:
            // Chewbacca,Han,Leia,Luke

            string[] namesArray1 = names.Split(',');
            Array.Reverse(namesArray1);
            resultLabel2.Text = string.Join(",", namesArray1);

            // 3. Use the sequence to create ascii art:
            // *****Luke*****
            // *****Leia*****
            // *****Han******
            // **Chewbacca***

            string result = "";
            string[] namesArray2 = names.Split(',');
            for (int i = 0; i < namesArray2.Length; i++)
            {
                int nameLength = namesArray2[i].Length;
                int stars = 14 - nameLength;
                int padLeft = stars / 2 + nameLength;
                result += namesArray2[i].PadLeft(padLeft, '*').PadRight(14, '*') + "<br />";
            }
            resultLabel3.Text = result;

            // 4. Solve this puzzle:

            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";

            // Once you fix it with string helper methods, it should read:
            // Now is the time for all good men to come to the aid of their country.

            // First solution
            int indexStart = puzzle.IndexOf("remove-me");
            int indexEnd = puzzle.IndexOf(" ZIME FOR");
            
            string puzzleRemoved = puzzle.Remove(indexStart, indexEnd - indexStart);
            string puzzleReadible = puzzleRemoved.Replace("Z", "T");
            string puzzleLowerCase = puzzleReadible.ToLower();
            string puzzleSolved = puzzleLowerCase.Replace("now", "Now");

            resultLabel4.Text = puzzleSolved;

            // Second solution
            string removeMe = "remove-me";
            int index = puzzle.IndexOf(removeMe);
            puzzle = puzzle.Remove(index, removeMe.Length);
            puzzle = puzzle.ToLower();
            puzzle = puzzle.Replace("z", "t");
            puzzle = puzzle.Remove(0, 1);
            puzzle = puzzle.Insert(0, "N");

            resultLabel5.Text = puzzle;
        }
    }
}