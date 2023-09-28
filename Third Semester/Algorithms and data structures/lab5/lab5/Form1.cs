using System;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double fNum;
        double sNum;
        int op;
        double result;
        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (!double.TryParse(textBox1.Text, out sNum))
                {
                    textBox1.Text = "Ошибка";
                    return;
                }
            }
            switch (op)
            {
                case 1:
                    result = fNum + sNum;
                    Console.WriteLine(result);
                    textBox1.Text = result.ToString();
                    break;
                case 2:
                    result = fNum - sNum;
                    textBox1.Text = result.ToString();
                    break;
                case 3:
                    result = fNum * sNum;
                    textBox1.Text = result.ToString();
                    break;
                case 4:
                    if (sNum == 0)
                    {
                        textBox1.Text = "Ошибка";
                        return;
                    }
                    result = fNum / sNum;
                    textBox1.Text = result.ToString();
                    break;
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;
            
            switch (buttonText)
            {
                case "+":
                    op = 1;
                    textBox1.Focus();  
                    break;
                case "-":
                    op = 2;
                    textBox1.Focus();
                    break;
                case "*":
                    op = 3;
                    textBox1.Focus();
                    break;
                case "/":
                    op = 4;
                    textBox1.Focus();
                    break;
                case "←":
                    if(textBox1.Text.Length > 0)
                    {
                        textBox1.Text = textBox1.Text.Remove(textBox1.TextLength-1,1);
                    }
                    return;
                case "C":
                    sNum = 0;
                    fNum = 0;
                    result = 0;
                    textBox1.Text = "0";
                    op = -1;
                    textBox1.Focus();
                    return;
            }
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (!double.TryParse(textBox1.Text, out fNum))
                {
                    textBox1.Text = "Ошибка";
                    return;
                }
                textBox1.Clear();
            }
        }
    }
}
