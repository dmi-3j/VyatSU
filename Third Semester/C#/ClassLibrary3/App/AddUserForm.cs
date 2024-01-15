using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using vaccinecalend;

namespace App
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
            roleComboBox.SelectedIndex = 0;
            dobPicker.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(firstNameTextBox.Text.Trim()))
                    {
                        MessageBox.Show("Поле Имя не может быть пустым", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string fName = firstNameTextBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(lastNameTextBox.Text.Trim()))
                    {
                        MessageBox.Show("Поле Фамилия не может быть пустым", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string lName = lastNameTextBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(addressTextBox.Text.Trim()))
                    {
                        MessageBox.Show("Поле Адрес не может быть пустым", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string address = addressTextBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(phoneTextBox.Text.Trim()) && !Regex.IsMatch(phoneTextBox.Text.Trim(), @"^\+7\d{10}$"))
                    {
                        MessageBox.Show("Введите корректный номер телефона в формате +7XXXXXXXXXX", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string phone = phoneTextBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(inshuranceNumberTextBox.Text.Trim()) && !Regex.IsMatch(inshuranceNumberTextBox.Text, @"^\d{16}$"))
                    {
                        MessageBox.Show("Введите корректный номер полиса ОМС (16 цифр)", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (context.Vaccinated.Any(v => v.InshuranceNumber == inshuranceNumberTextBox.Text.Trim()))
                    {
                        MessageBox.Show("Пользователь с таким полисом ОМС уже существует", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string insNum = inshuranceNumberTextBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(passwordTextBox.Text.Trim()))
                    {
                        MessageBox.Show("Поле Пароль  не может быть пустым", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string password = passwordTextBox.Text.Trim();
                    if (roleComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Необходимо выьрать роль для пользователя", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(loginTextBox.Text.Trim()))
                    {
                        MessageBox.Show("Поле Логин не может быть пустым", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    bool isLoginBusy = context.Users
                        .Any(u => u.Username == loginTextBox.Text.Trim());
                    if (isLoginBusy)
                    {
                        MessageBox.Show("Такой логин занят", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string login = loginTextBox.Text.Trim();

                    DBService service = new DBService(context);
                    User user = new User()
                    {
                        FirstName = fName,
                        LastName = lName,
                        MiddleName = middleNameTextBox.Text,
                        DateOfBirth = dobPicker.Value.Date,
                        Address = address,
                        PhoneNumber = phone,
                        InshuranceNumber = insNum,
                        Username = login,
                        Password = password,
                        UserRoles = new List<UserRole>() { new UserRole() { Role = roleComboBox.SelectedItem.ToString() } }
                    };
                    service.AddUser(user);
                    MessageBox.Show("Пользователь успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
