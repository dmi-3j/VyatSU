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
            CheckForChild();
        }
        private void CheckForChild()
        {
            using (var context = new VaccineCalendarContext())
            {
                var userWithChilds = context.Users
                .Include(u => u.Children)
                .FirstOrDefault(u => u.Id == currentUser.Id);
                //if (userWithChilds.Children.Count == 0) tabControl1.TabPages[2].Parent = null;
                if (userWithChilds.Children.Count == 0) tabControl1.TabPages.Remove(childVaccinationTab);
                InitChildVaccinationTab();
            }
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
                    childChoiceComboBox.DataSource = userWithChildren.Children.ToList();
                    childChoiceComboBox.DisplayMember = "FirstName";
                    childChoiceComboBox.ValueMember = "Id";
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

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void userVaccinationTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == userVaccinationTable.Columns["infoVaccinaton"].Index)
            {
                // Проверяем, что тип содержимого в ячейке - кнопка
                if (userVaccinationTable.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {
                    // Обработка нажатия кнопки в столбце infoVaccinaton
                    string serial = userVaccinationTable.Rows[e.RowIndex].Cells["VaccinationSerial"].Value.ToString();
                    string vaccineName = userVaccinationTable.Rows[e.RowIndex].Cells["VaccineName"].Value.ToString();
                    string medicalOrganization = userVaccinationTable.Rows[e.RowIndex].Cells["MedicalOrganizatiin"].Value.ToString();

                    // Создание и отображение новой формы VaccinationInfoForm
                    VaccinationInfoForm infoForm = new VaccinationInfoForm(serial, vaccineName, medicalOrganization);
                    infoForm.ShowDialog();
                }
            }
        }

        private void addChildForUserButton_Click(object sender, EventArgs e)
        {
            AddChildForUserForm childForUser = new AddChildForUserForm(currentUser);
            childForUser.ShowDialog();
            InitChildVaccinationTab();
            if (!tabControl1.TabPages.Contains(childVaccinationTab)) tabControl1.TabPages.Add(childVaccinationTab);


        }
    }
}


