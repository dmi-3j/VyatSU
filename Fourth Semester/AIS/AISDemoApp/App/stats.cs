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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App
{
    public partial class stats : Form
    {
        public stats(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private string username;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            profile p = new profile(username);
            p.MdiParent = MdiParent;
            //Close();
            p.Show();
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

        private void stasweek_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                DateTime startDate = DateTime.Today.AddDays(-6).Date;
                int count = context.Orders.Count(o => o.OrderDate >= startDate);
                decimal totalMoney = context.Orders.Where(o => o.OrderDate >= startDate).Sum(o => o.TotalAmount);
                decimal avgOrd = Math.Round(context.Orders.Where(o => o.OrderDate >= startDate).Average(o => o.TotalAmount), 2);
                double avgCart = context.Orders.Where(o => o.OrderDate >= startDate).Average(o => o.OrderItems.Count());
                MessageBox.Show($"Статистика за неделю:\n Количество заказов: {count}\n Общая выручка: {totalMoney}\n Среднее количество товаров в корзине: {avgCart}\n Средний чек: {avgOrd}");
            }
        }

        private void statsall_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                int count = context.Orders.Count();
                decimal totalMoney = context.Orders.Sum(o => o.TotalAmount);
                decimal avgOrd = Math.Round(context.Orders.Average(o => o.TotalAmount), 2);
                double avgCart = context.Orders.Average(o => o.OrderItems.Count());
                MessageBox.Show($"Статистика за всё время:\n Количество заказов: {count}\n Общая выручка: {totalMoney}\n Среднее количество товаров в корзине: {avgCart}\n Средний чек: {avgOrd}");
            }
        }

        private void statsmonth_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                DateTime startDate = DateTime.Today.AddMonths(-1);
                startDate = new DateTime(startDate.Year, startDate.Month, 1).Date;
                int count = context.Orders.Count(o => o.OrderDate >= startDate);
                decimal totalMoney = context.Orders.Where(o => o.OrderDate >= startDate).Sum(o => o.TotalAmount);
                decimal avgOrd = Math.Round(context.Orders.Where(o => o.OrderDate >= startDate).Average(o => o.TotalAmount), 2);
                double avgCart = context.Orders.Where(o => o.OrderDate >= startDate).Average(o => o.OrderItems.Count());
                MessageBox.Show($"Статистика за месяц:\n Количество заказов: {count}\n Общая выручка: {totalMoney}\n Среднее количество товаров в корзине: {avgCart}\n Средний чек: {avgOrd}");
            }
        }
    }
}
