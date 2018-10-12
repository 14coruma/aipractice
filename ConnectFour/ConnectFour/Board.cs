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
        public int myWinner = 0;
        public bool myGameOver;
         
        /// Empty constructor - Creates empy board
        public Board()
        {
            myPlayersTurn = 1;
            myGameOver = false;
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
            myGameOver = false;
            myPieces = new List<List<int>>(pieces);
        }

        /// Copy constructor
        public Board(Board b)
        {
            myPlayersTurn = b.myPlayersTurn;
            myGameOver = b.myGameOver;
            myWinner = b.myWinner;
            myPieces = new List<List<int>>();
            for (int row = 0; row < 6; row++)
            {
                myPieces.Add(new List<int>());
                for (int col = 0; col < 7; col++)
                {
                    myPieces[row].Add(b.myPieces[row][col]);
                }
            }
        }

        /// Checks if a move is legal
        public bool legalMove(int pos)
        {
            if (pos < 0 || pos > 6 || myPieces[0][pos] > 0)
                return false;
            else
                return true;
        }

        /// Check for a winning combination, returning player who one or zero otherwise
        public int checkGameOver()
        {
            // Horizontal
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int player = myPieces[row][col];
                    if (player != 0 && player == myPieces[row][col+1] && player == myPieces[row][col+2] && player == myPieces[row][col+3])
                        return player;
                }
            }

            // Vertical
            for (int col = 0; col < 7; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    int player = myPieces[row][col];
                    if (player != 0 &&  player == myPieces[row + 1][col] && player == myPieces[row + 2][col] && player == myPieces[row + 3][col])
                        return player;
                }
            }

            // Diagonals (rising)
            for (int row = 3; row < 6; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int player = myPieces[row][col];
                    if (player != 0 &&  player == myPieces[row - 1][col + 1] && player == myPieces[row - 2][col + 2] && player == myPieces[row - 3][col + 3])
                        return player;
                }
            }            
            
            // Diagonals (falling)
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int player = myPieces[row][col];
                    if (player != 0 &&  player == myPieces[row + 1][col + 1] && player == myPieces[row + 2][col + 2] && player == myPieces[row + 3][col + 3])
                        return player;
                }
            }            

            return 0;
        }

        /// Makes a move 
        /// If illegal, ends game and returns winner
        /// If results in a winning combo, ends game and returns winner
        public int makeMove(int pos)
        {
            if (!legalMove(pos)) // Check if legal move
            {
                myGameOver = true;
                myWinner = (myPlayersTurn % 2) + 1;
                return myWinner;
            }

            // Drop piece into position
            int row = 0;
            while (row < 5 && myPieces[row+1][pos] == 0)
            {
                row++;
            }
            myPieces[row][pos] = myPlayersTurn;

            if (checkGameOver() != 0) // Game over?
            {
                myGameOver = true;
                myWinner = myPlayersTurn;
                return myPlayersTurn;
            }

            myPlayersTurn = (myPlayersTurn % 2) + 1;
            return 0;
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
            Console.Write(b2);
            Console.WriteLine("\t  If it looks good... -- Passed!");

            Console.Write("\t* Board.legalMove(int pos)");
            Debug.Assert(b1.legalMove(3));
            Debug.Assert(b2.legalMove(1));
            Debug.Assert(!b2.legalMove(0));
            Console.WriteLine(" -- Passed!");

            Console.Write("\t* Board.makeMove(int pos)");
            b2.makeMove(1);
            Debug.Assert(b2.myPieces[5][1] == 1);
            b2.makeMove(1);
            Debug.Assert(b2.myPieces[4][1] == 2);
            Debug.Assert(b2.makeMove(1) == 0);
            Debug.Assert(b2.myPieces[3][1] == 1);
            Debug.Assert(b2.makeMove(0) == 1);
            Debug.Assert(b2.myGameOver);
            Console.WriteLine(" -- Passed!");

            Console.Write("\t* Board.checkGameOver()");
            Debug.Assert(b1.checkGameOver() == 0);
            for (var i = 0; i < 3; i++)
            {
                b1.makeMove(0);
                b1.makeMove(6);
            }
            Debug.Assert(b1.checkGameOver() == 0);
            b1.makeMove(0);
            Debug.Assert(b1.checkGameOver() == 1); // Vertical win
            Board b3 = new Board();
            for (var i = 0; i < 3; i++)
            {
                b3.makeMove(i);
                b3.makeMove(6-i);
            }
            Debug.Assert(b3.checkGameOver() == 0);
            Debug.Assert(b3.makeMove(0) == 0);
            Debug.Assert(b3.makeMove(3) == 2); // Horizontal win
            Console.WriteLine(" -- Passed!");
        }
    }
}
