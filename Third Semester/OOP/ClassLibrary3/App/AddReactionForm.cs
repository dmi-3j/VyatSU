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
    public partial class addReactionForm : Form
    {
        public addReactionForm(Vaccination vaccination)
        {
            InitializeComponent();
            this.vaccination = vaccination;
        }
        private Vaccination vaccination;

        private void addReactionButton_Click(object sender, EventArgs e)
        {
            using (var context = new VaccineCalendarContext())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(reactionTextBox.Text.Trim()))
                    {
                        MessageBox.Show($"Текст реакции не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string reaction = reactionTextBox.Text.Trim();
                    ReactionOnVaccination reactionOnVaccination = new();
                    reactionOnVaccination.DescriptionOfReaction = reaction;
                    reactionOnVaccination.DateOfReaction = DateTime.Now.Date;
                    reactionOnVaccination.VaccinationId = vaccination.VaccinationId;
                    reactionOnVaccination.ReactionId = Guid.NewGuid();
                    DBService service = new DBService(context);
                    service.AddReactionOnVaccination(reactionOnVaccination);
                    MessageBox.Show("Реакция успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
