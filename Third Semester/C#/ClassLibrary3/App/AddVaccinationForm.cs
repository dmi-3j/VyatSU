using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vaccinecalend;

namespace App
{
    public partial class addVaccinationForm : Form
    {
        public addVaccinationForm(Guid id)
        {
            InitializeComponent();
            vaccinatedId = id;
        }
        private void addVaccinationForm_Load(object sender, EventArgs e)
        {
            InitMedOrgCombobox();
            InitVaccineComboBox();
        }

        private Guid vaccinatedId;
        private void InitMedOrgCombobox()
        {
            using (var context = new VaccineCalendarContext())
            {
                List<MedicalOrganization> organizations = context.MedicalOrganizations.ToList();

                medOrgComboBox.DataSource = organizations;
                medOrgComboBox.DisplayMember = "OrganizationName";
                medOrgComboBox.ValueMember = "OrganizationId";

            }
            medOrgComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            medOrgComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void InitVaccineComboBox()
        {
            using (var context = new VaccineCalendarContext())
            {
                List<Vaccine> vaccines = context.Vaccines.ToList();

                vaccineComboBox.DataSource = vaccines;
                vaccineComboBox.DisplayMember = "VaccineName";
                vaccineComboBox.ValueMember = "VaccineId";

            }
            vaccineComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            vaccineComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void InitVaccineComponentCombobox(Guid id)
        {
            using (var context = new VaccineCalendarContext())
            {
                List<VaccineComponent> components = context.Components
                    .Where(c => c.VaccineId == id).ToList();
                vaccineComponentComboBox.DataSource = components;
                vaccineComponentComboBox.DisplayMember = "Name";
                vaccineComponentComboBox.ValueMember = "ComponentId";
            }
            vaccineComponentComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            vaccineComponentComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void saveVaccineButton_Click(object sender, EventArgs e)
        {
            vaccineGroup.Enabled = false;
            if (vaccineComboBox.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать вакцину, чтобы продолжить.");
                return;
            }
            Guid vaccineId = (Guid)vaccineComboBox.SelectedValue;
            InitVaccineComponentCombobox(vaccineId);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            vaccineGroup.Enabled = true;
        }
        private bool CheckForExistVaccinationForThisVaccine(Guid vaccineId, Guid vaccinatedId) //проверка, есть ли неавершенная вакцинация по этой вакцине у пользователя
        {
            using (var context = new VaccineCalendarContext())
            {
                bool hasUnfinishedVaccination = context.VaccinationDiary
                    .Include(vd => vd.Vaccinations)
                        .ThenInclude(v => v.Vaccine)
                            .Any(vd => vd.VaccinatedId == vaccinatedId && vd.Vaccinations.Any(v => v.VaccineId == vaccineId && !v.FlagIsDone));
                return hasUnfinishedVaccination;
            }
        }
        private bool ChechForAlreadyDoneComponentForThisVaccination(Guid componentId, Guid vaccinationId) //проверка, поставлен ли этот компонент в рамках этой вакцинации
        {
            using (var context = new VaccineCalendarContext())
            {
                bool hasComponentInVaccination = context.CompleteVaccineComponents
                    .Any(cvc => cvc.VaccinationId == vaccinationId && cvc.VaccineComponent.ComponentId == componentId);
                return hasComponentInVaccination;
            }
        }
        private Guid GetVaccinationIdForThisVaccinatedAndThisVaccine(Guid vaccineId) //получение id вакцинации для этого польователя и этой вакцины
        {
            using (var context = new VaccineCalendarContext())
            {
                var vaccinationId = context.VaccinationDiary
                    .Where(vd => vd.VaccinatedId == vaccinatedId)
                        .SelectMany(vd => vd.Vaccinations)
                            .Where(v => v.VaccineId == vaccineId && !v.FlagIsDone)
                                .Select(v => v.VaccinationId)
                                    .FirstOrDefault();
                return vaccinationId;
            }
        }
        private void CheckForDoneAndUpdateFlagIsDone(Guid vaccinationId, Guid vaccineId) // проверка на завершение вакцинации и обновление флага о выполнении
        {
            using (var context = new VaccineCalendarContext())
            {
                DBService service = new DBService(context);
                int cntOfCompleteComponents = context.CompleteVaccineComponents
                                .Where(cvc => cvc.VaccinationId == vaccinationId).Count();
                int cntOfAllComponents = context.Components
                        .Where(c => c.VaccineId == vaccineId).Count();
                if (cntOfCompleteComponents == cntOfAllComponents)
                {
                    Vaccination vaccination = context.Vaccinations
                        .FirstOrDefault(v => v.VaccinationId == vaccinationId);
                    vaccination.FlagIsDone = true;
                    service.UpdateVaccination(vaccination);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                try
                {
                    if (vaccineComboBox.SelectedItem == null || vaccineGroup.Enabled == true)
                    {
                        MessageBox.Show("Необходимо выбрать вакцину, чтобы продолжить. Выберите вакцину и нажмите кнопку 'Сохранить'.");
                        return;
                    }
                    if (vaccineComponentComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Необходимо выбрать компонент вакцины, чтобы продолжить.");
                        return;
                    }
                    DBService service = new DBService(context);
                    Guid vaccineId = (Guid)vaccineComboBox.SelectedValue;
                    Guid componentId = (Guid)vaccineComponentComboBox.SelectedValue;
                    VaccineComponent component = context.Components
                        .Where(v => v.ComponentId == componentId)
                            .FirstOrDefault();
                    if (vaccineGroup.Enabled == false)
                    {
                        if (CheckForExistVaccinationForThisVaccine(vaccineId, vaccinatedId))
                        {
                            Guid vaccinationId = GetVaccinationIdForThisVaccinatedAndThisVaccine(vaccineId);
                            if (ChechForAlreadyDoneComponentForThisVaccination(componentId, vaccinationId))
                            {
                                MessageBox.Show("Этот компонент уже был поставлен.");
                                return;
                            }
                            else
                            {
                                CompleteVaccineComponent completeComponent = new CompleteVaccineComponent()
                                {
                                    VaccinationId = vaccinationId,
                                    VaccineComponent = component,
                                    VaccinationDate = DateTime.Now.Date,
                                };
                                service.AddCompleteVaccineComponent(completeComponent);

                                CheckForDoneAndUpdateFlagIsDone(vaccinationId, vaccineId);
                                MessageBox.Show("Вакцинация успешно добавлена!");
                                Close();
                            }
                        }
                        else
                        {
                            if (medOrgComboBox.SelectedItem == null)
                            {
                                MessageBox.Show("Необходимо выбрать медицинскую организацию, чтобы продолжить.");
                                return;
                            }
                            Guid organizationId = (Guid)medOrgComboBox.SelectedValue;
                            MedicalOrganization organization = context.MedicalOrganizations.FirstOrDefault(o => o.OrganizationId == organizationId);
                            Vaccine vaccine = context.Vaccines.FirstOrDefault(v => v.VaccineId == vaccineId);
                            string serial = "";
                            SerialInputForm serialInputForm = new SerialInputForm();
                            if (serialInputForm.ShowDialog() == DialogResult.OK) serial = serialInputForm.Serial;
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                Vaccination vaccination = new Vaccination()
                                {
                                    Serial = serial,
                                    FlagIsDone = false,
                                    MedicalOrganization = organization,
                                    TimeInterval = vaccine.ValidPeriod,
                                    Vaccine = vaccine,
                                };
                                service.AddVaccination(vaccination);
                                CompleteVaccineComponent completeComponent = new CompleteVaccineComponent()
                                {
                                    VaccinationId = vaccination.VaccinationId,
                                    VaccineComponent = component,
                                    VaccinationDate = DateTime.Now.Date,
                                };
                                service.AddCompleteVaccineComponent(completeComponent);
                                var vaccinationDiary = new VaccinationDiary
                                {
                                    VaccinatedId = vaccinatedId,
                                    VaccinationId = vaccination.VaccinationId
                                };
                                vaccinationDiary.Vaccinations.Add(vaccination);
                                service.AddVaccinationDiary(vaccinationDiary);
                                transaction.Commit();
                                CheckForDoneAndUpdateFlagIsDone(vaccination.VaccinationId, vaccineId);
                            }
                            MessageBox.Show("Вакцинация успешно добавлена!");
                            Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }
}
