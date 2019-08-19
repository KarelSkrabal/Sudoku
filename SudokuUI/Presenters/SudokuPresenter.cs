using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver;
using SudokuUI.Views;


namespace SudokuUI.Presenters
{
    public interface ISudokuGame
    {
        List<Puzzle> GetById(int id);
    }
    public class SudokuPresenter : ISudokuGame
    {
        private IView puzzleView;
        private ISudoku sudokuSolver;

        public SudokuPresenter(IView view, ISudoku sudoku)
        {
            puzzleView = view;
            sudokuSolver = sudoku;
            Initialize();
        }

        public SudokuPresenter()
        {

        }

        private void Initialize()
        {
            puzzleView.Clear += Clear;
            puzzleView.Show += Show;
            puzzleView.LoadData += Load;
            puzzleView.Solve += Solve;
        }

        private void Clear(object sender, EventArgs e)
        {
            foreach (var cell in puzzleView.board)
            {
                cell.Value.Text = Convert.ToString(0);
            }
        }

        private void Show(object sender, EventArgs e)
        {
            using (var puzzles = new PuzzleContext())
            {
                puzzleView.puzzleIds = puzzles.PuzzleCells.Select(p => p.puzzleId).Distinct().ToList<int>();
            }
        }

        private void Load(object sender, EventArgs e)
        {
            foreach (var cell in GetById(puzzleView.selectedIndex))
            {
                Tuple<int, int> key = new Tuple<int, int>(cell.row, cell.col);
                puzzleView.board[key].Text = Convert.ToString(cell.value);
            }
        }

        public List<Puzzle> GetById(int id)
        {
            using(var puzzle = new PuzzleContext())
            {
                return puzzle.PuzzleCells.Where(p => p.puzzleId == id).ToList();
            }
        }

        private void Solve(object sender, EventArgs e)
        {
            int[,] values = puzzleView.cellValues;
            sudokuSolver.SolveSudoku(values);

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    Tuple<int, int> key = new Tuple<int, int>(r, c);
                    puzzleView.board[key].Text = values[r,c].ToString();
                }
            }
        }
    }
}
