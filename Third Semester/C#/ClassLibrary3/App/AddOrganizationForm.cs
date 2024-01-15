using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using vaccinecalend;

namespace App
{
    public partial class AddOrganizationForm : Form
    {
        public AddOrganizationForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                try
                {
                    string organizationName = "";
                    string address = "";
                    string phoneNumber = "";
                    if(!string.IsNullOrWhiteSpace(NameTextBox.Text.Trim()))
                    {
                        organizationName = NameTextBox.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Название организации не может быть пустым.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(addressTextBox.Text.Trim()))
                    {
                        address = addressTextBox.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Адрес организации не может быть пустым.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(phoneTextBox.Text.Trim()) && Regex.IsMatch(phoneTextBox.Text.Trim(), @"^\+7\d{10}$"))
                    {
                        phoneNumber = phoneTextBox.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Введите корректный номер телефона в формате +7XXXXXXXXXX", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DBService service = new DBService(context);
                    MedicalOrganization organization = new MedicalOrganization()
                    {
                        OrganizationName = organizationName,
                        Address = address,
                        PhoneNumber = phoneNumber,
                    };
                    service.AddMedicalOrganization(organization);
                    MessageBox.Show("Организация успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
