using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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

    public partial class UserForm : Form
    {


        private vaccinecalend.User currentUser;
        public UserForm(vaccinecalend.User user)
        {
            InitializeComponent();
            currentUser = user;
            InitStatusLabel();
            InitProfileTab();
            InitUserVaccinationTab();
            InitChildVaccinationTab();
        }
        private void InitProfileTab()
        {
            firstNameLabel.Text = currentUser.FirstName;
            lastNameLabel.Text = currentUser.LastName;
            dobLabel.Text = currentUser.DateOfBirth.Date.ToString("dd.MM.yyyy");
            phoneLabel.Text = currentUser.PhoneNumber;
            addressLabel.Text = currentUser.Address;
        }
        private void InitUserVaccinationTab()
        {
            using (VaccineCalendarContext context = new())
            {
                var userWithVaccinations = context.Users
                    .Include(u => u.VaccinationDiary)
                    .ThenInclude(vd => vd.Vaccinations)
                    .ThenInclude(w => w.Vaccine)
                    .Include(u => u.VaccinationDiary)
                    .ThenInclude(vd => vd.Vaccinations)
                    .ThenInclude(m => m.MedicalOrganization)
                    .FirstOrDefault(u => u.Id == currentUser.Id);

                if (userWithVaccinations != null)
                {
                    var vaccinationDiary = userWithVaccinations.VaccinationDiary;
                    if (vaccinationDiary != null)
                    {
                        foreach (var vaccinationItem in vaccinationDiary)
                        {
                            var vc = vaccinationItem.Vaccinations;
                            foreach (var v in vc)
                            {
                                string serial = v.Serial;
                                string vaccineName = v.Vaccine.VaccineName;
                                string medicalOrganization = v.MedicalOrganization.OrganizationName;
                                userVaccinationTable.Rows.Add(serial, vaccineName, medicalOrganization);
                            }
                        }
                    }
                }
            }
        }
        private void InitChildVaccinationTab()
        {
            using (VaccineCalendarContext context = new())
            {
                // Загружаем пользователя с детьми
                var userWithChildren = context.Users
                    .Include(u => u.Children)
                    .FirstOrDefault(u => u.Id == currentUser.Id);

                if (userWithChildren != null)
                {
                    // Устанавливаем источник данных для ComboBox
                    childChoiceComboBox.DataSource = userWithChildren.Children.ToList();
                    childChoiceComboBox.DisplayMember = "FirstName"; // Используйте свойство, которое хотите отображать
                    childChoiceComboBox.ValueMember = "Id"; // Используйте свойство, которое хотите использовать в качестве значения
                }
            }
        }
        private void InitStatusLabel()
        {
            userNameLabel.Text = $"Вы авторизованы за {currentUser.FirstName}";
            statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            userNameLabel.Alignment = ToolStripItemAlignment.Right;
        }


        private void displayButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("======");
            Child selectedChild = (Child)childChoiceComboBox.SelectedItem;
            Console.WriteLine(selectedChild);
            if (selectedChild != null)
            {
                using (VaccineCalendarContext context = new())
                {
                    var childWithVaccinations = context.Childs
                        .Include(c => c.VaccinationDiary)
                            .ThenInclude(vd => vd.Vaccinations)
                                .ThenInclude(w => w.Vaccine)
                        .Include(c => c.VaccinationDiary)
                            .ThenInclude(vd => vd.Vaccinations)
                                .ThenInclude(m => m.MedicalOrganization)
                        .FirstOrDefault(c => c.Id == selectedChild.Id);

                    if (childWithVaccinations != null)
                    {
                        childVaccinationTable.Rows.Clear();

                        foreach (var vaccinationItem in childWithVaccinations.VaccinationDiary)
                        {
                            foreach (var v in vaccinationItem.Vaccinations)
                            {
                                string serial = v.Serial;
                                string vaccineName = v.Vaccine.VaccineName;
                                string medicalOrganization = v.MedicalOrganization.OrganizationName;
                                childVaccinationTable.Rows.Add(serial, vaccineName, medicalOrganization);
                            }
                        }
                    }
                }
            }
        }
    }
}


