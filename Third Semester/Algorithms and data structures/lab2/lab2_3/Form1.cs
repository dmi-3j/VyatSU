using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab2_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (radioButton2.Checked)
            {
                count++;
                groupBox1.BackColor = Color.Green;
            }
            else
            {
                groupBox1.BackColor = Color.Red;
            }
            if (radioButton5.Checked) 
            {
                count++;
                groupBox2.BackColor = Color.Green;
            }
            else
            {
                groupBox2.BackColor = Color.Red;
            }
            if ((checkBox1.Checked) &&  (checkBox2.Checked))
            {
                count++;
                groupBox3.BackColor = Color.Green;
            }
            else
            {
                groupBox3.BackColor = Color.Red;
            }
            if ((checkBox5.Checked) && (checkBox7.Checked))
            {
                count++;
                groupBox4.BackColor = Color.Green;
            }
            else
            {
                groupBox4.BackColor = Color.Red;
            }
            if (count == 1) MessageBox.Show("Правильных ответов: " + count, "Оценка: " + 2);
            if (count == 2) MessageBox.Show("Правильных ответов: " + count, "Оценка: " + 3);
            if (count == 3) MessageBox.Show("Правильных ответов: " + count, "Оценка: " + 4);
            if (count == 4) MessageBox.Show("Правильных ответов: " + count, "Оценка: " + 5);
        }
    }
}
