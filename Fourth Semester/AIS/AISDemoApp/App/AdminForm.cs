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
    }
}
