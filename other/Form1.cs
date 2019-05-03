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
            textBox1.Text = textBox1.Text + qwe.Text;
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
            string newsum2 = MathClass.SimplifyString(newsum);
            textBox2.Text = newsum2;
        }


        private void closeDown()
        {
            this.Close();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("key prezzv " + e.KeyChar.ToString() + "' pressed.");
            int keyInt = (int)e.KeyChar;
            Debug.WriteLine( keyInt);
            if (keyInt == 8)
            {
                delScreen();
            }
            if (keyInt == 27)
            {
                closeDown();
            }
            if (e.KeyChar == 's')
            {
                doEquals();
            }
            if (e.KeyChar == 'o')
            {
                textBox1.Text = textBox1.Text + "(";
            }
            if (e.KeyChar == 'p')
            {
                textBox1.Text = textBox1.Text + ")";
            }
            if (e.KeyChar == 'n')
            {
                textBox1.Text = textBox1.Text + "+";
            }
            if (e.KeyChar == 'm')
            {
                textBox1.Text = textBox1.Text + "-";
            }
            if (e.KeyChar == 'd')
            {
                textBox1.Text = textBox1.Text + "/";
            }
            if (e.KeyChar == 'x')
            {
                textBox1.Text = textBox1.Text + "*";
            }
            if (e.KeyChar == 'a')
            {
                clearScreen();
            }
            if ( keyInt >= 48 && keyInt <= 57 )
            {
                textBox1.Text = textBox1.Text + e.KeyChar.ToString();
            }
        }



        
    }
}
