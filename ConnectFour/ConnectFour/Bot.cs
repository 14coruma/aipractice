using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class Bot
    {
        Stopwatch stopwatch = new Stopwatch();

        /// Find best move given a game Board object
        public int getMove(Board board)
        {
            // Begin timing
            stopwatch.Start();

            // Iterate until out of time
            int depth = 0;
            int lastMove = -1;
            int move = -1;
            while (stopwatch.ElapsedMilliseconds < 2000)
            {
                lastMove = move;
                Random r = new Random();
                move = r.Next(0, 7);
            }

            stopwatch.Reset();
            return lastMove;
        }
    }
}
