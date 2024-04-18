using AISDemoApp;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace App
{
    public partial class cart : Form
    {
        public cart(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private string username;
        private decimal total;
        private void cart_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = username;
            comboBox1.SelectedIndex = 0;
            InitData();
        }
        private void InitData()
        {

            dataGridView1.Rows.Clear();
            total = 0;
            using Context context = new();
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);
                Cart cart = context.Cart.FirstOrDefault(c => c.User == user);
                List<CartItem> ci = context.CartItems.Where(c => c.Cart == cart).ToList();

                var inventoryInCart = new List<Inventory>();
                foreach (var cartItem in ci)
                {
                    Inventory i = context.Inventory.FirstOrDefault(i => i.Id == cartItem.InventoryId);
                    inventoryInCart.Add(i);
                }

                foreach (Inventory item in inventoryInCart)
                {
                    total += item.RentPrice;
                    dataGridView1.Rows.Add(item.Id, item.InventoryName, item.InventoryType, item.Size, item.RentPrice);
                }
                if (comboBox1.SelectedIndex == 1) total *= 2;
                if (comboBox1.SelectedIndex == 2) total *= 3;
                if (checkBox1.Checked) total += 150;
                if (checkBox2.Checked) total += 100;
                if (checkBox3.Checked) total += 500;
                labelTotal.Text = total.ToString() + "р";

            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
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


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                total += 500;

            }
            else if (!checkBox2.Checked)
            {
                total -= 500;

            }
            labelTotal.Text = total.ToString() + "р";
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                total += 150;

            }
            else if (!checkBox1.Checked)
            {
                total -= 150;

            }
            labelTotal.Text = total.ToString() + "р";
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                total += 100;

            }
            else if (!checkBox2.Checked)
            {
                total -= 100;

            }
            labelTotal.Text = total.ToString() + "р";
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked)
            {
                total += 500;

            }
            else if (!checkBox3.Checked)
            {
                total -= 500;

            }
            labelTotal.Text = total.ToString() + "р";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["actiondel"].Index)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {
                    using (var context = new Context())
                    {
                        Inventory? inv = context.Inventory
                            .Where(v => v.Id == Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString()))
                            .FirstOrDefault();
                        User user = context.Users.FirstOrDefault(u => u.Username == username);
                        Cart cart = context.Cart.FirstOrDefault(c => c.User == user);
                        CartItem cartItem = context.CartItems.Where(c => c.Cart == cart).FirstOrDefault(ci => ci.InventoryId == inv.Id);
                        DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            context.CartItems.Remove(cartItem);
                            context.SaveChanges();
                            InitData();

                            labelTotal.Text = total.ToString() + "р";
                        }
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            profile p = new profile(username);
            p.MdiParent = MdiParent;
            p.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username);
                Cart cart = context.Cart.FirstOrDefault(c => c.User == user);
                List<CartItem> ci = context.CartItems.Where(c => c.Cart == cart).ToList();
                if (ci.Count == 0)
                {
                    MessageBox.Show("Ваша корзина пуста. Добавьте инвентарь в корзину, чтобы продолжиьть.");
                    return;
                }
                string services = "";
                if (checkBox1.Checked) services += "Смазка лыж, ";
                if (checkBox2.Checked) services += "Горячий чай, ";
                if (checkBox3.Checked) services += "Страхование жизни ";

                DialogResult result = MessageBox.Show("Оформить заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            Order order = new Order
                            {
                                UserId = user.Id,
                                User = user,
                                OrderDate = DateTime.Now.Date,
                                Services = services,
                                RentDuaration = comboBox1.SelectedItem.ToString(),
                                TotalAmount = total
                            };
                            foreach (var cartItem in ci)
                            {
                                OrderItem orderItem = new OrderItem
                                {
                                    InventoryId = cartItem.InventoryId,
                                    Inventory = cartItem.Inventory
                                };
                                order.OrderItems.Add(orderItem);
                            }
                            context.Orders.Add(order);
                            context.CartItems.RemoveRange(context.CartItems.Where(c => c.Cart == cart));
                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка при оформлении заказа: {ex.Message}");
                        }
                    }
                    MessageBox.Show("Ваш заказ успешно оформлен!");
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    InitData();
                }

            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
