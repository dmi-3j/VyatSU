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
    public partial class VaccinationInfoForm : Form
    {
        public VaccinationInfoForm(Guid id, bool flag)
        {
            InitializeComponent();
            this.vaccinationId = id;
            this.flag = flag;
            InitData();
        }
        private bool flag;
        private Guid vaccinationId;
        private Guid vaccineId;
        private void InitData()
        {
            using (var context = new VaccineCalendarContext())
            {
                if (flag) addReactionButton.Visible = false;

                Vaccination? vaccination = context.Vaccinations
                    .Include(v => v.Vaccine)
                        .Include(v => v.MedicalOrganization)
                            .FirstOrDefault(v => v.VaccinationId == vaccinationId);
                vaccineId = vaccination.Vaccine.VaccineId;

                serialLabel.Text = vaccination.Serial;
                vaccineLabel.Text = vaccination.Vaccine.VaccineName;
                medorgLabel.Text = vaccination.MedicalOrganization.OrganizationName;

                List<CompleteVaccineComponent> completeVaccineComponents = context.CompleteVaccineComponents
                    .Include(cvc => cvc.VaccineComponent)
                        .Where(cvc => cvc.VaccinationId == vaccinationId).ToList();

                foreach (var component in completeVaccineComponents)
                {
                    string componentName = component.VaccineComponent.Name;
                    string componentStructure = component.VaccineComponent.Structure;
                    string componentType = component.VaccineComponent.Type;
                    string componentInterval = component.VaccineComponent.IntervalOfComponent;
                    string date = component.VaccinationDate.Date.ToString("yyyy-MM-dd");
                    componentsInfoTable.Rows.Add(componentName, componentStructure, componentType, componentInterval, date);
                }
            }
        }

        private void medorgInfoButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                Vaccination? vaccination = context.Vaccinations
                    .Include(v => v.MedicalOrganization)
                        .FirstOrDefault(v => v.VaccinationId == vaccinationId);

                MedicalOrganization? medicalOrganization = context.MedicalOrganizations
                    .FirstOrDefault(m => m.OrganizationId == vaccination.MedicalOrganization.OrganizationId);
                if (medicalOrganization != null)
                {
                    medicalOrganizationInfoForm infoForm = new medicalOrganizationInfoForm(medicalOrganization);
                    infoForm.ShowDialog();
                }
            }
        }

        private void addReactionButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                Vaccination? vaccination = context.Vaccinations
                    .FirstOrDefault(m => m.VaccinationId == vaccinationId);
                if (vaccination != null)
                {
                    addReactionForm addReactionForm = new addReactionForm(vaccination);
                    addReactionForm.ShowDialog();
                }
            }
        }

        private void vaccineInfoButton_Click(object sender, EventArgs e)
        {
            vaccineInfoForm vaccineInfoForm = new vaccineInfoForm(vaccineId);
            vaccineInfoForm.ShowDialog();
        }

        private void showReactionButton_Click(object sender, EventArgs e)
        {
            ReactionsForm reactionsForm = new ReactionsForm(vaccinationId, flag);
            reactionsForm.ShowDialog();
        }
    }
}