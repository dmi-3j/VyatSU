using AISDemoApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class AdminForm : Form
    {
        public AdminForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private string username;

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = username;
            InitTable();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = this.MdiParent;
            Close();
            loginForm.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addInventoryForm addInventoryForm = new addInventoryForm(username);
            addInventoryForm.MdiParent = MdiParent;
            addInventoryForm.Show();
            this.Close();
        }

        private void InitTable()
        {
            using Context context = new();
            {
                List<Inventory> inventory = context.Inventory.ToList();
                foreach (Inventory item in inventory)
                {
                    Image image = Image.FromFile(item.PhotoPath);
                    dataGridView1.Rows.Add(item.Id, image, item.InventoryName, item.InventoryType, item.Size, item.RentPrice);
                }
            }
        }
        private void InitTable(string find)
        {
            dataGridView1.Rows.Clear();
            using Context context = new();
            {
                List<Inventory> inventory = context.Inventory.Where(a => a.InventoryName.ToLower().Contains(find.ToLower())).ToList();
                foreach (Inventory item in inventory)
                {
                    Image image = Image.FromFile(item.PhotoPath);
                    dataGridView1.Rows.Add(item.Id, image, item.InventoryName, item.InventoryType, item.Size, item.RentPrice);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string find = textBox1.Text;
            if (find == null || find.Trim().Length == 0)
            {
                InitTable();
            }
            else
            {
                InitTable(find);
            }
        }
    }
}
