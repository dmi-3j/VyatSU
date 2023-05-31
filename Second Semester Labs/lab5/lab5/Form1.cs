using lab5;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class Form1 : Form
    {
        private Tree osinka;
        public Form1()
        {
            InitializeComponent();
            bypass.Enabled = false;
            buttonSearch.Enabled = false;
            HomeTask.Enabled = false;
            statusLabel.Text = "Загрузите данные";
            openFileDialog1.Filter = "Текстовые файлы(*.txt) | *.txt";
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Load_Click(object sender, EventArgs e)
        {
            textBoxTree.Clear();
            textBoxBypass.Clear();
            textBoxSearch.Clear();
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    osinka = new Tree();// создать новое дерево
                    textBoxTree.Clear();
                    using (var file = new System.IO.StreamReader(openFileDialog1.FileName))
                    {
                        while (file.Peek() >= 0)
                        {
                            string currentElement = file.ReadLine();
                            if (currentElement != null) osinka.Add(int.Parse(currentElement));
                        }
                    }
                    string results = "";
                    osinka.Output(ref results);
                    textBoxTree.Text = results;
                    bypass.Enabled = true;
                    buttonSearch.Enabled = true;
                    HomeTask.Enabled = true;
                    statusLabel.Text = "Выполните обход, поиск ключа или выведите слой с минимальным ключом";
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода", "Графы", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
        }
        private int FindMinKey()
        {
            int minKey = int.MaxValue;
            string bypass = "";
            osinka.Bypass(Tree.BypassOptions.LNR, ref bypass);
            int[] tempArray = bypass.Split().Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();
            minKey = tempArray[0];
            return minKey;
        }

        private void LNR_Click(object sender, EventArgs e)
        {
            string bypass = "";
            osinka.Bypass(Tree.BypassOptions.LNR, ref bypass);
            textBoxBypass.Text += @"Симметричный метод LNR: " + bypass;
        }
        private void NLR_Click(object sender, EventArgs e)
        {
            string bypass = "";
            osinka.Bypass(Tree.BypassOptions.NLR, ref bypass);
            textBoxBypass.Text += @"Прямой метод NLR: " + bypass;
        }
        private void LRN_Click(object sender, EventArgs e)
        {
            string bypass = "";
            osinka.Bypass(Tree.BypassOptions.LRN, ref bypass);
            textBoxBypass.Text += @"Обратный метод LRN: " + bypass;
        }
        private void RNL_Click(object sender, EventArgs e)
        {
            string bypass = "";
            osinka.Bypass(Tree.BypassOptions.RNL, ref bypass);
            textBoxBypass.Text += @"Справа налево RNL: " + bypass;
        }
        private void BFS_Click(object sender, EventArgs e)
        {
            string bypass = "";
            osinka.Bypass(Tree.BypassOptions.BFS, ref bypass);
            textBoxBypass.Text += @"Обход в ширину BFS: " + bypass;
        }
        private void All_Click(object sender, EventArgs e)
        {
            textBoxBypass.Clear();
            LNR_Click(sender, e);
            NLR_Click(sender, e);
            LRN_Click(sender, e);
            RNL_Click(sender, e);
            BFS_Click(sender, e);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string results = "";
            if (!Int32.TryParse(textBoxKey.Text, out int key))
            {
                MessageBox.Show("Введите корректный ключ.");
                return;
            }
            int depth = 0;
            osinka.KeySearch(ref results, key, ref depth);
            if (results != "") textBoxSearch.Text += @"найден элемент " + results + @"уровень " + depth + Environment.NewLine;
            else textBoxSearch.Text += @"элемент " + key + @" не найден " + Environment.NewLine;
        }

        private void HomeTask_Click(object sender, EventArgs e)
        {
            int minKey = FindMinKey();
            int depthMinKey = 0;
            string result = "";
            osinka.KeySearch(ref result, minKey, ref depthMinKey);
            osinka.OutLayer(depthMinKey, ref result);
            textBoxTree.Text += "Слой с минимальным ключом (Минимальный ключ: " + minKey + "): " + Environment.NewLine + result;
        }

        private void Help_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.ShowDialog();
        }
    }
}
