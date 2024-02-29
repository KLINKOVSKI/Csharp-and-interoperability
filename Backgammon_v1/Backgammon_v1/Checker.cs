using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon_v1
{
    public class Checker
    {
        private string color;
        private int position;

        public string Color { get => color; set => color = value; }
        public int Position { get => position; set => position = value; }

        public Checker(string color, int position)
        {
            this.color = color;
            this.position = position;
        }

        public void Move(Spike destination)
        {
            //move the checker to the specified spike
        }

        public bool IsHomeBoard()
        {
            //check if the checker is in the home board
            return false;
        }

        
    }
}
