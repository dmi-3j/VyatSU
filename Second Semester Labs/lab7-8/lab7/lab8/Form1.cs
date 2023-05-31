using System;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            statusLabel.Text = "Введите данные для расчёта";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            double circleRadius = 0;
            double coneRadius = 0;
            double coneHeiht = 0;
            double truncConeBigRadius = 0;
            double truncConeSmallRadius = 0;
            double truncConeHeight = 0;
            if (!double.TryParse(circleRadiusField.Text, out circleRadius) || circleRadius <= 0)
            {
                MessageBox.Show("Ошибка ввода радиуса круга!");
                return;
            }
            if (!double.TryParse(coneRadiusField.Text, out coneRadius) || coneRadius <= 0)
            {
                MessageBox.Show("Ошибка ввода радиуса конуса!");
                return;
            }
            if (!double.TryParse(coneHeightField.Text, out coneHeiht) || coneHeiht <= 0)
            {
                MessageBox.Show("Ошибка ввода высоты конуса!");
                return;
            }
            if (!double.TryParse(truncConeBigRadiusField.Text, out truncConeBigRadius) || truncConeBigRadius <= 0)
            {
                MessageBox.Show("Ошибка ввода большого радиуса усеченного конуса!");
                return;
            }
            if (!double.TryParse(truncConeSmallRadiusField.Text, out truncConeSmallRadius) || truncConeSmallRadius <= 0)
            {
                MessageBox.Show("Ошибка ввода малого радиуса усеченного конуса!");
                return;
            }
            if (!double.TryParse(truncConeHeightField.Text, out truncConeHeight) || truncConeHeight <= 0)
            {
                MessageBox.Show("Ошибка ввода высоты усеченного конуса!");
                return;
            }

            IForma circle = new Circle(circleRadius);
            outputField.Text += "Круг" + Environment.NewLine +
                                  "\tРадиус круга равен: " + circleRadius + Environment.NewLine +
                                  "\tПлощадь круга равна: " + circle.Square() + Environment.NewLine + Environment.NewLine;
            IForma cone = new Cone(coneRadius, coneHeiht);
            outputField.Text += "Конус" + Environment.NewLine +
                                  "\tРадиус конуса равен: " + coneRadius + Environment.NewLine +
                                  "\tВысота конуса равна: " + coneHeiht + Environment.NewLine +
                                  "\tПлощадь поверхности конуса равна: " + cone.FullSquare() + Environment.NewLine +
                                  "\tОбъем конуса равен: " + cone.Volume() + Environment.NewLine + Environment.NewLine;
            IForma truncCone = new TruncCone(truncConeBigRadius, truncConeSmallRadius, truncConeHeight);
            outputField.Text += "Усеченный конус" + Environment.NewLine +
                                  "\tРадиус большего основания усеченного конуса равен: " + truncConeBigRadius + Environment.NewLine +
                                  "\tРадиус меньшего основания усеченного конуса равен: " + truncConeSmallRadius + Environment.NewLine +
                                  "\tВысота усеченного конуса равна: " + truncConeHeight + Environment.NewLine +
                                  "\tПлощадь поверхности усеченного конуса равна: " + truncCone.FullSquare() + Environment.NewLine +
                                  "\tОбъем усеченного конуса равен: " + truncCone.Volume() + Environment.NewLine + Environment.NewLine;
            statusLabel.Text = "Вычисления выполнены успешно. Ознакомьтесь с результатами";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputField.Clear();
            statusLabel.Text = "Введите данные для расчёта";
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void calculateMenuItem_Click(object sender, EventArgs e)
        {
            calculateButton_Click(sender, e);
        }

        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.ShowDialog();
        }
    }
}
