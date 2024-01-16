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
    public partial class MedPersonalForm : Form
    {
        private vaccinecalend.User currentUser;
        public MedPersonalForm(vaccinecalend.User user)
        {
            InitializeComponent();
            currentUser = user;
            InitStatusLabel();
        }
        private void InitStatusLabel()
        {
            userNameLabel.Text = $"Вы авторизованы за {currentUser.FirstName} (Мед. работник)";
            statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            userNameLabel.Alignment = ToolStripItemAlignment.Right;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void findUserButton_Click(object sender, EventArgs e)
        {
            FindUserForm findUserForm = new FindUserForm();
            findUserForm.ShowDialog();
        }

        private void viewRecordsButton_Click(object sender, EventArgs e)
        {
            RecordsForm recordsForm = new RecordsForm();
            recordsForm.ShowDialog();
        }
    }
}
