using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery_Players
{
    internal class Player
    {
        string name;
        int id;

        public Player(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        // Definieer dit als properties.
        public string GetName() => name;

        /// <summary>
        /// Dit is GetId.
        /// </summary>
        /// <returns>return</returns>
        public int GetId() => id;

        // Variable to store the qty of guesses
        public int qtyGuesses {  get; set; }
        // Variable to store the qty of wright guesses
        public int qtyCorrectGuesses { get; set; }
    }
}
