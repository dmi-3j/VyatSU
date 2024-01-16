using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            Init(currentUser);
            Init(currentUser, statusStrip);
            Init(currentUser, userVaccinationTable);
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
                Init(currentUser, childChoiceComboBox);
            }
        }

        private void GetVaccinationsForTab(Guid id, DataGridView dataGridView)
        {
            using (VaccineCalendarContext context = new())
            {
                var vaccinatedWithVaccinations = context.Vaccinated
                    .Include(u => u.VaccinationDiary)
                        .ThenInclude(vd => vd.Vaccinations)
                            .ThenInclude(w => w.Vaccine)
                    .Include(u => u.VaccinationDiary)
                        .ThenInclude(vd => vd.Vaccinations)
                            .ThenInclude(m => m.MedicalOrganization)
                    .FirstOrDefault(u => u.Id == id);

                if (vaccinatedWithVaccinations != null)
                {
                    var vaccinationDiary = vaccinatedWithVaccinations.VaccinationDiary;
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
                                    .Where(cvc => cvc.VaccinationId == v.VaccinationId).Count();
                                int cntOfAllComponents = context.Components
                                    .Where(c => c.VaccineId == v.VaccineId).Count();
                                string countOfCompleteComponents = $"{cntOfCompleteComponents} / {cntOfAllComponents}";
                                DateTime date = context.CompleteVaccineComponents
                                    .Where(cvc => cvc.VaccinationId == v.VaccinationId)
                                        .Select(cvc => cvc.VaccinationDate).Max();
                                string dateOfLastComponent = date.Date.ToString("yyyy-MM-dd");
                                var lastComponentId = context.CompleteVaccineComponents
                                    .Where(cvc => cvc.VaccinationId == v.VaccinationId)
                                        .OrderByDescending(cvc => cvc.VaccinationDate)
                                            .Select(cvc => cvc.VaccineComponent.ComponentId).FirstOrDefault();
                                string? interval = context.Components
                                    .Where(c => c.ComponentId == lastComponentId)
                                        .Select(c => c.IntervalOfComponent).FirstOrDefault();
                                if (cntOfAllComponents == cntOfCompleteComponents) interval = v.TimeInterval;
                                DateTime recommendNextDate = DBService.AddInterval(date, interval);
                                string nextRecommendDate = recommendNextDate.Date.ToString("yyyy-MM-dd");
                                string medicalOrganization = v.MedicalOrganization.OrganizationName;
                                string flag = "Нет";
                                if (v.FlagIsDone == true) flag = "Да";
                                dataGridView.Rows.Add(serial, vaccineName, countOfCompleteComponents, dateOfLastComponent, nextRecommendDate, medicalOrganization, flag);
                            }
                        }
                    }
                }
            }
        }

        private void Init(vaccinecalend.User user)
        {
            firstNameLabel.Text = user.FirstName;
            lastNameLabel.Text = user.LastName;
            dobLabel.Text = user.DateOfBirth.Date.ToString("dd.MM.yyyy");
            phoneLabel.Text = user.PhoneNumber;
            addressLabel.Text = user.Address;
            inshuranceNumberLabel.Text = user.InshuranceNumber.ToString();
        }
        private void Init(vaccinecalend.User user, DataGridView dataGridView)
        {
            GetVaccinationsForTab(user.Id, dataGridView);
        }
        private void Init(vaccinecalend.User user, StatusStrip status)
        {
            userNameLabel.Text = $"Вы авторизованы за {user.FirstName}";
            status.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            userNameLabel.Alignment = ToolStripItemAlignment.Right;
        }
        private void Init(vaccinecalend.User user, ComboBox combo)
        {
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            using (VaccineCalendarContext context = new())
            {
                var userWithChildren = context.Users
                    .Include(u => u.Children)
                        .FirstOrDefault(u => u.Id == user.Id);

                if (userWithChildren != null)
                {
                    combo.DataSource = userWithChildren.Children.ToList();
                    combo.DisplayMember = "FirstName";
                    combo.ValueMember = "Id";
                }
            }
        }


        private void displayButton_Click(object sender, EventArgs e)
        {
            Vaccinated selectedChild = (Vaccinated)childChoiceComboBox.SelectedItem;
            if (selectedChild != null)
            {
                childVaccinationTable.Rows.Clear();
                GetVaccinationsForTab(selectedChild.Id, childVaccinationTable);
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
                    using (var context = new VaccineCalendarContext())
                    {
                        Guid vaccinationId = context.Vaccinations
                            .Where(v => v.Serial == userVaccinationTable.Rows[e.RowIndex].Cells["VaccinationSerial"].Value.ToString())
                                .Select(v => v.VaccinationId).FirstOrDefault();
                        VaccinationInfoForm infoForm = new VaccinationInfoForm(vaccinationId, false);
                        infoForm.ShowDialog();
                    }
                }
            }
        }

        private void addChildForUserButton_Click(object sender, EventArgs e)
        {
            AddChildForUserForm childForUser = new AddChildForUserForm(currentUser);
            childForUser.ShowDialog();
            Init(currentUser, childChoiceComboBox);
            if (!tabControl1.TabPages.Contains(childVaccinationTab)) tabControl1.TabPages.Add(childVaccinationTab);
        }

        private void updateUserDataButton_Click(object sender, EventArgs e)
        {
            UpdateUserForm updateUserForm = new UpdateUserForm(currentUser);
            updateUserForm.ShowDialog();
            Init(currentUser);
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
                                .Select(v => v.VaccinationId).FirstOrDefault();
                        VaccinationInfoForm infoForm = new VaccinationInfoForm(vaccinationId, false);
                        infoForm.ShowDialog();
                    }
                }
            }
        }

       
    }
}