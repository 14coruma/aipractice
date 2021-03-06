﻿using System;
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
        public int getMove(Board b)
        {
            // Begin timing
            stopwatch.Reset();
            stopwatch.Start();

            // Iterate until out of time
            int depth = 0;
            int lastMove = -1;
            int move = -1;
            Board board = new Board(b);
            while (stopwatch.ElapsedMilliseconds < 2000 && depth <= 100)
            {
                lastMove = move;
                move = alphabeta(board, depth, int.MinValue, int.MaxValue).Item1;
                depth++;
            }

            Console.WriteLine("Bot search depth: " + depth);
            Console.WriteLine("Bot's move: " + lastMove);

            return lastMove;
        }

        /// Alpha-beta algorithm
        public Tuple<int, int> alphabeta(Board board, int depth, int a, int b)
        {
            int bestMove = -1;
            int val;
            int newVal;

            if (depth == 0 || board.myGameOver)
                return Tuple.Create(-1, evaluate(board));
            if (board.myPlayersTurn == 1) // P1 is maximizing player
            {
                val = int.MinValue;
                foreach (int move in board.moveSpace())
                {
                    if (stopwatch.ElapsedMilliseconds > 2000 - 1)
                        break;
                    Board tempBoard = new Board(board);
                    tempBoard.makeMove(move);
                    newVal = alphabeta(tempBoard, depth - 1, a, b).Item2;
                    if (newVal > val)
                    {
                        val = newVal;
                        bestMove = move;
                    }
                    a = Math.Max(a, val);
                    if (a >= b)
                        break;
                }
            } else // P2 is minimizing player
            {
                val = int.MaxValue;
                foreach (int move in board.moveSpace())
                {
                    if (stopwatch.ElapsedMilliseconds > 2000 - 1)
                        break;
                    Board tempBoard = new Board(board);
                    tempBoard.makeMove(move);
                    newVal = alphabeta(tempBoard, depth - 1, a, b).Item2;
                    if (newVal < val)
                    {
                        val = newVal;
                        bestMove = move;
                    }
                    b = Math.Min(b, val);
                    if (a >= b)
                        break;
                }
            }
            return Tuple.Create(bestMove, val);
        }

        /// Evaluation function
        public int evaluate(Board board)
        {
            // TODO: Make this better
            if (board.myWinner != 0)
                return (board.myWinner * 2 - 3) * -1;
            else
                return 0;
        }
    }
}
