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
        List<int> puzzleIds { set; }
        int selectedIndex { get; }

        event EventHandler<EventArgs> Clear;
        event EventHandler<EventArgs> Show;
        event EventHandler<EventArgs> LoadData;

        Dictionary<Tuple<int, int>, TextBox> board { get; set; }
    }
}
