using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class Game
    {
        static void Main(string[] args)
        {
            Board b = new Board();
            while (!b.myGameOver)
            {
                Console.Write(b);
                Console.Write("Player " + b.myPlayersTurn + "'s move: ");
                int move = -1;
                Int32.TryParse(Console.ReadLine(), out move);
                b.makeMove(move);
            }

            Console.WriteLine("Player " + b.myWinner + " won!");
            Console.ReadLine();
        }
    }
}
