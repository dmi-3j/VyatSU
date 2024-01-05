using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vaccinecalend;

namespace App
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = loginField.Text;
            string password = passwordField.Text;

            using (var context = new VaccineCalendarContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    
                    this.Close();
                    UserForm userForm = new UserForm(user);
                    userForm.Show();
                }
                else
                {
                    MessageBox.Show("Неверные учётные данные. Повторите попытку.");
                }
            }
        }
    }
}
