using Microsoft.EntityFrameworkCore;
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
    public partial class UserInfoForm : Form
    {
        public UserInfoForm(Guid id)
        {
            InitializeComponent();
            this.vaccinatedId = id;
            Init();
        }
        private Guid vaccinatedId;
        private Vaccinated? vaccinated;

        private void Init()
        {
            using (var context = new VaccineCalendarContext())
            {
                vaccinationTable.Rows.Clear();
                Vaccinated? vv = context.Vaccinated
                    .FirstOrDefault(v => v.Id == vaccinatedId);
                vaccinated = vv;

                nameLabel.Text = $"{vaccinated.LastName} {vaccinated.FirstName}";

                var userWithVaccinations = context.Vaccinated
                    .Include(u => u.VaccinationDiary)
                        .ThenInclude(vd => vd.Vaccinations)
                            .ThenInclude(w => w.Vaccine)
                    .Include(u => u.VaccinationDiary)
                        .ThenInclude(vd => vd.Vaccinations)
                            .ThenInclude(m => m.MedicalOrganization)
                    .FirstOrDefault(u => u.Id == vaccinated.Id);

                if (userWithVaccinations != null)
                {
                    var vaccinationDiary = userWithVaccinations.VaccinationDiary;
                    if (vaccinationDiary != null)
                    {
                        foreach (var vaccinationItem in vaccinationDiary)
                        {
                            var vc = vaccinationItem.Vaccinations;
                            foreach (Vaccination v in vc)
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
                                var lastComponent = context.CompleteVaccineComponents
                                    .Where(cvc => cvc.VaccinationId == v.VaccinationId)
                                        .OrderByDescending(cvc => cvc.VaccinationDate)
                                            .Select(cvc => cvc.VaccineComponent.ComponentId).FirstOrDefault();
                                string? interval = context.Components
                                    .Where(c => c.ComponentId == lastComponent)
                                        .Select(c => c.IntervalOfComponent).FirstOrDefault();
                                if (cntOfAllComponents == cntOfCompleteComponents) interval = v.TimeInterval;

                                DateTime recommendNextDate = AddInterval(date, interval);
                                string nextRecommendDate = recommendNextDate.Date.ToString("yyyy-MM-dd");

                                string medicalOrganization = v.MedicalOrganization.OrganizationName;
                                vaccinationTable.Rows.Add(v.VaccinationId, serial, vaccineName, medicalOrganization, countOfCompleteComponents, dateOfLastComponent, nextRecommendDate);
                            }
                        }
                    }
                }
            }
        }
        private static DateTime AddInterval(DateTime startDate, string? intervalString)
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

        private void addVaccinationButton_Click(object sender, EventArgs e)
        {
            addVaccinationForm addVaccinationForm = new addVaccinationForm(vaccinatedId);
            addVaccinationForm.ShowDialog();
            Init();
        }

        private void vaccinationTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == vaccinationTable.Columns["action"].Index)
            {

                if (vaccinationTable.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {
                    using (var context = new VaccineCalendarContext())
                    {
                        Guid vaccinationId = Guid.Parse(vaccinationTable.Rows[e.RowIndex].Cells["id"].Value.ToString());
                        VaccinationInfoForm infoForm = new VaccinationInfoForm(vaccinationId, true);
                        infoForm.ShowDialog();
                    }
                }
            }
        }
    }
}
