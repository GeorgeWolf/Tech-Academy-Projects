using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MegaChallengeWar
{
    public class Deck
    {
        private List<Card> _deck;
        private Random _random;
        private StringBuilder _sb;

        public Deck()
        {
            _deck = new List<Card>();
            _random = new Random();
            _sb = new StringBuilder();

            string[] colors = new string[] {
                " of <span style='color:blue;font-weight:bolder;'>Clubs</span>",
                " of <span style='color:blue;font-weight:bolder;'>Diamonds</span>",
                " of <span style='color:red;font-weight:bolder;'>Hearts</span>",
                " of <span style='color:red;font-weight:bolder;'>Spades</span>" };
            string[] kinds = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var color in colors)
            {
                foreach (var kind in kinds)
                {
                    _deck.Add(new Card() { Color = color, Kind = kind });
                }
            }
        }

        public string Deal(Player player1, Player player2)
        {
            while (_deck.Count > 0)
            {
                dealCard(player1);
                dealCard(player2);
            }
            return _sb.ToString();
        }

        private void dealCard(Player player)
        {
            Card card = _deck.ElementAt(_random.Next(_deck.Count));
            player.Cards.Add(card);
            _deck.Remove(card);

            _sb.Append("<br/>");
            _sb.Append(player.Name);
            _sb.Append(" is dealt the ");
            _sb.Append(card.Kind);
            _sb.Append(card.Color);
        }
    }
}