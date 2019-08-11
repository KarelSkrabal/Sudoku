using SudokuSolver;
using System;

namespace SudokuCLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Sudoku sudoku = new Sudoku();

            int[,] board = new int[,]
        {
            {3, 0, 6, 5, 0, 8, 4, 0, 0},
            {5, 2, 0, 0, 0, 0, 0, 0, 0},
            {0, 8, 7, 0, 0, 0, 0, 3, 1},
            {0, 0, 3, 0, 1, 0, 0, 8, 0},
            {9, 0, 0, 8, 6, 3, 0, 0, 5},
            {0, 5, 0, 0, 9, 0, 6, 0, 0},
            {1, 3, 0, 0, 0, 0, 2, 5, 0},
            {0, 0, 0, 0, 0, 0, 0, 7, 4},
            {0, 0, 5, 2, 0, 6, 3, 0, 0}
        };

            int[,] smallBoard = new int[,]
            {
                {2, 0, 3},
                {1, 2, 3},
                {1, 0, 1}
            };
            int boardSize = Convert.ToInt16(Math.Sqrt(smallBoard.Length));
            var test = sudoku.isValidCol(smallBoard, boardSize, 0, 1, 2);
            sudoku.printBoard(smallBoard, boardSize);
            Console.WriteLine(sudoku.getColFirstEmptyCell(smallBoard, boardSize));
            Console.WriteLine(sudoku.getRowFirstEmptyCell(smallBoard, boardSize));
            Console.ReadKey();
        }

    }
}
