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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regex regularExpression = new Regex(@"^[1-9]$");
            if (regularExpression.IsMatch(textBox1.Text))
            {
                ;
            }
            else
            {
                textBox1.Text = "";
            }
            HideCaret(textBox1.Handle);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Regex regularExpression = new Regex(@"^[1-9]$");
            if (regularExpression.IsMatch(textBox2.Text))
            {
                ;
            }
            else
            {
                textBox2.Text = "";
            }
            HideCaret(textBox2.Handle);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            HideCaret(textBox1.Handle);
        }

  

        private void Form1_Shown(object sender, EventArgs e)
        {
            HideCaret(textBox2.Handle);
            HideCaret(textBox1.Handle);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            HideCaret(textBox2.Handle);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
