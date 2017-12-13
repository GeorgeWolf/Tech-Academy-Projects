using CustomExceptions.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions.Domain
{
    public class GameActions
    {
        // In the past, some have tried return codes.
        // That is generally frowned upon because
        // return codes are like magic numbers ...
        // they are hard to check at compile time.
        // DO NOT DO THIS:
        // public int Battle(Character attacker, Character defender)
        // {
        //   ...
        //   if (successful) return 0;
        //   else return 66;
        //   ...
        // }

        public static void Battle(Character attacker, Character defender)
        {
            if (attacker.HitPoints <= 0)
                throw new CharacterAlreadyDeadException("Attacker");


            if (defender.HitPoints <= 0)
                throw new CharacterAlreadyDeadException("Defender");

            Random random = new Random();
            int attackValue = random.Next(100);

            defender.HitPoints -= attackValue;

        }
    }
}
