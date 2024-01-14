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
    public partial class SerialInputForm : Form
    {
        public SerialInputForm()
        {
            InitializeComponent();
        }
        public string Serial { get; set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            Serial = input.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
