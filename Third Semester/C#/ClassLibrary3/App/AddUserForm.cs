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
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                DBService service = new DBService(context);
                User user = new User()
                {
                    FirstName = firstNameTextBox.Text,
                    LastName = lastNameTextBox.Text,
                    MiddleName = middleNameTextBox.Text,
                    DateOfBirth = DateTimeOffset.Parse(DoBTextBox.Text).UtcDateTime,
                    Address = addressTextBox.Text,
                    PhoneNumber = phoneTextBox.Text,
                    Username = loginTextBox.Text,
                    Password = passwordTextBox.Text,
                    UserRoles = new List<UserRole>() { new UserRole() {Role = roleComboBox.SelectedItem.ToString()} }
                };
                service.AddUser(user);

            }
        }
    }
}
