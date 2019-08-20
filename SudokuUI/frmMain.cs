using SudokuSolver;
using SudokuUI.Presenters;
using SudokuUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SudokuUI
{
    public partial class frmMain : Form, IView
    {
        SudokuPresenter presenter;

        Dictionary<Tuple<int, int>, TextBox> board = new Dictionary<Tuple<int, int>, TextBox>();
        Dictionary<Tuple<int, int>, TextBox> IView.board { get => board; set => board = value; }
        public List<int> puzzleIds { get => puzzleIds;
            set
            {
                cbGames.DataSource = null;
                cbGames.DataSource = value;
                cbGames.Refresh();
            }
        }
        public int selectedIndex { get => cbGames.SelectedIndex; }
        public int[,] cellValues { get => GetValuesFromForm(); }
        public string processTime { get => lbProcessTime.Text; set => lbProcessTime.Text = value; }
        public bool isDirty { get; set; }

        public event EventHandler<EventArgs> Clear;
        public event EventHandler<EventArgs> Show;
        public event EventHandler<EventArgs> LoadData;
        public event EventHandler<EventArgs> Solve;
        public event EventHandler<EventArgs> Save;

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

        private int[,] GetValuesFromForm()
        {
            int[,] boardValues = new int[9, 9];
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    TextBox tbx = this.Controls.Find("textBox" + Convert.ToString(r) + Convert.ToString(c), true).FirstOrDefault() as TextBox;
                    boardValues[r, c] = Convert.ToInt16(tbx.Text);
                }
            }
            return boardValues;
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
            isDirty = true;
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
            if (AbandonEdit() == System.Windows.Forms.DialogResult.Yes)
            {
                isDirty = false;
                Clear(this, EventArgs.Empty);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            isDirty = false;
            presenter = new SudokuPresenter(this, new Sudoku());
            cbGames.SelectedIndex = -1;
            this.ActiveControl = btnCancel;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (isDirty)
            {
                if (AbandonEdit() == System.Windows.Forms.DialogResult.Yes)
                {
                    isDirty = false;
                    Clear(this, EventArgs.Empty);
                }
            }
        }

        private void cbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            isDirty = true;
            LoadData(this, EventArgs.Empty);
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (isDirty)
            {
                Solve(this, EventArgs.Empty);
            }
        }

        private DialogResult AbandonEdit()
        {
            return MessageBox.Show("Abandon current editing?", "Abandon", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isDirty)
            {
                Save(this, EventArgs.Empty);
            }
        }
    }
}
