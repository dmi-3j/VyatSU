﻿using System;
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
        private vaccinecalend.User currentUser;
        public AdminForm(vaccinecalend.User user)
        {
            InitializeComponent();
            currentUser = user;
            InitStatusLabel();
        }
        private void InitStatusLabel()
        {
            userNameLabel.Text = $"Вы авторизованы за {currentUser.FirstName} (Администратор)";
            statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            userNameLabel.Alignment = ToolStripItemAlignment.Right;
        }

        private void addOrganizationButton_Click(object sender, EventArgs e)
        {
            AddOrganizationForm addOrganizationForm = new AddOrganizationForm();
            addOrganizationForm.ShowDialog();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.ShowDialog();
        }

        private void addVaccineButton_Click(object sender, EventArgs e)
        {
            AddVaccineForm addVaccineForm = new AddVaccineForm();
            addVaccineForm.ShowDialog();
        }
    }
}
