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
    public partial class RecordsForm : Form
    {
        public RecordsForm()
        {
            InitializeComponent();
            InitOrganizationCombobox();
            choiceOrganizationComboBox.SelectedIndex = 0;
        }
        private void InitOrganizationCombobox()
        {
            using (var context = new VaccineCalendarContext())
            {
                List<MedicalOrganization> medicalOrganization = context.MedicalOrganizations.ToList();
                choiceOrganizationComboBox.DataSource = medicalOrganization;
                choiceOrganizationComboBox.DisplayMember = "OrganizationName";
                choiceOrganizationComboBox.ValueMember = "OrganizationId";

            }
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            recordsTable.Rows.Clear();
            Guid? organizationId = (Guid?)choiceOrganizationComboBox.SelectedValue;
            using (var context = new VaccineCalendarContext())
            {

                List<RecordToVaccination> records = context.Records
                    .Where(r => r.OrganizationId == organizationId)
                    .ToList();
                foreach (RecordToVaccination record in records)
                {
                    if (record.RecordDate < DateTime.Now.Date) continue;
                    string recordDate = record.RecordDate.ToString("yyyy-MM-dd");
                    Vaccine? vaccine = context.Vaccines
                    .Where(v => v.VaccineId == record.VaccineId)
                    .FirstOrDefault();
                    string vaccineName = vaccine.VaccineName;

                    Vaccinated? vaccinated = context.Vaccinated
                        .Where(v => v.Id == record.VaccinatedId)
                        .FirstOrDefault();

                    string id = record.RecordId.ToString();
                    string firstName = vaccinated.FirstName;
                    string lastName = vaccinated.LastName;
                    string insNumber = vaccinated.InshuranceNumber;
                    string dob = vaccinated.DateOfBirth.ToString("yyyy-MM-dd");
                    string phone = vaccinated.PhoneNumber;

                    recordsTable.Rows.Add(id, lastName, firstName, dob, phone, insNumber, vaccineName, recordDate);
                }
            }

        }

        private void recordsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == recordsTable.Columns["action"].Index)
            {

                if (recordsTable.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {
                    using (var context = new VaccineCalendarContext())
                    {
                        DBService service = new DBService(context);
                        

                        RecordToVaccination? record = context.Records
                            .Where(r => r.RecordId == Guid.Parse(recordsTable.Rows[e.RowIndex].Cells["RecordId"].Value.ToString()))
                            .FirstOrDefault();
                        if (record != null) service.DeleteRecordToVaccination(record);
                        displayButton_Click(sender, e);
                    }
                }
            }
        }

    }
}
