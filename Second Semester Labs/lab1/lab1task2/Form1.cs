using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int m, n;
        private int FindIndexOfLineWithMin(int[,] array)
        {
            int index = 0;
            int min = array[0, 0];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        index = i;
                    }
                }
            }
            return index;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            button1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            if (numericUpDown3.Value > numericUpDown4.Value) { 
                label9.Text = "Минимум не может быть больше максимума!";
                return; 
            }
            m = Convert.ToInt32(numericUpDown1.Value);
            n = Convert.ToInt32(numericUpDown2.Value);
            button1.Enabled = false;
            int[,] array = new int[m, n];
            Random random = new Random();
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = m;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = random.Next(Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown4.Value));
                    dataGridView1.Rows[i].Cells[j].Value = array[i, j];
                }
            }
            int row = FindIndexOfLineWithMin(array);
            if (row == 0)
            {
                label9.Text = "Минимальный элемент находится в первой строке.";
                return;
            }
            int[,] resultArray = new int[m, n];
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                if (i == row)
                {
                    continue;
                }
                for (int j = 0; j < n; j++)
                {
                    resultArray[count, j] = array[i, j];
                }
                count++;
            }
            int[] tempArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                tempArray[i] = array[row - 1, i];
            }
            Array.Sort(tempArray);
            for (int i = 0; i < n; i++)
            {
                resultArray[m - 1, i] = tempArray[i];
            }
            dataGridView2.ColumnCount = n;
            dataGridView2.RowCount = m;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = resultArray[i, j];
                }
            }
            label9.Text = "Удалена " + (row +1) + " строка. Отсортирована " + row +" строка.";

        }
    }
}