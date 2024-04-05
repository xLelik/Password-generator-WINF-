using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace LameApp
{
    public partial class Form1 : Form
    {

        bool drag = false;
        Point start_point = new Point(0, 0);


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }



        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(52, 138, 167);
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(18, 18, 18);
        }

        private void buttonCloose_MouseEnter(object sender, EventArgs e)
        {
            buttonCloose.BackColor = Color.Red;
        }

        private void buttonCloose_MouseLeave(object sender, EventArgs e)
        {
            buttonCloose.BackColor = Color.FromArgb(18, 18, 18);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            int len_pass = (int)numericUpDown1.Value;
            int quantity = (int)numericUpDown2.Value;
            bool symbols = checkBox1.Checked;
            Random rand = new Random();
            Random type = new Random();

            for (int j = 0; j < quantity; j++)
            {
                for (int i = 0; i < len_pass; i++)
                {
                    if (symbols == false)
                    {
                        int value = rand.Next(0, 9);
                        richTextBox1.Text = richTextBox1.Text + value.ToString();
                        continue;
                    }

                    if (symbols == true)
                    {
                        char value = (char)rand.Next(33, 125);
                        if (value == '\\' || value == '/')
                        {
                            value = (char)rand.Next(33, 91);
                            richTextBox1.Text += value.ToString();
                        }
                        else
                        {
                            richTextBox1.Text += value.ToString();
                        }
                        continue;
                    }
                }
                richTextBox1.Text += "\n";
            }
        }

        
    }
}

