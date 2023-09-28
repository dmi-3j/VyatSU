using System;
using System.Linq;
using System.Windows.Forms;

namespace lab5_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] lines = new string[] { "один", "два", "три", "четыре", "пять", "шесть", "семь" };
        string[] newLines;

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(lines);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                newLines = richTextBox1.Text.Split(new char[] { ' ', ',', '.', ':', ';', '?', '!','\n' }).ToArray();
                listBox2.Items.AddRange(newLines);
            }
            else
            {
                MessageBox.Show("Введите текст");
                return;
            }
        }
    }
}
