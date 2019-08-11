using System;

namespace SudokuSolver
{
    //https://www.geeksforgeeks.org/sudoku-backtracking-7/
    //https://hackernoon.com/sudoku-and-backtracking-6613d33229af
    //https://qqwing.com/download.html
    //http://www.sudokuessentials.com/easy_sudoku.html
    /*
        r > 0 && r < 3		r > 0 && r < 3		r > 0 && r < 3
        c > 0 && c < 3		c > 2 && c < 6		c > 5 && c < 9

        r > 2 && r < 6		r > 2 && r < 6		r > 2 && r < 6
        c > 0 && c < 3		c > 2 && c < 6		c > 5 && c < 9

        r > 5 && r < 9		r > 5 && r < 9		r > 5 && r < 9
        c > 0 && c < 3		c > 2 && c < 6		c > 5 && c < 9
     */
    public class Sudoku
    {
        public bool isValidCol(int[,] board, int boardSize, int rowTested, int colTested, int valueTested)
        {
            for (int r = 0; r < boardSize; r++)
            {
                if (r == rowTested)
                {
                    continue;
                }

                if (board[r, colTested] == valueTested)
                {
                    return false;
                }
            }
            return true;
        }

        public bool isValidRow(int[,] board, int boardSize, int rowTested, int colTested, int valueTested)
        {
            for (int c = 0; c < boardSize; c++)
            {
                if (c == colTested)
                {
                    continue;
                }

                if (board[rowTested, c] == valueTested)
                {
                    return false;
                }
            }
            return true;
        }

        public bool isValidSubgridValue(int[,] board, int boardSize, int rowTested, int colTested, int valueTested)
        {
            return false;
        }

        public int getRowFirstEmptyCell(int[,] board, int boardSize)
        {
            int ret = -1;
            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    if (board[r, c] == 0)
                    {
                        return r;
                    }
                }
            }

            return ret;
        }

        public int getColFirstEmptyCell(int[,] board, int boardSize)
        {
            int ret = -1;
            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    if (board[r, c] == 0)
                    {
                        return c;
                    }
                }
            }

            return ret;
        }

        public void printBoard(int[,] board, int boardSize)
        {
            //todo - check for value from interval 3-9 

            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    Console.Write(board[r, c].ToString() + "|");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
