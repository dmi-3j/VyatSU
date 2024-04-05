using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AISDemoApp;

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
        private string path;
        private void uploadPhotoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(path);
                string destinationDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Images");
                string fileName = Guid.NewGuid() + ".jpg";

                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }
                string destinationPath = Path.Combine(destinationDirectory, fileName);
                File.Copy(path, destinationPath, true);
                path = destinationPath;
            }
        }

        private void addInventoryForm_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = username;
            comboBox1.SelectedIndex = 0;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //AdminForm af = new AdminForm(username);
            //af.MdiParent = MdiParent;
            //af.Show();
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }
            decimal price = numericUpDown1.Value;
            string type = comboBox1.SelectedItem.ToString();
            decimal size = numericUpDown2.Value;
            if (path == null)
            {
                path = "D:\\Documents\\GitHub\\VyatSu\\Fourth Semester\\AIS\\AISDemoApp\\App\\bin\\Images\\default.jpg";
            }
            using Context context = new();
            {
                Inventory inv = new Inventory()
                {
                    InventoryName = title,
                    InventoryType = type,
                    RentPrice = price,
                    PhotoPath = path,
                    Size = size
                };
                DBService db = new DBService(context);
                db.saveInventory(inv);
            }
            MessageBox.Show("Успешно добавлено!");
            backButton_Click(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            profile p = new profile(username);
            p.MdiParent = MdiParent;
            //Close();
            p.Show();
        }
    }
}
