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
            Bot bot = new Bot();

            while (!b.myGameOver)
            {
                Console.Write(b);
                Console.WriteLine("Player " + b.myPlayersTurn + "'s move: ");
                int move = -1;
                Int32.TryParse(Console.ReadLine(), out move);
                //Random r = new Random();
                //while (!b.legalMove(move))
                //    move = r.Next(0, 7);
                b.makeMove(move);
                if (b.myGameOver)
                    break;

                Console.Write(b);
                b.makeMove(bot.getMove(b));
            }

            Console.WriteLine("Player " + b.myWinner + " won!");
            Console.ReadLine();
        }
    }
}
