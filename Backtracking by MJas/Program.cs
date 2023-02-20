using System;
using System.Collections.Generic;

//Backtracking for 8H by MJas

namespace Backtracking_by_MJas
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[8, 8];

            if (!Hetmans(board, 0))
            {
                Console.WriteLine("Error");

            }

            Program.board(board);


            Console.ReadKey();
        }
        public static void board(int[,] board)
        {
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j] + "|");
                }
                Console.WriteLine();
            }
        }
        public static bool Hetmans(int[,] board, int x)   //x = our columns
        {
            if (x >= 8)
            {
                return true;   //8 column - we have solution
            }

            for (int i = 0; i < 8; i++)
            {
                if (CheckedPos(board, i, x))
                {
                    Program.board(board);
                    Console.WriteLine();
                    board[i, x] = 1; //placed hetman
                    if (Hetmans(board, x + 1))
                    {
                        return true;
                    }
                    board[i, x] = 0; //backtracking
                }
            }
            return false;
        }

        public static bool CheckedPos(int[,] board, int i, int x) //i row, x column
        {
            int o, p;

            for (o = 0; o < x; o++)    //left row
            {

                if (board[i, o] == 1)
                {
                    return false;
                }
            }
            for (o = i, p = x; o >= 0 && p >= 0; o--, p--) //przek  gora
            {
                if (board[o, p] == 1)
                {
                    return false;
                }
            }
            for (o = i, p = x; p >= 0 && o < 8; o++, p--) //przek dol
            {
                if (board[o, p] == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
