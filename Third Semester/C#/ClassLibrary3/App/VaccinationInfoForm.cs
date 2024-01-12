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
using vaccinecalend.Migrations;

namespace App
{
    public partial class VaccinationInfoForm : Form
    {
        public VaccinationInfoForm(string serial, string vaccine, string medorg)
        {
            InitializeComponent();
            this.serial = serial;
            this.vaccine = vaccine;
            this.medorg = medorg;
            init();

        }
        private string serial;
        private string vaccine;


        private string medorg;

        private void init()
        {
            serialLabel.Text = serial;
            vaccineLabel.Text = vaccine;
            medorgLabel.Text = medorg;
        }


        private void medorgInfoButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                MedicalOrganization medicalOrganization = context.MedicalOrganizations
                    .FirstOrDefault(m => m.OrganizationName == medorg);
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
                Vaccination vaccination = context.Vaccinations
                    .FirstOrDefault(m => m.Serial == serial);
                if (vaccination != null)
                {
                    addReactionForm addReactionForm = new addReactionForm(vaccination);
                    addReactionForm.ShowDialog();
                }
            }
        }
    }
}
