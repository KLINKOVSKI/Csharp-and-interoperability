using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon_v1
{
    public class Dice
    {
        private Random random;

        public Dice(Random random)
        {
            this.random = new Random();
        }

        public (int, int) Roll()
        {
            int die1 = random.Next(1, 7);
            int die2 = random.Next(1, 7);
            return (die1, die2);
        }
    }
}
