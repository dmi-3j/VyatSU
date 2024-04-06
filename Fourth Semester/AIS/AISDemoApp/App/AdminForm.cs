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
        string find;

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
            //this.Close();
        }

        private void InitTable()
        {
            dataGridView1.Rows.Clear();
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
            find = textBox1.Text;
            if (find == null || find.Trim().Length == 0)
            {
                InitTable();
            }
            else
            {
                InitTable(find);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["actionDel"].Index)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {
                    using (var context = new Context())
                    {
                        Inventory? inv = context.Inventory
                            .Where(v => v.Id == Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString()))
                            .FirstOrDefault();
                        DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            DBService service = new(context);
                            service.deleteInventory(inv);
                            if (find != null && find.Trim().Length != 0) InitTable(find);
                            else InitTable();
                        }
                    }
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["actionRed"].Index)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {
                    using (var context = new Context())
                    {
                        Inventory? inv = context.Inventory
                            .Where(v => v.Id == Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString()))
                            .FirstOrDefault();
                        editForm ef = new editForm(username, inv.Id);
                        ef.MdiParent = MdiParent;
                        // Close();
                        ef.Show();
                    }
                }
            }



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            profile p = new profile(username);
            p.MdiParent = MdiParent;
            //Close();
            p.Show();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            InitTable();
        }
    }
}
