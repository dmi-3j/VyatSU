using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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

    public partial class UserForm : Form
    {


        private vaccinecalend.User currentUser;
        public UserForm(vaccinecalend.User user)
        {
            InitializeComponent();
            currentUser = user;
            InitStatusLabel();

        }
        private void InitStatusLabel()
        {
            userNameLabel.Text = $"Вы авторизованы за {currentUser.FirstName}";
            statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            userNameLabel.Alignment = ToolStripItemAlignment.Right;
        }

        private void vaccinationBox_Click(object sender, EventArgs e)
        {

        }
        private void initBox()
        {
            vaccinationBox.Clear();
            using (VaccineCalendarContext context = new())
            {

                var userWithVaccinations = context.Users
                    .Include(u => u.VaccinationDiary)
                    .ThenInclude(vd => vd.Vaccinations)
                    .ThenInclude(w => w.Vaccine)
                    .Include(u => u.VaccinationDiary)
                    .ThenInclude(vd => vd.Vaccinations)
                    .ThenInclude(m => m.MedicalOrganization)
                    .FirstOrDefault(u => u.Id == currentUser.Id);
                if (userWithVaccinations != null)
                {
                    vaccinationBox.AppendText($"User: {userWithVaccinations.FirstName} {userWithVaccinations.LastName}\n");

                    var vaccinationDiary = userWithVaccinations.VaccinationDiary;
                    if (vaccinationDiary != null)
                    {
                        foreach (var vaccinationItem in vaccinationDiary)
                        {
                            var vc = vaccinationItem.Vaccinations;
                            foreach (var v in vc)
                            {

                                vaccinationBox.AppendText($"\nVaccination: {v.Serial}\n");
                                var vaiicne = v.Vaccine;
                                vaccinationBox.AppendText($"Vaccine: {vaiicne.VaccineName}\n");
                                var medicalOrganizationn = v.MedicalOrganization;
                                vaccinationBox.AppendText($"Medical Organization: {medicalOrganizationn.OrganizationName}\n");
                            }
                        }
                    }
                }
            }
        }
        private void initBox2()
        {
            vaccinationBox.Clear();
            using (VaccineCalendarContext context = new())
            {
                var userWithVaccinations = context.Users
                .Include(u => u.VaccinationDiary)
                    .ThenInclude(vd => vd.Vaccinations)
                    .ThenInclude(w => w.Vaccine)
                    .Include(u => u.VaccinationDiary)
                    .ThenInclude(vd => vd.Vaccinations)
                    .ThenInclude(m => m.MedicalOrganization)
                .Include(u => u.Children)
                    .ThenInclude(c => c.VaccinationDiary)
                    .ThenInclude(vd => vd.Vaccinations)
                    .ThenInclude(v => v.Vaccine)
                    .Include(c => c.VaccinationDiary)
                    .ThenInclude(vd => vd.Vaccinations)
                    .ThenInclude(v => v.MedicalOrganization)
                .FirstOrDefault(u => u.Id == currentUser.Id);

                if (userWithVaccinations != null)
                {
                    vaccinationBox.Text += $"User: {userWithVaccinations.FirstName} {userWithVaccinations.LastName}\n";

                    // Вакцинации пользователя
                    var userVaccinationDiary = userWithVaccinations.VaccinationDiary;
                    if (userVaccinationDiary != null)
                    {
                        foreach (var vaccinationItem in userVaccinationDiary)
                        {
                            var vc = vaccinationItem.Vaccinations;
                            foreach (var v in vc)
                            {
                                vaccinationBox.Text += $"\nVaccination: {v.Serial}\n";
                                var vaccinee = v.Vaccine;
                                vaccinationBox.Text += $"Vaccine: {vaccinee.VaccineName}\n";
                                var medicalOrganizationn = v.MedicalOrganization;
                                vaccinationBox.Text += $"Medical Organization: {medicalOrganizationn.OrganizationName}\n";
                            }
                        }
                    }

                    // Вакцинации детей пользователя
                    var children = userWithVaccinations.Children;
                    foreach (var child in children)
                    {
                        var childVaccinationDiary = child.VaccinationDiary;
                        if (childVaccinationDiary != null)
                        {
                            vaccinationBox.Text += $"\nChild: {child.FirstName} {child.LastName}\n";
                            if (childVaccinationDiary.Count == 0)
                            {
                                vaccinationBox.Text += "Нет вакцинаций\n";
                            }
                            foreach (var vaccinationItem in childVaccinationDiary)
                            {
                                var vc = vaccinationItem.Vaccinations;
                                foreach (var v in vc)
                                {
                                    vaccinationBox.Text += $"\nVaccination: {v.Serial}\n";
                                    var vaccinee = v.Vaccine;
                                    vaccinationBox.Text += $"Vaccine: {vaccinee.VaccineName}\n";
                                    var medicalOrganizationn = v.MedicalOrganization;
                                    vaccinationBox.Text += $"Medical Organization: {medicalOrganizationn.OrganizationName}\n";
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vaccinationBox.Clear();
            initBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initBox2();
        }
    }
}


