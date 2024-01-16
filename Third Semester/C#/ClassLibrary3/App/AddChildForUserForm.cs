using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using vaccinecalend;

namespace App
{
    public partial class AddChildForUserForm : Form
    {
        public AddChildForUserForm(User user)
        {
            InitializeComponent();
            this.user = user;
            dobPicker.MaxDate = DateTime.Now.Date;
            dobPicker.MinDate = DateTime.Now.Date.AddYears(-18);
        }
        private User user;
        private void addButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                //try
                //{

                if (string.IsNullOrWhiteSpace(lastNameTextBox.Text.Trim()))
                {
                    MessageBox.Show("Поле Фамилия  не может быть пустым", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string lName = lastNameTextBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(firstNameTextBox.Text.Trim()))
                {
                    MessageBox.Show("Поле Имя  не может быть пустым", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string fName = firstNameTextBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(insNumTextBox.Text.Trim()) && !Regex.IsMatch(insNumTextBox.Text, @"^\d{16}$"))
                {
                    MessageBox.Show("Введите корректный номер полиса ОМС (16 цифр)", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (context.Vaccinated.Any(v => v.InshuranceNumber == insNumTextBox.Text.Trim()))
                {
                    MessageBox.Show("Пользователь с таким полисом ОМС уже существует", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string insNum = insNumTextBox.Text.Trim();


                DBService service = new DBService(context);
                Child child = new Child()
                {
                    LastName = lName,
                    FirstName = fName,
                    MiddleName = middleNameTextBox.Text,
                    DateOfBirth = dobPicker.Value.Date,
                    UserId = user.Id,
                    InshuranceNumber = insNum,
                    PhoneNumber = user.PhoneNumber //по умолчанию ребенку ставится номер родителя
                };
                service.AddChild(child);
                MessageBox.Show("Ребёнок успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                //}

                //catch (Exception ex)
                //{
                //    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }
    }
}
