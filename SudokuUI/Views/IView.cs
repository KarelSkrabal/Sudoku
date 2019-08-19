using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuUI.Views
{
    public interface IView
    {
        Dictionary<Tuple<int, int>, TextBox> board { get; set; }
        List<int> puzzleIds { set; }
        int selectedIndex { get; }
        int[,] cellValues { get; }

        event EventHandler<EventArgs> Clear;
        event EventHandler<EventArgs> Show;
        event EventHandler<EventArgs> LoadData;
        event EventHandler<EventArgs> Solve;        
    }
}
