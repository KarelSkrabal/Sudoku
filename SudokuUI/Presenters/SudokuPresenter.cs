using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public SudokuPresenter(IView view)
        {
            puzzleView = view;
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
        
    }
}
