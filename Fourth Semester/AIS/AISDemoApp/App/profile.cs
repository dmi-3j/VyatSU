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
    public partial class profile : Form
    {
        public profile(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private string username;

        private void profile_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = username;
            loadData();
        }
        private void loadData()
        {
            using Context context = new();
            {
                User? user = context.Users.FirstOrDefault(x => x.Username == username);
                fnameTB.Text = user.FirstName;
                lNmaeTB.Text = user.LastName;
                dobTB.Text = user.DateOfBirth.ToString();
                phoneTB.Text = user.PhoneNumber;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminForm af = new AdminForm(username);
            af.MdiParent = MdiParent;
            af.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
