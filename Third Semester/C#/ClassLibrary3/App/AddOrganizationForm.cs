using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
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
                    DBService service = new DBService(context);
                    MedicalOrganization organization = new MedicalOrganization()
                    {
                        OrganizationName = NameTextBox.Text,
                        Address = addressTextBox.Text,
                        PhoneNumber = phoneTextBox.Text,
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
