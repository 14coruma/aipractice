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
            BoardTests b = new BoardTests();
            b.TestMethod1();

            Console.WriteLine("All tests passed!");

            Console.ReadLine();
        }
    }
}
