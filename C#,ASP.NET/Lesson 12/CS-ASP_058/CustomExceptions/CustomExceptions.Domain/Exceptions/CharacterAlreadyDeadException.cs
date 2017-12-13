using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions.Domain.Exceptions
{
    public class CharacterAlreadyDeadException : Exception
    {
        public string CharacterName { get; set; }

        public CharacterAlreadyDeadException(string characterName)
        {
            CharacterName = characterName;
        }
    }
}
