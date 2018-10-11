using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class Board
    {
        public List<List<int>> myPieces;
        public int myPlayersTurn;
         
        public Board()
        {
            myPlayersTurn = 1;
            myPieces = new List<List<int>>();
            for (int row = 0; row < 6; row++)
            {
                myPieces.Add(new List<int>());
                for (int col = 0; col < 7; col++)
                {
                    myPieces[row].Add(0);
                }
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    s += myPieces[row][col] + " ";
                }
                s += "\n";
            }

            return s;
        }
    }

    class BoardTests
    {
        public void TestMethod1()
        {
            Console.WriteLine("Testing Board Class:");

            Console.Write("\t* Board Constructor");
            Board b = new Board();
            Debug.Assert(b.myPieces.Count == 6);
            Debug.Assert(b.myPieces[0].Count == 7);
            Debug.Assert(b.myPlayersTurn == 1);
            Console.WriteLine(" -- Passed!");

            Console.WriteLine("\t* Board.ToString()");
            Console.WriteLine(b.ToString());
            Console.WriteLine("\t  If it looks good... -- Passed!");

            //Console.Write("\t* Board.");
            
            //Console.WriteLine(" -- Passed!");
        }
    }
}
