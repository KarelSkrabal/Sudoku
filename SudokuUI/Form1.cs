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
    public partial class frmMain : Form
    {
        Dictionary<Tuple<int, int>, TextBox> board = new Dictionary<Tuple<int, int>, TextBox>();

        public frmMain()
        {
            InitializeComponent();

            initBoard();

            foreach(var cell in board)
            {
                cell.Value.Text = Convert.ToString(0);
                cell.Value.TextChanged += new EventHandler(textBoxProperty);
                cell.Value.Enter += new EventHandler(textBoxProperty);
            }
           
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
