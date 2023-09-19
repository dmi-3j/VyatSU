using System;

using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Double.TryParse(textBox1.Text, out double X)) 
            {
                MessageBox.Show("Некорреткное значение X");
                return;
            }
            if (!Double.TryParse(textBox2.Text, out double Y))
            {
                MessageBox.Show("Некорреткное значение Y");
                return;
            }
            if (!Double.TryParse(textBox3.Text, out double Z))
            {
                MessageBox.Show("Некорреткное значение Z");
                return;
            }
            if ((X != Y) && (Y != Z) && (X!= Z))
            {
                double sum = X + Y + Z;
              
                if (sum < 1)
                {
                    X = (Y + Z) / 2;
                    textBox4.Text = "X = " + X.ToString();
                }
                else
                {
                    if (X<Y)
                    {
                        X = Y - Z;
                        textBox4.Text = "X = " + X.ToString();
                    }
                    else
                    {
                        Y = X - Z;
                        textBox4.Text = "Y = " + Y.ToString();
                    }
                }
            }

        }
    }
}
