using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab5_2
{
    struct Task
    {
        public string Name;
        public decimal Duration;
        public string Priority;
        public string Status;
        public string[] Category;
        public Task(string name, decimal duration, string priority, string status, string[] category)
        {
            Name = name;
            Duration = duration;
            Priority = priority;
            Status = status;
            Category = category;
        }
    }
    public partial class Form1 : Form
    {
        List<Task> tasks = new List<Task>();
        Task task = new Task();
        public Form1()
        {
            InitializeComponent();
        }
       
        private void method()
        {
            textBox1.Text = "";
            numericUpDown1.Value = 1;
            comboBox1.SelectedIndex = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            listView1.Items.Clear();
            treeView1.Nodes.Clear();
            for (int i = 0; i < domainUpDown1.Items.Count; i++)
            {
                treeView1.Nodes.Add(new TreeNode(domainUpDown1.Items[i].ToString()));
            }
            for (int i = 0; i < tasks.Count; i++)
            {
                for (int j = 0; j < domainUpDown1.Items.Count; j++)
                {
                    if (tasks[i].Status == domainUpDown1.Items[j].ToString())
                    {
                        treeView1.Nodes[j].Nodes.Add(new TreeNode(tasks[i].Name));
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            task.Name = textBox1.Text;
            task.Duration = numericUpDown1.Value;
            task.Priority = comboBox1.Text;
            task.Status = domainUpDown1.Text;
            List<string> select = new List<string>();
            for (int i = 0;i < checkedListBox1.Items.Count;i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    select.Add(checkedListBox1.Items[i].ToString());
                }
            }
            task.Category = select.ToArray();
            tasks.Add(task);
            method();
            for(int i =0; i<tasks.Count;i++)
            {
                string category = "";
                for (int k = 0; k < tasks[i].Category.Length;k++)
                {
                    category += tasks[i].Category[k] + ", ";
                }
                ListViewItem item = new ListViewItem(new string[]
                {
                    tasks[i].Name,
                    tasks[i].Duration.ToString(),
                    tasks[i].Priority,
                    tasks[i].Status,
                    category
                });
                listView1.Items.Add(item);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            method();
        }
    }
}
