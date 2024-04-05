using AISDemoApp;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App
{
    public partial class editForm : Form
    {
        public editForm(string username, Guid id)
        {
            InitializeComponent();
            this.username = username;
            this.id = id;
        }
        private string username;
        private Guid id;

        private void editForm_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = username;
            initData();

        }
        private void initData()
        {
            using Context context = new();
            {
                Inventory? inv = context.Inventory.FirstOrDefault(i => i.Id == id);
                titleTextBox.Text = inv.InventoryName;
                numericUpDown2.Value = inv.Size;
                numericUpDown1.Value = inv.RentPrice;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminForm af = new AdminForm(username);
            af.MdiParent = MdiParent;
            af.Show();
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }
            decimal price = numericUpDown1.Value;
            decimal size = numericUpDown2.Value;
            using Context context = new();
            {
                Inventory? inv = context.Inventory.FirstOrDefault(i => i.Id == id);
                inv.RentPrice = price;
                inv.Size = size;
                inv.InventoryName = title;
                DBService service = new(context);
                service.updateInventory(inv);
                MessageBox.Show("Успешно обновлено!");
                backButton_Click(sender, e);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            profile p = new profile(username);
            p.MdiParent = MdiParent;
            Close();
            p.Show();
        }
    }
}
