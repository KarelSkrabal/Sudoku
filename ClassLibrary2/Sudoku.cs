using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    public enum BOARD_ITEM { row, col}
    

    public class Sudoku : ISudoku
    {
        public readonly int boardSize = 9;
        private readonly int[] allValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public bool SolveSudoku(int[,] board)
        {
            int row = -1;
            int col = -1;

            row = getFirstEmptyCell(board,BOARD_ITEM.row);
            col = getFirstEmptyCell(board,BOARD_ITEM.col);
            if (row == -1 && col == -1)
            {
                return true;
            }

            var rowPossibleValues = PossibleRowValues(board, row, col);
            var colPossibleValues = PossibleColValues(board, row, col);
            var subgridPossibleValues = PossibleSubgridValues(board, row, col);
            var possibleValues = rowPossibleValues.Intersect(colPossibleValues).Intersect(subgridPossibleValues).ToList<int>();
            
            foreach (var value in possibleValues)
            {
                board[row, col] = value;
                bool validRow = isValidRow(board, row, col, value);
                bool validCol = isValidCol(board, row, col, value);
                bool validSubgrid = isValidSubgridValue(board, row, col, value);
                if (validCol && validRow && validSubgrid)
                {
                    if (SolveSudoku(board))
                    {
                        return true;
                    }
                    else
                    {
                        board[row, col] = 0;
                    }
                }
            }

            return false;
        }

        public int getLowerBound(int rowOrColTested)
        {
            return (int)Math.Truncate(rowOrColTested / Math.Sqrt(boardSize)) * (int)Math.Sqrt(boardSize);
        }

        public int getUpperBound(int rowOrColTested)
        {
            return ((int)Math.Truncate(rowOrColTested / Math.Sqrt(boardSize)) * (int)Math.Sqrt(boardSize)) + 2;
        }

        public bool isValidSubgridValue(int[,] board, int rowTested, int colTested, int valueTested)
        {
            for (int row = getLowerBound(rowTested); row <= getUpperBound(rowTested); row++)
            {
                for (int col = getLowerBound(colTested); col <= getUpperBound(colTested); col++)
                {
                    if (row == rowTested && col == colTested)
                    {
                        continue;
                    }

                    if (board[row, col] == valueTested)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public IEnumerable<int> PossibleSubgridValues(int[,] board, int rowTested, int colTested)
        {
            int[] actualRow = new int[boardSize];
            int i = 0;
            
            for (int row = getLowerBound(rowTested); row <= getUpperBound(rowTested); row++)
            {
                for (int col = getLowerBound(colTested); col <= getUpperBound(colTested); col++)
                {
                    if (board[row, col] != 0)
                    {
                        actualRow[i] = board[row, col];
                        i++;
                    }
                }
            }
            IEnumerable<int> ret = allValues.Except(actualRow).Where((r) => r != 0);
            return ret;
        }
        public IEnumerable<int> PossibleRowValues(int[,] board, int rowTested, int colTested)
        {
            int[] actualRow = new int[boardSize];
            int i = 0;
            for (int c = 0; c < boardSize; c++)
            {
                if (board[rowTested, c] != 0)
                {
                    actualRow[i] = board[rowTested, c];
                    i++;
                }
            }
            IEnumerable<int> ret = allValues.Except(actualRow).Where((r) => r != 0);
            return ret;
        }
        public bool isValidCol(int[,] board, int rowTested, int colTested, int valueTested)
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

        public bool isValidRow(int[,] board, int rowTested, int colTested, int valueTested)
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
        public IEnumerable<int> PossibleColValues(int[,] board, int rowTested, int colTested)
        {
            int[] actualRow = new int[boardSize];
            int i = 0;
            for (int r = 0; r < boardSize; r++)
            {
                if (board[r, colTested] != 0)
                {
                    actualRow[i] = board[r, colTested];
                    i++;
                }
            }
            IEnumerable<int> ret = allValues.Except(actualRow).Where((r) => r != 0);
            return ret;
        }

        public int getFirstEmptyCell(int[,] board, BOARD_ITEM item)
        {
            int ret = -1;
            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    if (board[r, c] == 0)
                    {
                        return (item == BOARD_ITEM.row) ? r : c;
                    }
                }
            }

            return ret;
        }      
        public void printBoard(int[,] board)
        {
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
