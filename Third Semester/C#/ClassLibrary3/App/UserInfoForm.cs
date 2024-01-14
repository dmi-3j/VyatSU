using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class UserInfoForm : Form
    {
        public UserInfoForm(Guid id)
        {
            InitializeComponent();
            this.vaccinatedId = id;
        }
        private Guid vaccinatedId;

        private void addVaccinationButton_Click(object sender, EventArgs e)
        {
            addVaccinationForm addOrganizationForm = new addVaccinationForm(vaccinatedId);
            addOrganizationForm.ShowDialog();
        }
    }
}
