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
    public partial class FindUserForm : Form
    {
        public FindUserForm()
        {
            InitializeComponent();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            string inshuranceNumber = "";
            if (!string.IsNullOrWhiteSpace(inshuranceNumberTextBox.Text.Trim()) && Regex.IsMatch(inshuranceNumberTextBox.Text, @"^\d{16}$"))
            {
                inshuranceNumber = inshuranceNumberTextBox.Text.Trim();
                using (var context = new VaccineCalendarContext())
                {
                    Vaccinated? vaccinated = context.Vaccinated
                        .Where(v => v.InshuranceNumber.Equals(inshuranceNumber))
                        .FirstOrDefault();
                    if (vaccinated == null)
                    {
                        MessageBox.Show($"Пользователь с таким полисом ОМС не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        Guid vaccinatedId = vaccinated.Id;
                        UserInfoForm userInfoForm = new UserInfoForm(vaccinatedId);
                        this.Close();
                        userInfoForm.Show();
                    }

                }
            }
            else
            {
                MessageBox.Show($"Введите корректный номер полиса ОМС (16 цифр)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
