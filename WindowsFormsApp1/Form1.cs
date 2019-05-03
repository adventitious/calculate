using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine("constructor fired");

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            Button qwe = (Button)sender;
            addNumber(qwe.Text);
            textBox1.Text = textBox1.Text + qwe.Text;
            button12.Focus();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button qwe = (Button)sender;
            addNumber( qwe.Text );
            button12.Focus();
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            Button qwe = (Button)sender;
            addNumber(qwe.Text);
            button12.Focus();
        }

        private void addNumber(string numberString)
        {
            textBox1.Text = textBox1.Text + numberString;
            button12.Focus();
        }
        private void addSign(string signString)
        {
            textBox1.Text = textBox1.Text + signString;
            button12.Focus();
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            doEquals();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearScreen();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            delScreen();
        }

        private void clearScreen()
        {
            textBox1.Text = "";
            textBox2.Text = "0";

        }

        private void delScreen()
        {
            string currentText = textBox1.Text;
            if (currentText.Length > 0)
            {
                currentText = currentText.Substring(0, currentText.Length - 1);
            }
            textBox1.Text = currentText;
        }

        private void doEquals()
        {
            string newsum = textBox1.Text;
            if (newsum == "")
            {
                return;
            }
            Debug.WriteLine("newsum " +  newsum);
            string newsum2 = MathClass.SimplifyString(newsum);
            textBox2.Text = newsum2;
        }

        private string GetSignFromKey( char key )
        {
            if (key == 'n')
            {
                return "+";
            }
            if (key == 'm')
            {
                return "-";
            }
            if (key == 'd')
            {
                return "/";
            }
            if (key == 'x')
            {
                return "*";
            }
            if (key == 'o')
            {
                return "(";
            }
            if (key == 'p')
            {
                return ")";
            }
            return "";
        }

        private void CloseDown()
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("key prezzv " + e.KeyChar.ToString() + "' pressed.");
            int keyInt = (int)e.KeyChar;
            Debug.WriteLine( keyInt);
            if (keyInt == 27)
            {
                CloseDown();
            }
            if (e.KeyChar == 'a')
            {
                clearScreen();
            }
            if (e.KeyChar == 's')
            {
                doEquals();
            }
            if (keyInt == 8)
            {
                delScreen();
            }
            
            if ( keyInt >= 48 && keyInt <= 57)
            {
                addNumber(e.KeyChar.ToString());
            }
            else
            {
                string sign = GetSignFromKey(e.KeyChar );
                addSign(sign);
            }
            button12.Focus();
        }
        
    }
}
