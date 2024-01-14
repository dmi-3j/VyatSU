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
                                int cntOfCompleteComponents = context.CompleteVaccineComponents
                                    .Where(cvc => cvc.VaccinationId == v.VaccinationId)
                                    .Count();
                                int cntOfAllComponents = context.Components
                                    .Where(c => c.VaccineId == v.VaccineId)
                                    .Count();
                                string countOfCompleteComponents = $"{cntOfCompleteComponents} / {cntOfAllComponents}";
                                DateTime date = context.CompleteVaccineComponents
                                    .Where(cvc => cvc.VaccinationId == v.VaccinationId)
                                    .Select(cvc => cvc.VaccinationDate)
                                    .Max();
                                string dateOfLastComponent = date.Date.ToString("yyyy-MM-dd");
                                var lastComponent = context.CompleteVaccineComponents
                                    .Where(cvc => cvc.VaccinationId == v.VaccinationId)
                                    .OrderByDescending(cvc => cvc.VaccinationDate)
                                    .Select(cvc => cvc.VaccineComponent.ComponentId)
                                    .FirstOrDefault();

                                string? interval = context.Components
                                    .Where(c => c.ComponentId == lastComponent)
                                    .Select(c => c.IntervalOfComponent)
                                    .FirstOrDefault();

                                DateTime recommendNextDate = AddInterval(date, interval);
                                string nextRecommendDate = recommendNextDate.Date.ToString("yyyy-MM-dd");

                                string medicalOrganization = v.MedicalOrganization.OrganizationName;
                                string flag = "Нет";
                                if (v.FlagIsDone == true) flag = "Да";
                                userVaccinationTable.Rows.Add(serial, vaccineName, countOfCompleteComponents, dateOfLastComponent, nextRecommendDate, medicalOrganization, flag);
                            }
                        }
                    }
                }
            }
        }

        private static DateTime AddInterval(DateTime startDate, string intervalString)
        {
            if (intervalString == null) return startDate + TimeSpan.FromDays(0);
            int intervalValue = int.Parse(intervalString.Split(' ')[0]);
            string intervalType = intervalString.Split(' ')[1];

            TimeSpan interval;
            switch (intervalType)
            {
                case "неделя":
                case "недели":
                    interval = TimeSpan.FromDays(intervalValue * 7);
                    break;
                case "месяц":
                case "месяца":
                case "месяцев":
                    interval = TimeSpan.FromDays(intervalValue * 30);
                    break;
                case "год":
                case "года":
                case "лет":
                    interval = TimeSpan.FromDays(intervalValue * 365);
                    break;
                default:
                    throw new ArgumentException("Неподдерживаемый тип интервала");
            }
            DateTime endDate = startDate + interval;
            return endDate;
        }

        private void InitChildVaccinationTab()
        {
            using (VaccineCalendarContext context = new())
            {
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
            Child selectedChild = (Child)childChoiceComboBox.SelectedItem;
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
                                int cntOfCompleteComponents = context.CompleteVaccineComponents
                                    .Where(cvc => cvc.VaccinationId == v.VaccinationId)
                                    .Count();
                                int cntOfAllComponents = context.Components
                                    .Where(c => c.VaccineId == v.VaccineId)
                                    .Count();
                                string countOfCompleteComponents = $"{cntOfCompleteComponents} / {cntOfAllComponents}";
                                DateTime date = context.CompleteVaccineComponents
                                    .Where(cvc => cvc.VaccinationId == v.VaccinationId)
                                    .Select(cvc => cvc.VaccinationDate)
                                    .Max();
                                string dateOfLastComponent = date.Date.ToString("yyyy-MM-dd");
                                var lastComponent = context.CompleteVaccineComponents
                                    .Where(cvc => cvc.VaccinationId == v.VaccinationId)
                                    .OrderByDescending(cvc => cvc.VaccinationDate)
                                    .Select(cvc => cvc.VaccineComponent.ComponentId)
                                    .FirstOrDefault();

                                string? interval = context.Components
                                    .Where(c => c.ComponentId == lastComponent)
                                    .Select(c => c.IntervalOfComponent)
                                    .FirstOrDefault();

                                DateTime recommendNextDate = AddInterval(date, interval);
                                string nextRecommendDate = recommendNextDate.Date.ToString("yyyy-MM-dd");

                                string medicalOrganization = v.MedicalOrganization.OrganizationName;
                                string flag = "Нет";
                                if (v.FlagIsDone == true) flag = "Да";
                                childVaccinationTable.Rows.Add(serial, vaccineName, countOfCompleteComponents, dateOfLastComponent, nextRecommendDate, medicalOrganization, flag);

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

                if (userVaccinationTable.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {
                    using (var context = new VaccineCalendarContext()) {
                        Guid vaccinationId = context.Vaccinations
                            .Where(v => v.Serial == userVaccinationTable.Rows[e.RowIndex].Cells["VaccinationSerial"].Value.ToString())
                            .Select(v => v.VaccinationId)
                            .FirstOrDefault();
                        VaccinationInfoForm infoForm = new VaccinationInfoForm(vaccinationId);
                        infoForm.ShowDialog();
                    }
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

        private void updateUserDataButton_Click(object sender, EventArgs e)
        {
            UpdateUserForm updateUserForm = new UpdateUserForm(currentUser);
            updateUserForm.ShowDialog();
            InitProfileTab();
        }

        private void addUserRecordToVaccination_Click(object sender, EventArgs e)
        {
            AddRecordToVaccinationForm addRecordToVaccination = new AddRecordToVaccinationForm(currentUser);
            addRecordToVaccination.ShowDialog();
        }

        private void addChildRecordButton_Click(object sender, EventArgs e)
        {
            Child selectedChild = (Child)childChoiceComboBox.SelectedItem;
            AddRecordToVaccinationForm addRecordToVaccination = new AddRecordToVaccinationForm(selectedChild);
            addRecordToVaccination.ShowDialog();
        }

        private void childVaccinationTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == childVaccinationTable.Columns["infoChildVaccinaton"].Index)
            {

                if (childVaccinationTable.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {

                    using (var context = new VaccineCalendarContext())
                    {
                        Guid vaccinationId = context.Vaccinations
                            .Where(v => v.Serial == childVaccinationTable.Rows[e.RowIndex].Cells["childVaccinationSerial"].Value.ToString())
                            .Select(v => v.VaccinationId)
                            .FirstOrDefault();
                        VaccinationInfoForm infoForm = new VaccinationInfoForm(vaccinationId);
                        infoForm.ShowDialog();
                    }
                }
            }
        }
    }
}
