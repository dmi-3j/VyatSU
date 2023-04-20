using System;
using System.Windows.Forms;

namespace lab3_individual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void сохранитьВсеГрафикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            сохранитьГрафикСортировкиToolStripMenuItem_Click(sender, e);
            сохранитьГрафикОбменовПузЦВыборРToolStripMenuItem_Click(sender, e);
            сохранитьГрафикСравненийШеллаПузРToolStripMenuItem_Click(sender, e);
            сохранитьГрафикОбменовШеллаПузРToolStripMenuItem_Click(sender, e);
            сохранитьГрафикОценкиЭффективностиToolStripMenuItem_Click(sender, e);
        }
        private void сохранитьГрафикСортировкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveGr1 = new SaveFileDialog())
            {
                saveGr1.Title = "Сохранить график как ...";
                saveGr1.Filter = "*.jpg|*.jpg";
                saveGr1.AddExtension = true;
                saveGr1.FileName = "График количества сравнений Пуз(Ц) - Выбор(Р)";
                if (saveGr1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    chart1.SaveImage(saveGr1.FileName,
                   System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
            }
        }
        private void сохранитьГрафикОбменовПузЦВыборРToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveGr1 = new SaveFileDialog())
            {
                saveGr1.Title = "Сохранить график как ...";
                saveGr1.Filter = "*.jpg|*.jpg";
                saveGr1.AddExtension = true;
                saveGr1.FileName = "График количества обменов Пуз(Ц) - Выбор(Р)";
                if (saveGr1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    chart2.SaveImage(saveGr1.FileName,
                   System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
            }
        }
        private void сохранитьГрафикСравненийШеллаПузРToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveGr1 = new SaveFileDialog())
            {
                saveGr1.Title = "Сохранить график как ...";
                saveGr1.Filter = "*.jpg|*.jpg";
                saveGr1.AddExtension = true;
                saveGr1.FileName = "График количества сравнений Шелла - Пуз(Р)";
                if (saveGr1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    chart3.SaveImage(saveGr1.FileName,
                   System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
            }
        }
        private void сохранитьГрафикОбменовШеллаПузРToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveGr1 = new SaveFileDialog())
            {
                saveGr1.Title = "Сохранить график как ...";
                saveGr1.Filter = "*.jpg|*.jpg";
                saveGr1.AddExtension = true;
                saveGr1.FileName = "График количества обменов Шелла - Пуз(Р)";
                if (saveGr1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    chart4.SaveImage(saveGr1.FileName,
                   System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
            }
        }
        private void сохранитьГрафикОценкиЭффективностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveGr1 = new SaveFileDialog())
            {
                saveGr1.Title = "Сохранить график как ...";
                saveGr1.Filter = "*.jpg|*.jpg";
                saveGr1.AddExtension = true;
                saveGr1.FileName = "График оценки эффективности";
                if (saveGr1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    chart5.SaveImage(saveGr1.FileName,
                   System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
            }
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lab3_individual.Form2 help = new Form2();
            help.ShowDialog();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void output_textBox(int[] out_arr, int n) //вывод массива в textBox
        {
            for (int i = 0; i < n; i++)
            { textBox1.Text += out_arr[i] + " "; }
            textBox1.Text += Environment.NewLine;
        }
        public void output_dataGridView(int count, int sr, int obm, int vid_sort, int effective)// вывод в таблицу кол-ва сравнений и обменов
        {
            dataGridView1.Rows[count].Cells[vid_sort].Value = sr;
            dataGridView2.Rows[count].Cells[vid_sort].Value = obm;
            dataGridView3.Rows[count].Cells[vid_sort].Value = effective;
        }
        public int EffectiveCount(int sr, int obm)
        {
            int result = 0;
            result = sr + obm / 3;
            return result;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            button1.Enabled = true;
            textBox1.Text = "";
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart3.Series[1].Points.Clear();
            chart4.Series[0].Points.Clear();
            chart4.Series[1].Points.Clear();
            chart5.Series[0].Points.Clear();
            chart5.Series[1].Points.Clear();
            chart5.Series[2].Points.Clear();
            chart5.Series[3].Points.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView2.ColumnCount = 5;
            dataGridView3.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Размер";
            dataGridView2.Columns[0].HeaderText = "Размер";
            dataGridView3.Columns[0].HeaderText = "Размер";
            dataGridView1.Columns[1].HeaderText = "Пузырек (Р)";
            dataGridView2.Columns[1].HeaderText = "Пузырек (Р)";
            dataGridView3.Columns[1].HeaderText = "Пузырек (Р)";
            dataGridView1.Columns[2].HeaderText = "Шелла";
            dataGridView2.Columns[2].HeaderText = "Шелла";
            dataGridView3.Columns[2].HeaderText = "Шелла";
            dataGridView1.Columns[3].HeaderText = "Пузырек (Ц)";
            dataGridView2.Columns[3].HeaderText = "Пузырек (Ц)";
            dataGridView3.Columns[3].HeaderText = "Пузырек (Ц)";
            dataGridView1.Columns[4].HeaderText = "Выбор (Р)";
            dataGridView2.Columns[4].HeaderText = "Выбор (Р)";
            dataGridView3.Columns[4].HeaderText = "Выбор (Р)";
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[1].BorderWidth = 3;
            chart2.Series[0].BorderWidth = 3;
            chart2.Series[1].BorderWidth = 3;
            chart3.Series[0].BorderWidth = 3;
            chart3.Series[1].BorderWidth = 3;
            chart4.Series[0].BorderWidth = 3;
            chart4.Series[1].BorderWidth = 3;
            chart5.Series[0].BorderWidth = 3;
            chart5.Series[1].BorderWidth = 3;
            chart5.Series[2].BorderWidth = 3;
            chart5.Series[3].BorderWidth = 3;
            button1.Enabled = false;
      
            if (numericUpDown4.Value > numericUpDown5.Value || numericUpDown1.Value > numericUpDown2.Value)
            { MessageBox.Show("Макс значение не м.б. меньше мин значения!"); return; }
            int count = 0, n, sr = 0, obm = 0, effective = 0;
            for (n = Convert.ToInt32(numericUpDown1.Value); n <= Convert.ToInt32(numericUpDown2.Value);n+=Convert.ToInt32(numericUpDown3.Value))
            {
                int[] base_arr = new int[n];
                Random rand = new Random();
                for (int j = 0; j < n; j++)
                {
                    base_arr[j] = rand.Next(Convert.ToInt32(numericUpDown4.Value), Convert.ToInt32(numericUpDown5.Value));
                }

                textBox1.Text += "Исходный массив " + Environment.NewLine;
                output_textBox(base_arr, n);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[count].Cells[0].Value = n;
                dataGridView2.Rows.Add();
                dataGridView2.Rows[count].Cells[0].Value = n;
                dataGridView3.Rows.Add();
                dataGridView3.Rows[count].Cells[0].Value = n;

                ArraySort bubbleRecursive = new ArraySort();
                bubbleRecursive.a = (int[])(base_arr.Clone());
                sr = 0; obm = 0;
                bubbleRecursive.BubbleSortRecursive(bubbleRecursive.a, n, ref obm,ref sr);
                effective = EffectiveCount(sr, obm);
                textBox1.Text += "Сортировка пузырьком рекурсия: " + Environment.NewLine;
                output_textBox(bubbleRecursive.a, n);
                output_dataGridView(count, sr, obm, 1, effective);
                chart3.Series[1].Points.AddXY(n, sr);
                chart4.Series[1].Points.AddXY(n, obm);
                chart5.Series[3].Points.AddXY(n, effective);

                ArraySort shellSort = new ArraySort();
                shellSort.a = (int[])(base_arr.Clone());
                sr = 0; obm = 0;
                shellSort.ShellSort(shellSort.a, n, ref sr, ref obm);
                effective = EffectiveCount(sr, obm);
                textBox1.Text += "Сортировка шелла: " + Environment.NewLine;
                output_textBox(shellSort.a, n);
                output_dataGridView(count, sr, obm, 2, effective);
                chart3.Series[0].Points.AddXY(n, sr);
                chart4.Series[0].Points.AddXY(n, obm);
                chart5.Series[2].Points.AddXY(n, effective);

                ArraySort bubbleCycle = new ArraySort();
                bubbleCycle.a = (int[])(base_arr.Clone());
                sr = 0; obm = 0;
                bubbleCycle.BubbleSortCycle(bubbleCycle.a, ref sr, ref obm);
                effective = EffectiveCount(sr, obm);
                textBox1.Text += "Сортировка пузырьком циклами:" + Environment.NewLine;
                output_textBox(bubbleCycle.a, n);
                output_dataGridView(count, sr, obm, 3, effective);
                chart1.Series[0].Points.AddXY(n, sr);
                chart2.Series[0].Points.AddXY(n, obm);
                chart5.Series[0].Points.AddXY(n, effective);
           
                ArraySort selectionRecursive = new ArraySort();
                selectionRecursive.a = (int[])(base_arr.Clone());
                sr = 0; obm = 0;
                selectionRecursive.SelectionSortRecursive(selectionRecursive.a, n, ref sr, ref obm, 0);
                effective = EffectiveCount(sr, obm);
                textBox1.Text += "Сортировка выбором рекурсия:" + Environment.NewLine;
                output_textBox(selectionRecursive.a, n);
                output_dataGridView(count, sr, obm, 4, effective);
                chart1.Series[1].Points.AddXY(n, sr);
                chart2.Series[1].Points.AddXY(n, obm);
                chart5.Series[1].Points.AddXY(n, effective);
                count++;
            }
        }
    }
}