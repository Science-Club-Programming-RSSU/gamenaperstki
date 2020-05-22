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
using System.Windows.Forms.VisualStyles;

namespace gamenaperstki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int credit;
        int bet;
        int abc = 0;
        Random rnd = new Random();

       

        private void button1_Click(object sender, EventArgs e)
        {
            bet = Convert.ToInt32(textBox1.Text);
            valcredit.Text = Convert.ToString(credit);
            rnd.Next(0, 3);
            int win = rnd.Next(1, 4);
            

                if (credit < bet)  
                {
                    MessageBox.Show("Ставка не может быть больше чем ваши кредиты");
                }


            if (credit >= bet & bet > 0 & abc>0)
            {
                if (win == abc)
                {
                    label4.Text = Convert.ToString(win);
                    credit = credit + (bet * 3);
                    label6.Text = "Победа";
                    valcredit.Text = Convert.ToString(credit);
                }
                else
                {
                    label4.Text = Convert.ToString(win);
                    label6.Text = "Проигрышь";
                    credit = credit - bet;
                    valcredit.Text = Convert.ToString(credit);
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            abc = 1;
            label5.Text = Convert.ToString(abc);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            abc = 2;
            label5.Text = Convert.ToString(abc);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            abc = 3;
            label5.Text = Convert.ToString(abc);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                FileStream load = new FileStream("D:\\credits.txt", FileMode.Open);
                StreamReader read = new StreamReader(load);
                valcredit.Text = read.ReadToEnd();
                load.Close();
                string path = @"D:\\credits.txt";
                File.Delete(path);
            }

            catch
            {
                StreamWriter sw = new StreamWriter("D:\\credits.txt", true, System.Text.Encoding.UTF8);
                sw.WriteLine("1000");
                valcredit.Text = "1000";
                sw.Close();
                string path = @"D:\\credits.txt";
                File.Delete(path);
            }


            credit = Convert.ToInt32(valcredit.Text);


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter a = new StreamWriter("D:\\credits.txt", true, System.Text.Encoding.UTF8);
            a.WriteLine(credit);
            a.Close();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            valcredit.Text = "1000";
            credit = 1000;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
                      
        }
    }
}
