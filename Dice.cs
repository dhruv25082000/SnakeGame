using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLadder
{
    public class Dice
    {
        private readonly int _diceCount;
        private readonly Random _random;

        public Dice(int diceCount)
        {
            _diceCount = diceCount;
            _random = new Random();
        }

        public int RollDice()
        {
            int total = 0;
            for (int i = 0; i < _diceCount; i++)
            {
                total += _random.Next(1, 7);
            }
            return total;
        }
    }
}
