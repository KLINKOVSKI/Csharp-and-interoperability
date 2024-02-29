using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon_v1
{
    public class Score
    {
        private int player1Score;
        private int player2Score;

        public int Player1Score { get => player1Score; set => player1Score = value; }
        public int Player2Score { get => player2Score; set => player2Score = value; }

        public Score(int player1Score, int player2Score) 
        { 
            this.player1Score = player1Score;
            this.player2Score = player2Score;
        }

        public void UpdateScore(Player player, int points)
        {
            
        }

        public void DisplayScore()
        {
            
        }
    }
}
