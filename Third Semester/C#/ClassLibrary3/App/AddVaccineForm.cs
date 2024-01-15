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
    public partial class AddVaccineForm : Form
    {
        public AddVaccineForm()
        {
            InitializeComponent();
            validPeriodComboBox.SelectedIndex = 0;
            componentIntervalСomboBox.SelectedIndex = 0;
        }

        private List<VaccineComponent> componentsV = new List<VaccineComponent>();

        private void addComponentButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(componentNameTextBox.Text.Trim()))
            {
                MessageBox.Show("Название компонента не может быть пустым", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string componentName = componentNameTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(componentStructureTextBox.Text.Trim()))
            {
                MessageBox.Show("Состав компонента не может отсутствовать", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string structure = componentStructureTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(comoonentTypeTextBox.Text.Trim()))
            {
                MessageBox.Show("Тип компонента не может отсутствовать", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string type = comoonentTypeTextBox.Text.Trim();
            if (componentIntervalСomboBox.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать период действия компонента", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            VaccineComponent component = new VaccineComponent()
            {
                Name = componentName,
                Structure = structure,
                Type = type,
                IntervalOfComponent = componentIntervalСomboBox.SelectedItem.ToString()
            };
            componentsV.Add(component);
            componentPreView.Rows.Add(component.Name, component.Structure, component.Type, component.IntervalOfComponent);
        }

        private void componentPreView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == componentPreView.Columns["action"].Index)
            {
                if (componentPreView.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {
                    VaccineComponent componentToRemove = componentsV[e.RowIndex];
                    componentsV.Remove(componentToRemove);
                    componentPreView.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void addVaccineButton_Click(object sender, EventArgs e)
        {
            if (componentsV.Count > 0)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(vaccineNameTextBox.Text.Trim()))
                    {
                        MessageBox.Show("Название вакцины не может быть пустым", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string vaccineName = vaccineNameTextBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(countryTextBox.Text.Trim()))
                    {
                        MessageBox.Show("Страна производитель вакцины не может отсутствовать", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string country = vaccineNameTextBox.Text.Trim();
                    if (validPeriodComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Необходимо выбрать период действия", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (var context = new VaccineCalendarContext())
                    {
                        DBService service = new DBService(context);
                        Vaccine vaccine = new Vaccine()
                        {
                            VaccineName = vaccineName,
                            ManufactorCountry = country,
                            ValidPeriod = validPeriodComboBox.SelectedItem.ToString()
                        };
                        service.AddVaccine(vaccine);
                        foreach (VaccineComponent component in componentsV)
                        {
                            component.VaccineId = vaccine.VaccineId;
                            service.AddVaccineComponent(component);
                        }
                        MessageBox.Show("Вакцина и её компоненты успешно добавлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Добавьте хотя бы один компонент, чтобы продолжить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
