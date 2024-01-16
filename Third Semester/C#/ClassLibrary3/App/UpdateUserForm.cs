using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using vaccinecalend;

namespace App
{
    public partial class UpdateUserForm : Form
    {
        public UpdateUserForm(User user)
        {
            InitializeComponent();
            this.user = user;
            InitData();
        }
        private User user;
        private void InitData()
        {
            firstNameTextBox.Text = user.FirstName;
            lastNameTextBox.Text = user.LastName;
            middleNameTextBox.Text = user.MiddleName;
            addressTextBox.Text = user.Address;
            phoneTextBox.Text = user.PhoneNumber;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                try
                {
                    DBService service = new DBService(context);
                    if (!string.IsNullOrWhiteSpace(firstNameTextBox.Text.Trim()))
                    {
                        user.FirstName = firstNameTextBox.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные данные в поле Имя.");
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(lastNameTextBox.Text.Trim()))
                    {
                        user.LastName = lastNameTextBox.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные данные в поле Фамилия.");
                        return;
                    }
                    user.MiddleName = middleNameTextBox.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(addressTextBox.Text.Trim()))
                    {
                        user.Address = addressTextBox.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные данные в поле Адрес.");
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(phoneTextBox.Text.Trim()) && Regex.IsMatch(phoneTextBox.Text.Trim(), @"^\+7\d{10}$"))
                    {
                        user.PhoneNumber = phoneTextBox.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные данные в поле Номер телефона. Формат номера: +7XXXXXXXXXX");
                        return;
                    }
                    service.UpdateUser(user);
                    MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
