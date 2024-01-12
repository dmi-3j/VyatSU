using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
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
        }
        private User user;
        private void addButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                try
                {
                    DBService service = new DBService(context);
                    Child child = new Child()
                    {
                        LastName = lastNameTextBox.Text,
                        FirstName = firstNameTextBox.Text,
                        MiddleName = middleNameTextBox.Text,
                        DateOfBirth = DateTimeOffset.Parse(DoBTextBox.Text).Date,
                        UserId = user.Id
                    };
                    service.AddChild(child);
                    MessageBox.Show("Ребёнок успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
