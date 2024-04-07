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
using AISDemoApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
namespace App
{
    public partial class reloadDB : Form
    {
        public reloadDB()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void reloadDB_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Имя не может быть пустым");
                return;
            }
            string newConnectionString = $"Host=localhost;Port=5432;Database={name};Username=postgres;Password=1";
            Context.ConnectionString = newConnectionString;
            using (var connection = new NpgsqlConnection(newConnectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT 1", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Подключение к базе данных успешно установлено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось подключиться к базе данных!");
                    return;
                }
            }
            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = MdiParent;
            Form[] openFormsCopy = Application.OpenForms.Cast<Form>().ToArray();
            foreach (Form form in openFormsCopy)
            {
                if (form.MdiParent == MdiParent) form.Close();
            }
            loginForm.Show();
        }
    }
}
