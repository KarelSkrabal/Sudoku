using SudokuSolver;
using SudokuUI.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace SudokuUI.Presenters
{
    public class SudokuPresenter
    {
        private IView puzzleView;
        private ISudoku sudokuSolver;

        public SudokuPresenter(IView view, ISudoku sudoku)
        {
            puzzleView = view;
            sudokuSolver = sudoku;
            Initialize();
        }

        private void Initialize()
        {
            puzzleView.Clear += Clear;
            puzzleView.Show += Show;
            puzzleView.LoadData += Load;
            puzzleView.Solve += Solve;
            puzzleView.Save += Save;
        }

        private void Clear(object sender, EventArgs e)
        {
            foreach (var cell in puzzleView.board)
            {
                cell.Value.Text = "0";
            }
        }

        private void Show(object sender, EventArgs e)
        {
            using (var db = new PuzzleContext())
            {
                List<int> ids = db.PuzzleCells.Select(p => p.puzzleId).Distinct().OrderBy(p => p).ToList();
                puzzleView.puzzleIds = ids;
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

        private List<Puzzle> GetById(int id)
        {
            using (var db = new PuzzleContext())
            {
                return db.PuzzleCells.Where(p => p.puzzleId == id).ToList();
            }
        }

        private async void Solve(object sender, EventArgs e)
        {
            int[,] values = puzzleView.cellValues;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            await Task.Run(() => sudokuSolver.SolveSudoku(values));
            stopWatch.Stop();
            puzzleView.processTime = stopWatch.ElapsedMilliseconds.ToString() + " ms";

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    Tuple<int, int> key = new Tuple<int, int>(r, c);
                    puzzleView.board[key].Text = values[r, c].ToString();
                }
            }
        }

        private void Save(object sender, EventArgs e)
        {
            int lastPuzzleId = GetLastPuzzleId();
            int newPuzzleId = ++lastPuzzleId;

            using (var db = new PuzzleContext())
            {
                List<Puzzle> cells = new List<Puzzle>();
                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        cells.Add( new Puzzle() { row = r, col = c, puzzleId = newPuzzleId, value = puzzleView.cellValues[r, c] } );
                    }
                }
                db.PuzzleCells.AddRange(cells);
                db.SaveChanges();
            }

            UpdatePuzzleIds();
        }


        private void UpdatePuzzleIds()
        {
            using (var db = new PuzzleContext())
            {
                List<int> ids = db.PuzzleCells.Select(p => p.puzzleId).Distinct().OrderBy(p => p).ToList();
                puzzleView.puzzleIds = ids;
            }                
        }

        private int GetLastPuzzleId()
        {
            using (var db = new PuzzleContext())
            {
                return db.PuzzleCells.OrderByDescending(p => p.puzzleId).FirstOrDefault().puzzleId;
            }
        }
    }
}
