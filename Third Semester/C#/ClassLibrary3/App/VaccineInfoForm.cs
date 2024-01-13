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
    public partial class vaccineInfoForm : Form
    {
        public vaccineInfoForm(Guid id)
        {
            InitializeComponent();
            this.id = id;
            Init();
        }
        private Guid id;
        private void Init()
        {
            using (var context = new VaccineCalendarContext())
            {
                Vaccine? vaccine = context.Vaccines
                    .Where(v => v.VaccineId == id)
                    .FirstOrDefault();
                validPeriodLabel.Text = vaccine.ValidPeriod;
                nameLabel.Text = vaccine.VaccineName;
                countryLabel.Text = vaccine.ManufactorCountry;
            }
        }


    }
}
