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
    public partial class addInventoryForm : Form
    {
        public addInventoryForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private string username;

        private void uploadPhotoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(selectedFilePath);
            }
        }

        private void addInventoryForm_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = username;
        }
    }
}
