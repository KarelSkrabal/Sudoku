using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SudokuUI.Views
{
    public interface IView
    {
        Dictionary<Tuple<int, int>, TextBox> board { get; set; }
        List<int> puzzleIds { set; }
        int selectedIndex { get; }
        int[,] cellValues { get; }
        string processTime { /*get;*/ set; }
        bool isDirty { get; set; }

        event EventHandler<EventArgs> Clear;
        event EventHandler<EventArgs> Show;
        event EventHandler<EventArgs> LoadData;
        event EventHandler<EventArgs> Solve;
        event EventHandler<EventArgs> Save;
    }
}
