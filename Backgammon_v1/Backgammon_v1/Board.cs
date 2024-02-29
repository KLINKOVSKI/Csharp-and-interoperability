using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon_v1
{
    public class Board
    {
        private List<Spike> spikes;
        

        public Board(List<Spike> spikes)
        { 
            //initialize the board with spikes and checkers
            this.spikes = spikes;
            InitializeBoard();
        }

        public List<Spike> Spikes { get => spikes; set => spikes = value; }

        public void InitializeBoard()
        {
            //create and arrange spikes and checkers
        }

        public void MoveChecker(Spike origin, Spike destination)
        {
            //move a checker from one spike to another
        }

    
       
    }
}
