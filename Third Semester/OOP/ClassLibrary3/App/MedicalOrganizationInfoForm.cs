using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using vaccinecalend;

namespace App
{
    public partial class medicalOrganizationInfoForm : Form
    {
        public medicalOrganizationInfoForm(MedicalOrganization medicalOrganization)
        {
            InitializeComponent();
            this.medicalOrganization = medicalOrganization;
            Init();
        }
        private MedicalOrganization medicalOrganization;
        private void Init()
        {
            nameLabel.Text = medicalOrganization.OrganizationName;
            phoneLabel.Text = medicalOrganization.PhoneNumber;
            addressLabel.Text = medicalOrganization.Address;
        }
    }
}
