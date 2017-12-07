using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                initialReels(spinReel);
                ViewState.Add("PlayersMoney", 100);
                displayPlayersMoney();
            }
        }
        
        private void initialReels(Func<string> spinReel)
        {
            string[] reels = new string[] { spinReel(), spinReel(), spinReel() };
            displayImages(reels);
        }
        
        protected void pullButton_Click(object sender, EventArgs e)
        {
            int bet = 0;
            if (!int.TryParse(betTextBox.Text, out bet)) return;
            int winnings = pullLever(bet);
            displayResult(bet, winnings);
            adjustPlayersMoney(bet, winnings);
            displayPlayersMoney();
        }
        
        private int pullLever(int bet)
        {
            string[] reels = new string[] { spinReel(), spinReel(), spinReel() };
            displayImages(reels);
            int multiplier = evaluateSpin(reels);
            return bet * multiplier;
        }

        private string spinReel()
        {
            string[] images = new string[] { "Bar", "Bell", "Cherry", "Clover", "Diamond", "HorseShoe", "Lemon", "Orange", "Plum", "Seven", "Strawberry", "Watermelon" };
            return images[random.Next(12)];
        }

        private int evaluateSpin(string[] reels)
        {
            if (isLoseBar(reels)) return 0;
            if (isSevenJackpot(reels)) return 100;
            int multiplier = 0;
            if (isCherryWinner(reels, out multiplier)) return multiplier;
            return 0;
        }

        private void adjustPlayersMoney(int bet, int winnings)
        {
            int playersMoney = int.Parse(ViewState["PlayersMoney"].ToString());
            playersMoney -= bet;
            playersMoney += winnings;
            ViewState["PlayersMoney"] = playersMoney;
        }

        // Lose Bar
        private bool isLoseBar(string[] reels)
        {
            if (reels[0] == "Bar" || reels[1] == "Bar" || reels[2] == "Bar")
                return true;
            else
                return false;
        }

        // 7 Jackpot
        private bool isSevenJackpot(string[] reels)
        {
            if (reels[0] == "Seven" && reels[1] == "Seven" && reels[2] == "Seven")
                return true;
            else
                return false;
        }

        // Win Cherry
        private bool isCherryWinner(string[] reels, out int multiplier)
        {
            multiplier = determineMultiplier(reels);
            if (multiplier > 0) return true;
            return false;
        }

        private int determineMultiplier(string[] reels)
        {
            int cherryCount = determineCherryCount(reels);
            if (cherryCount == 1) return 2;
            if (cherryCount == 2) return 3;
            if (cherryCount == 3) return 4;
            return 0;
        }

        private int determineCherryCount(string[] reels)
        {
            int cherryCount = 0;
            if (reels[0] == "Cherry") cherryCount++;
            if (reels[1] == "Cherry") cherryCount++;
            if (reels[2] == "Cherry") cherryCount++;
            return cherryCount;
        }

        // Displays

        private void displayImages(string[] reels)
        {
            Image1.ImageUrl = "/Images/" + reels[0] + ".png";
            Image2.ImageUrl = "/Images/" + reels[1] + ".png";
            Image3.ImageUrl = "/Images/" + reels[2] + ".png";
        }

        private void displayPlayersMoney()
        {
            moneyLabel.Text = String.Format("Player's Money: {0:C}", ViewState["PlayersMoney"]);
        }

        private void displayResult(int bet, int winnings)
        {
            if (winnings > 0)
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, winnings);
            else
                resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", bet);
        }
    }
}