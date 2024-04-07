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

namespace App
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private Context db = new Context();


        private void LoginForm_Load(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                dblabel.Text = context.Database.GetDbConnection().Database;
            }
        }

        private void loginProcessButton_Click(object sender, EventArgs e)
        {
            string username = loginTextBox.Text.Trim();
            string password = passwoedTextBox.Text;
            string hashPassword = DBService.HashPassword(password);

            var user = db.Users
                .Include(u => u.UserRoles)
                    .FirstOrDefault(u => u.Username == username && u.Password == hashPassword);
            if (user != null)
            {
                if (user.UserRoles.Any(a => a.Role == "USER"))
                {
                    UserForm uf = new UserForm(username);
                    uf.MdiParent = this.MdiParent;
                    this.Close();
                    uf.Show();
                }
                if (user.UserRoles.Any(a => a.Role == "ADMIN"))
                {
                    AdminForm af = new AdminForm(username);
                    af.MdiParent = this.MdiParent;
                    this.Close();
                    af.Show();
                }
            }
            else
            {
                MessageBox.Show("Неверные учётные данные. Повторите попытку.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reloadDB reload = new reloadDB();
            reload.MdiParent = MdiParent;
            reload.Show();
        }
    }
}
