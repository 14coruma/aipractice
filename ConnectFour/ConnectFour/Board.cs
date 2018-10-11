using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    /*
     * Class for a Connect Four Board
     */
    class Board
    {
        public List<List<int>> myPieces;
        public int myPlayersTurn;
         
        /// Empty constructor - Creates empy board
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

  
        /// Constructor from 2D list
        public Board(List<List<int>> pieces)
        {
            myPlayersTurn = 1;
            myPieces = new List<List<int>>(pieces);
        }

        /// Board to nice string
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

    /*
     * Tests for Connect Four Board
     */
    class BoardTests
    {
        public void TestMethod1()
        {
            Console.WriteLine("Testing Board Class:");

            Console.Write("\t* Empty Board constructor");
            Board b1 = new Board();
            Debug.Assert(b1.myPieces.Count == 6);
            Debug.Assert(b1.myPieces[0].Count == 7);
            Debug.Assert(b1.myPlayersTurn == 1);
            Debug.Assert(b1.myPieces[0][0] == 0);
            Debug.Assert(b1.myPieces[5][6] == 0);
            Console.WriteLine(" -- Passed!");

            Console.Write("\t* Board constructor from 2D list");
            List<List<int>> pieces = new List<List<int>>();
            for (int row = 0; row < 6; row++)
            {
                pieces.Add(new List<int>());
                for (int col = 0; col < 7; col++)
                {
                    if (col == 0)
                        pieces[row].Add((row % 2) + 1);
                    else
                        pieces[row].Add(0);
                }
            }
            Board b2 = new Board(pieces);
            Debug.Assert(b2.myPieces.Count == 6);
            Debug.Assert(b2.myPieces[0].Count == 7);
            Debug.Assert(b2.myPlayersTurn == 1);
            Debug.Assert(b2.myPieces[0][0] == 1);
            Debug.Assert(b2.myPieces[5][6] == 0);
            Console.WriteLine(" -- Passed!");

            Console.WriteLine("\t* Board.ToString()");
            Console.WriteLine(b2.ToString());
            Console.WriteLine("\t  If it looks good... -- Passed!");

            //Console.Write("\t* Board.");
            
            //Console.WriteLine(" -- Passed!");
        }
    }
}
