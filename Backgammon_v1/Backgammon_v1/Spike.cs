using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon_v1
{
    public class Spike
    {
        private int position;
        private List<Checker> checkers;

        public int Position { get => position; set => position = value; }
        public List<Checker> Checkers { get => checkers; set => checkers = value; }

        public Spike(int Position,List<Checker> Checkers)
        {
            this.checkers = new List<Checker>();
        }

        public void AddChecker(Checker checker)
        {
            Checkers.Add(checker);
        }

        public void RemoveChecker()
        {
            if (Checkers.Count > 0)
            {
                Checkers.RemoveAt(Checkers.Count - 1);
            }
        }
    }
}
