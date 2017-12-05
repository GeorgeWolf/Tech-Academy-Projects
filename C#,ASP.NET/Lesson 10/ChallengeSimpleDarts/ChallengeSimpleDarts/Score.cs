using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Score
    {
        public static void ScoreDart(Player player, Dart dart)
        {
            doubleTriple(player, dart);
            bullsEye(player, dart);
        }

        private static void doubleTriple(Player player, Dart dart)
        {
            int score = 0;

            if (dart.IsDouble) score = dart.Score * 2;
            else if (dart.IsTriple) score = dart.Score * 3;

            player.Score += score;
        }

        private static void bullsEye(Player player, Dart dart)
        {
            int score = 0;

            if (dart.IsInner && dart.Score == 0) score = 50;
            else if (dart.Score == 0) score = 25;

            player.Score += score;
        }
    }
}