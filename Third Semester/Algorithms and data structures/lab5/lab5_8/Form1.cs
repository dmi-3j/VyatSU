using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lab5_8
{
    public partial class Form1 : Form
    {
        string[] strings = { "раз", "два", "три", "четыре", "пять" };
        List<string> list = new List<string>();
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            list = strings.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                listBox1.Items.Add(list[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            File.WriteAllLines(filename, strings);
            button2.Enabled=true;
            button3.Enabled=true;
            MessageBox.Show("Успешно записано в файл");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;
            string[] text = File.ReadAllLines(filename);
            list.Clear();
            list = text.ToList();
            list.Insert(1, "Привет!");
            File.WriteAllLines(filename, list);
            for (int i = 0; i < list.Count; i++)
            {
                listBox2.Items.Add(list[i]);
            }
            MessageBox.Show("Успешно записано в файл");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            list.Sort();
            int index = list.BinarySearch("Привет!");
            if (index >= 0)
            {
                list[index] = list[index].Insert(list[index].IndexOf("!"), ", Коля");
                MessageBox.Show("Ура, добавили!");
            }
            else MessageBox.Show("Не добавили:(");
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(80, 80);
            imageList.Images.Add(new Bitmap("D:\\Desktop\\image-1.png"));
            imageList.Images.Add(new Bitmap("D:\\Desktop\\image-2.png"));
            imageList.Images.Add(new Bitmap("D:\\Desktop\\image-3.png"));
            imageList.Images.Add(new Bitmap("D:\\Desktop\\image-6.png"));
            imageList.Images.Add(new Bitmap("D:\\Desktop\\image-5.png"));
            imageList.Images.Add(new Bitmap("D:\\Desktop\\image-4.png"));
            listView1.SmallImageList = imageList;
            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { "", list[i] });
                listViewItem.ImageIndex = i;
                listView1.Items.Add(listViewItem);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            list.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listView1.Items.Clear();
        }
    }
}

