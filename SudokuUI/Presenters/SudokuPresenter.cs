using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuUI.Views;


namespace SudokuUI.Presenters
{
    class SudokuPresenter
    {
        IPuzzle puzzleView;

        public SudokuPresenter(IPuzzle view)
        {
            puzzleView = view;
        }
        
    }
}
