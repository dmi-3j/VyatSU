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
    public partial class AddRecordToVaccinationForm : Form
    {
        public AddRecordToVaccinationForm(vaccinecalend.User user)
        {
            InitializeComponent();
            this.user = user;
            datePicker.MinDate = DateTime.Now;
            InitMedOrgComboBox();
            InitVaccineComboBox();
            vaccinated = user.Id;
        }
        public AddRecordToVaccinationForm(vaccinecalend.Child child)
        {
            InitializeComponent();
            this.child = child;
            datePicker.MinDate = DateTime.Now;
            InitMedOrgComboBox();
            InitVaccineComboBox();
            vaccinated = child.Id;
        }
        private Child child;
        private vaccinecalend.User user;
        private Guid vaccinated;
        private void InitMedOrgComboBox()

        {
            using (var context = new VaccineCalendarContext())
            {
                var medicalOrganizations = context.MedicalOrganizations.ToList();
                medOrgComboBox.DataSource = medicalOrganizations;
                medOrgComboBox.DisplayMember = "OrganizationName";
                medOrgComboBox.ValueMember = "OrganizationId";
            }
        }
        private void InitVaccineComboBox()
        {
            using (var context = new VaccineCalendarContext())
            {
                var vaccines = context.Vaccines.ToList();
                vaccineComboBox.DataSource = vaccines;
                vaccineComboBox.DisplayMember = "VaccineName";
                vaccineComboBox.ValueMember = "VaccineId";
            }
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                try
                {
                    DBService service = new DBService(context);
                    MedicalOrganization selectedMedicalOrganization = (MedicalOrganization)medOrgComboBox.SelectedItem;
                    Vaccine selectedVaccine = (Vaccine)vaccineComboBox.SelectedItem;
                    RecordToVaccination record = new RecordToVaccination()
                    {
                        RecordDate = datePicker.Value.Date,
                        VaccinatedId = vaccinated,
                        VaccineId = selectedVaccine.VaccineId,
                        OrganizationId = selectedMedicalOrganization.OrganizationId


                    };
                    service.AddRecordToVaccination(record);
                    MessageBox.Show("Запись успешно отправлена! Ожидайте звонка с подтверждением.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
