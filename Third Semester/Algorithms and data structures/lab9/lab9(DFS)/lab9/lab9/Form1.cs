using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static lab9.Form1;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;

        }
        public class GraphNode
        {
            public int Index { get; set; }
            public string Value { get; set; }

            public GraphNode(int index, string value)
            {
                Index = index;
                Value = value;
            }
        }
        int[,] adjacencyMatrix;
        int graphNodeCount;
        private List<GraphNode> graphNodes; // Список вершин графа
        private void button1_Click(object sender, EventArgs e)
        {
            graphNodeCount = (int)numericUpDown1.Value;
            dataGridView1.RowCount = graphNodeCount;
            dataGridView1.ColumnCount = graphNodeCount;
            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = graphNodeCount;
            button2.Enabled = true;
            graphNodes = new List<GraphNode>();
            for (int i = 0; i < graphNodeCount; i++)
            {
                graphNodes.Add(new GraphNode(i, "Value" + (i + 1)));
            }
        }


        private void DrawGraph(int[,] adjacencyMatrix)
        {
            if (adjacencyMatrix == null) return;

            int vertexCount = adjacencyMatrix.GetLength(0);
            if (vertexCount == 0) return;

            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Определение координат для вершин, чтобы они равномерно распределялись по окружности
                PointF[] vertexPositions = CalculateVertexPositions(vertexCount);

                for (int i = 0; i < vertexCount; i++) //отрисовка вершин
                {
                    PointF vertexPosition = vertexPositions[i];
                    g.FillEllipse(Brushes.Blue, vertexPosition.X - 10, vertexPosition.Y - 10, 25, 25);
                    g.DrawString((i + 1).ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.White, vertexPosition.X - 5, vertexPosition.Y - 5);

                    //if (i < graphNodes.Count)
                    //{
                    //    string nodeValue = graphNodes[i].Value;
                    //    SizeF textSize = g.MeasureString(nodeValue, new Font("Arial", 12, FontStyle.Bold));
                    //    PointF textPosition = new PointF(vertexPosition.X - textSize.Width / 2, vertexPosition.Y + 20); // Расположение текста рядом с вершиной
                    //    g.DrawString(nodeValue, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, textPosition);
                    //}
                }

                for (int i = 0; i < vertexCount; i++)  // Отрисовка ребер на основе матрицы смежности
                {
                    for (int j = i; j < vertexCount; j++) // Изменение здесь: начните с j = i
                    {
                        if (adjacencyMatrix[i, j] == 1) // Проверка на значение в матрице смежности (= 1)
                        {
                            if (i == j)
                            {
                                g.DrawEllipse(Pens.Black, vertexPositions[i].X - 10, vertexPositions[i].Y - 10, 40, 40); //петля
                            }
                            else
                            {
                                g.DrawLine(Pens.Black, vertexPositions[i], vertexPositions[j]); //отрисовка ребра между вершинами
                            }
                        }
                    }
                }
            }
            pictureBox1.Image = bitmap;
        }

        private PointF[] CalculateVertexPositions(int vertexCount)
        {
            PointF[] positions = new PointF[vertexCount];
            float centerX = pictureBox1.Width / 2;
            float centerY = pictureBox1.Height / 2;
            float radius = Math.Min(centerX, centerY) - 30;

            for (int i = 0; i < vertexCount; i++)
            {
                float angle = (float)(2 * Math.PI * i / vertexCount);
                float x = centerX + radius * (float)Math.Cos(angle);
                float y = centerY + radius * (float)Math.Sin(angle);
                positions[i] = new PointF(x, y);
            }
            return positions;
        }
        private void VisualizeGraph(object sender, EventArgs e)
        {
            int vertexCount = dataGridView1.RowCount;  //количество вершин (размер матрицы)
            adjacencyMatrix = new int[vertexCount, vertexCount]; // матрица смежности

            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    // Проверка, есть ли значение в ячейке DataGridView
                    object cellValue = dataGridView1.Rows[i].Cells[j].Value;
                    if (cellValue != null)
                    {
                        adjacencyMatrix[i, j] = Convert.ToInt32(cellValue); // Преобразование и запись в матрицу смежности
                    }
                }
            }
            DrawGraph(adjacencyMatrix);  //визуализация графа на PictureBox
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
        }
        private bool isValueFound = false; // Флаг, указывающий, было ли найдено значение
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            numericUpDown2.Maximum = graphNodeCount;
            int startVertex = (int)numericUpDown2.Value - 1; //выбранная начальная вершина.
            string searchValue = textBox1.Text; // Значение, которое нужно найти
            isValueFound = false; //сброс флага
            List<int> dfsResult = DFS(adjacencyMatrix, startVertex, searchValue);

            if (isValueFound)
            {
                richTextBox1.AppendText("Значение найдено в обходе DFS:\n");
                foreach (int vertex in dfsResult)
                {
                    richTextBox1.AppendText((vertex + 1) + " ");
                }
            }
            else
            {
                richTextBox1.AppendText("Значение не найдено в обходе DFS.");
            }
        }
        private List<int> DFS(int[,] adjacencyMatrix, int startVertex, string searchValue)
        {
            int vertexCount = adjacencyMatrix.GetLength(0);
            List<int> dfsResult = new List<int>();
            bool[] visited = new bool[vertexCount];

            Stack<int> stack = new Stack<int>();
            stack.Push(startVertex);
            visited[startVertex] = true;

            while (stack.Count > 0)
            {
                int currentVertex = stack.Pop();
                dfsResult.Add(currentVertex);

                if (graphNodes[currentVertex].Value == searchValue)
                {
                    isValueFound = true;
                    break;
                }

                for (int i = 0; i < vertexCount; i++)
                {
                    if (adjacencyMatrix[currentVertex, i] == 1 && !visited[i])
                    {
                        stack.Push(i);
                        visited[i] = true;
                    }
                }
            }
            return dfsResult;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            groupBox4.Enabled = false;
            button2.Enabled = false;
            dataGridView1.Rows.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if (graphNodes == null)
            //{
            //    MessageBox.Show("Сначала создайте граф и вершины, нажав на кнопку 'Создать граф'.");
            //    return;
            //}

            // Очистите список graphNodes перед добавлением новых значений.
            graphNodes.Clear();

            // Обновите значения узлов из dataGridView2 и сохраните их в graphNodes.
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                string nodeValue = dataGridView2.Rows[0].Cells[i].Value.ToString();
                graphNodes.Add(new GraphNode(i, nodeValue));
            }
            DrawGraph(adjacencyMatrix);
        }

    }
}