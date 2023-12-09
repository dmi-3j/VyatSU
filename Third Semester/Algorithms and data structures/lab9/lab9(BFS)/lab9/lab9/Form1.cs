using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            groupBox4.Enabled = false;

        }
        int[,] adjacencyMatrix;
        int graphNodeCount;
        private void button1_Click(object sender, EventArgs e)
        {
            graphNodeCount = (int)numericUpDown1.Value;
            dataGridView1.RowCount = graphNodeCount;
            dataGridView1.ColumnCount = graphNodeCount;
            button2.Enabled = true;
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            numericUpDown2.Maximum = graphNodeCount;
            int startVertex = (int)numericUpDown2.Value - 1; //выбранная начальная вершина.
            List<int> bfsResult = BFS(adjacencyMatrix, startVertex);
            richTextBox1.AppendText("BFS обход вершин:\n");
            foreach (int vertex in bfsResult)
            {
                richTextBox1.AppendText((vertex + 1) + " ");
            }
        }
        private List<int> BFS(int[,] adjacencyMatrix, int startVertex)
        {
            int vertexCount = adjacencyMatrix.GetLength(0);
            List<int> bfsResult = new List<int>();
            bool[] visited = new bool[vertexCount];
          
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startVertex);
            visited[startVertex] = true;

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();
                bfsResult.Add(currentVertex);

                for (int i = 0; i < vertexCount; i++)
                {
                    if (adjacencyMatrix[currentVertex, i] == 1 && !visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
            return bfsResult;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            groupBox4.Enabled = false;
            button2.Enabled = false;
            dataGridView1.Rows.Clear();
        }
    }
}