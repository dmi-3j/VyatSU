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

        public User AuthenticatedUser { get; private set; }

        private VaccineCalendarContext context;
        

        public LoginForm(VaccineCalendarContext context)
        {
            InitializeComponent();
            this.context = context;
           // service = new DBService(context);
        }
     
        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = loginField.Text;
            string password = passwordField.Text;

            string hashPassword = DBService.HashPassword(password);

            var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == hashPassword);
            if (user != null)
            {
                AuthenticatedUser = user;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные учётные данные. Повторите попытку.");
            }
        }
    }
}