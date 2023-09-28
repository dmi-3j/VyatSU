using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace lab5_7
{
    public partial class Form1 : Form
    {
        List<string> lines = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
           

            string filename = openFileDialog1.FileName;
            lines.AddRange(File.ReadAllLines(filename, Encoding.UTF8));
            for (int i = 0; i < lines.Count;i++)
            {
                listBox1.Items.Add(lines[i]);
            }
        }
       

        public void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            lines.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lines.Add("погулять");
            listBox1.Items.Add(lines[lines.Count-1]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            File.WriteAllLines(filename, lines);
            lines.Clear();
            lines.AddRange(File.ReadAllLines(filename, Encoding.UTF8));
            for (int i = 0; i < lines.Count; i++)
            {
                listBox2.Items.Add(lines[i]);
            }
        }
    }
}
