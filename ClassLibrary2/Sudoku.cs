using System;

namespace SudokuSolver
{
    //https://www.geeksforgeeks.org/sudoku-backtracking-7/
    //https://hackernoon.com/sudoku-and-backtracking-6613d33229af
    //https://qqwing.com/download.html
    //http://www.sudokuessentials.com/easy_sudoku.html
    /*
     * Math.Truncate(num);
        r > 0 && r < 3		r > 0 && r < 3		r > 0 && r < 3
        c > 0 && c < 3		c > 2 && c < 6		c > 5 && c < 9

        r > 2 && r < 6		r > 2 && r < 6		r > 2 && r < 6
        c > 0 && c < 3		c > 2 && c < 6		c > 5 && c < 9

        r > 5 && r < 9		r > 5 && r < 9		r > 5 && r < 9
        c > 0 && c < 3		c > 2 && c < 6		c > 5 && c < 9

        r >= 0 && r <= 2		r >= 0 && r <= 2    r >= 0 && r <= 2
        c >= 0 && c <= 2		c >= 3 && c <= 5	c >= 6 && c <= 8

        r >= 3 && r <= 5		r >= 3 && r <= 5	r >= 3 && r <= 5
        c >= 0 && c <= 2		c >= 3 && c <= 5	c >= 6 && c <= 8

        r >= 6 && r <= 8		r >= 6 && r <= 8    r >= 6 && r <= 8
        c >= 0 && c <= 2 		c >= 3 && c <= 5	c >= 6 && c <= 8

        3,6 => 3 / delka = 1 => 1 * delka = 3
            => 6 / delka = 2 => 2 * delka = 6
        0,4 => 0 / delka = 0 => 0 * delka = 0
            => 4 / delka = 1 => 1 * delka = 3
        5,2 => 5 / delka = 1 5%3=2
            => 2 / delka = 0
        4,4
        7,8
        i=0,1,2
        i*delka,i*delka+2

        delka = 3
        for(r=
            for(c
                
     */
    public class Sudoku
    {
        /*
            {3, 0, 6, 5, 0, 8, 4, 0, 0},
            {5, 2, 0, 0, 0, 0, 0, 0, 0},
            {0, 8, 7, 0, 0, 0, 0, 3, 1},
            {0, 0, 3, 0, 1, 0, 0, 8, 0},
            {9, 0, 0, 8, 6, 3, 0, 0, 5},
            {0, 5, 0, 0, 9, 0, 6, 0, 0},
            {1, 3, 0, 0, 0, 0, 2, 5, 0},
            {0, 0, 0, 0, 0, 0, 0, 7, 4},
            {0, 0, 5, 2, 0, 6, 3, 0, 0}
         */
        public bool SolveSudoku(int[,] board)
        {
            int row = getRowFirstEmptyCell(board, 9);
            int col = getColFirstEmptyCell(board, 9);

            if(row == null && col == null)
            {
                return true;
            }
            for(int i=1;i<=9;i++)
            {
                ;
                board[row, col] = i;
                bool validRow = isValidRow(board, 9, row, col, i);
                bool validCol = isValidCol(board, 9, row, col, i);
                bool validSubgrid = isValidSubgridValue(board, 9, row, col, i);
                if(validCol && validRow && validSubgrid)
                {
                    if(SolveSudoku(board))
                    {
                        printBoard(board,9);
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }              
            }

            return false;
        }

        public bool isValidSubgridValue(int[,] board, int boardSize, int rowTested, int colTested, int valueTested)
        {
            boardSize = (int)Math.Sqrt(boardSize);
            int rowLowerBound = (int)Math.Truncate(rowTested/(decimal)boardSize) * boardSize;
            int rowUpperBound = ((int)Math.Truncate(rowTested / (decimal)boardSize) * boardSize)+2;
            int colLowerBound = (int)Math.Truncate(colTested / (decimal)boardSize) * boardSize;
            int colUpperBound = ((int)Math.Truncate(colTested / (decimal)boardSize) * boardSize) + 2;
            ;
            for(int row = rowLowerBound;row <= rowUpperBound; row++)
            {
                for(int col = colLowerBound; col <= colUpperBound; col++)
                {
                    if(row == rowTested && col == colTested)
                    {
                        continue;
                    }

                    if(board[row,col] == valueTested)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
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
