using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon_v1
{
    public class Player
    {
        private string color;
        private List<Checker> checkersOnBoard;

        public string Color { get => color; set => color = value; }
        public List<Checker> CheckersOnBoard { get => checkersOnBoard; set => checkersOnBoard = value; }

        public Player(string color, List<Checker> checkersOnBoard)
        {
            this.color = color;
            this.checkersOnBoard = new List<Checker>();
        }

        public void RollDice()
        {
            //simulate rolling dice
        }

        public bool HasWon()
        {
            //check if the player has won
            return false;
        }
    }
}
