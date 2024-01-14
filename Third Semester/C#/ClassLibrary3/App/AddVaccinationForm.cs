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
            InitMedOrgCombobox();
            InitVaccineComboBox();
            vaccinatedId = id;
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
                    .Where(c => c.VaccineId == id)
                    .ToList();
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
            Guid vaccineId = (Guid)vaccineComboBox.SelectedValue;
            InitVaccineComponentCombobox(vaccineId);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            vaccineGroup.Enabled = true;
        }
        private bool CheckForExistVaccinationForThisVaccine(Guid vaccineId, Guid vaccinatedId)
        {
            using (var context = new VaccineCalendarContext())
            {
                bool hasUnfinishedVaccination = context.VaccinationDiary
                    .Any(vd => vd.VaccinationId == vaccineId &&
                               vd.VaccinatedId == vaccinatedId &&
                               vd.Vaccinations.Any(v => !v.FlagIsDone));

                return hasUnfinishedVaccination;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Guid vaccineId = (Guid)vaccineComboBox.SelectedValue;
            Guid componentId = (Guid)vaccineComponentComboBox.SelectedValue;
            if(vaccineGroup.Enabled == false)
            {
                //if (CheckForExistVaccinationForThisVaccine(vaccineId))
                //{

                //}
                //else
                //{
                //    //Vaccination vaccination = new Vaccination()
                //    //{
                //    //    Serial = "",
                //    //    FlagIsDone = false,
                //    //    MedicalOrganization = 
                //    //};
                //}
            }
        }
    }
}
