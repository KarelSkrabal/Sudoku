using SudokuUI.Presenters;
using SudokuUI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuUI
{
    public partial class frmMain : Form, IView
    {
        SudokuPresenter presenter;

        Dictionary<Tuple<int, int>, TextBox> board = new Dictionary<Tuple<int, int>, TextBox>();
        Dictionary<Tuple<int, int>, TextBox> IView.board { get => board; set => board = value; }
        public List<int> puzzleIds { set => cbGames.DataSource = value; }
        public int selectedIndex { get => cbGames.SelectedIndex; }

        public event EventHandler<EventArgs> Clear;
        public event EventHandler<EventArgs> Show;
        public event EventHandler<EventArgs> LoadData;

        public frmMain()
        {
            InitializeComponent();

            initBoard();

            commonTextBoxProperties();
        }



        private void initBoard()
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    TextBox tbx = this.Controls.Find("textBox" + Convert.ToString(r) + Convert.ToString(c), true).FirstOrDefault() as TextBox;
                    if (tbx == null)
                    {
                        throw new Exception("TextBoxes on the form are not correct");
                    }
                    else
                    {
                        board.Add(new Tuple<int, int>(r, c), tbx);
                    }
                }
            }
        }

        private void commonTextBoxProperties()
        {
            foreach (var cell in board)
            {
                cell.Value.Text = Convert.ToString(0);
                cell.Value.TextChanged += new EventHandler(textBoxProperty);
                cell.Value.Enter += new EventHandler(textBoxProperty);
            }
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        private void textBoxProperty(object sender, EventArgs e)
        {
            Regex regularExpression = new Regex(@"^[0-9]$");
            if (!regularExpression.IsMatch(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = string.Empty;
            }

            HideCaret(((TextBox)sender).Handle);
        }

       
        private void frmMain_Shown(object sender, EventArgs e)
        {
            Show(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear(this, EventArgs.Empty);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            presenter = new SudokuPresenter(this);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear(this, EventArgs.Empty);
        }

        private void cbGames_SelectedIndexChanged(object sender, EventArgs e)
        {        
            LoadData(this, EventArgs.Empty);
        }
    }
}
