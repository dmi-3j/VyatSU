using AISDemoApp;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App
{
    public partial class UserForm : Form
    {
        public UserForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private string username;
        string find;

        private void UserForm_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = username;
            InitTable();
            InitCmb();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = this.MdiParent;
            Close();
            loginForm.Show();
        }

        private void InitCmb()
        {
            using Context context = new();
            {
                string empt = "Выберите тип:";
                List<string> types = context.Inventory.Select(i => i.InventoryType).Distinct().ToList();
                types.Insert(0, empt);
                typeComboBox.DataSource = types;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            profile p = new profile(username);
            p.MdiParent = MdiParent;
            p.Show();
        }

        private void logoutButton_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = MdiParent;
            Form[] openFormsCopy = Application.OpenForms.Cast<Form>().ToArray();
            foreach (Form form in openFormsCopy)
            {
                if (form.MdiParent == MdiParent) form.Close();
            }
            loginForm.Show();
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
            InitTable();
        }

        private void finaButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            find = searchTextBox.Text;
            if (find == null || find.Trim().Length == 0)
            {
                InitTable();
            }
            else
            {
                InitTable(find);
            }
        }

        private void resBut_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text == null || searchTextBox.Text.Trim().Length == 0)
            {
                InitTable();
            }
            else
            {
                InitTable(find);
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            string from = priceFrom.Text;
            string to = priceTo.Text;
            string type = typeComboBox.SelectedItem.ToString();
            string search = searchTextBox.Text;

            using Context context = new();
            {
                var filteredInventory = context.Inventory.AsQueryable(); // Начальный запрос

                if (!string.IsNullOrEmpty(search) && search.Trim().Length != 0)
                {
                    filteredInventory = filteredInventory.Where(i => i.InventoryName.ToLower().Contains(search.ToLower()));
                }
                if (!string.IsNullOrEmpty(from) && decimal.TryParse(from, out decimal fromPrice))
                {
                    filteredInventory = filteredInventory.Where(i => i.RentPrice >= fromPrice);
                }

                if (!string.IsNullOrEmpty(to) && decimal.TryParse(to, out decimal toPrice))
                {
                    filteredInventory = filteredInventory.Where(i => i.RentPrice <= toPrice);
                }

                if (!string.IsNullOrEmpty(type) && type != "Выберите тип:")
                {
                    filteredInventory = filteredInventory.Where(i => i.InventoryType == type);
                }

                List<Inventory> result = filteredInventory.ToList();
                dataGridView1.Rows.Clear();
                foreach (Inventory item in result)
                {
                    Image image = Image.FromFile(item.PhotoPath);
                    dataGridView1.Rows.Add(item.Id, image, item.InventoryName, item.InventoryType, item.Size, item.RentPrice);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["actionCart"].Index)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {
                    using (var context = new Context())
                    {
                        Inventory? inv = context.Inventory
                            .FirstOrDefault(v => v.Id == Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString()));
                        AISDemoApp.User user = context.Users.FirstOrDefault(u => u.Username == username);
                        //Cart cart = new Cart
                        //{
                        //    UserId = user.Id,
                        //    User = user
                        //};
                        //user.Cart = cart;
                        //context.Cart.Add(cart);
                        //context.SaveChanges();
                        Cart cart = context.Cart.FirstOrDefault(u => u.User == user);

                        CartItem cartitem = new CartItem
                        {
                            Inventory = inv,
                            Cart = cart,
                        };
                        user.Cart.CartItems.Add(cartitem);
                        context.CartItems.Add(cartitem);
                        context.SaveChanges();
                        MessageBox.Show("Добавлено в корзину");

                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cart cart = new cart(username);
            cart.MdiParent = MdiParent;
            cart.Show();
        }
    }
}
