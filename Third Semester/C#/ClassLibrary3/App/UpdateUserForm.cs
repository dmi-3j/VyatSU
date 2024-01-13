using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vaccinecalend;

namespace App
{
    public partial class UpdateUserForm : Form
    {
        public UpdateUserForm(vaccinecalend.User user)
        {
            InitializeComponent();
            this.user = user;
            InitData();
        }
        private vaccinecalend.User user;
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
                    user.FirstName = firstNameTextBox.Text;
                    user.LastName = lastNameTextBox.Text;
                    user.MiddleName = middleNameTextBox.Text;
                    user.Address = addressTextBox.Text;
                    user.PhoneNumber = phoneTextBox.Text;
                    service.UpdateUser(user);
                    MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
