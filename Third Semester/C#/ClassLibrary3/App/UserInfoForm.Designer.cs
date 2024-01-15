namespace App
{
    partial class UserInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            vaccinationTable = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            serial = new DataGridViewTextBoxColumn();
            vaccine = new DataGridViewTextBoxColumn();
            medOrg = new DataGridViewTextBoxColumn();
            cntOfComponents = new DataGridViewTextBoxColumn();
            dateOfLast = new DataGridViewTextBoxColumn();
            nextDate = new DataGridViewTextBoxColumn();
            action = new DataGridViewButtonColumn();
            addVaccinationButton = new Button();
            label1 = new Label();
            nameLabel = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)vaccinationTable).BeginInit();
            SuspendLayout();
            // 
            // vaccinationTable
            // 
            vaccinationTable.AllowUserToAddRows = false;
            vaccinationTable.AllowUserToDeleteRows = false;
            vaccinationTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            vaccinationTable.Columns.AddRange(new DataGridViewColumn[] { id, serial, vaccine, medOrg, cntOfComponents, dateOfLast, nextDate, action });
            vaccinationTable.Location = new Point(12, 116);
            vaccinationTable.Name = "vaccinationTable";
            vaccinationTable.RowHeadersVisible = false;
            vaccinationTable.RowTemplate.Height = 25;
            vaccinationTable.Size = new Size(703, 245);
            vaccinationTable.TabIndex = 0;
            vaccinationTable.CellContentClick += vaccinationTable_CellContentClick;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // serial
            // 
            serial.HeaderText = "Серия";
            serial.Name = "serial";
            serial.ReadOnly = true;
            // 
            // vaccine
            // 
            vaccine.HeaderText = "Вакцина";
            vaccine.Name = "vaccine";
            vaccine.ReadOnly = true;
            // 
            // medOrg
            // 
            medOrg.HeaderText = "Медицинская организация";
            medOrg.Name = "medOrg";
            medOrg.ReadOnly = true;
            // 
            // cntOfComponents
            // 
            cntOfComponents.HeaderText = "Поставленные компоненты";
            cntOfComponents.Name = "cntOfComponents";
            cntOfComponents.ReadOnly = true;
            // 
            // dateOfLast
            // 
            dateOfLast.HeaderText = "Дата постановки последнего компонента";
            dateOfLast.Name = "dateOfLast";
            dateOfLast.ReadOnly = true;
            // 
            // nextDate
            // 
            nextDate.HeaderText = "Рекомендуемая дата постановки следующего компонента";
            nextDate.Name = "nextDate";
            nextDate.ReadOnly = true;
            // 
            // action
            // 
            action.HeaderText = "Действие";
            action.Name = "action";
            action.ReadOnly = true;
            action.Text = "Подробнее";
            action.UseColumnTextForButtonValue = true;
            // 
            // addVaccinationButton
            // 
            addVaccinationButton.Location = new Point(532, 382);
            addVaccinationButton.Name = "addVaccinationButton";
            addVaccinationButton.Size = new Size(183, 42);
            addVaccinationButton.TabIndex = 1;
            addVaccinationButton.Text = "Добавить вакцинацию";
            addVaccinationButton.UseVisualStyleBackColor = true;
            addVaccinationButton.Click += addVaccinationButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 26);
            label1.Name = "label1";
            label1.Size = new Size(152, 30);
            label1.TabIndex = 2;
            label1.Text = "Пользователь:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.Location = new Point(172, 26);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(148, 30);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Фамилия Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(203, 21);
            label2.TabIndex = 4;
            label2.Text = "Вакцинации пользователя:";
            // 
            // UserInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 448);
            Controls.Add(label2);
            Controls.Add(nameLabel);
            Controls.Add(label1);
            Controls.Add(addVaccinationButton);
            Controls.Add(vaccinationTable);
            Name = "UserInfoForm";
            Text = "Информация о пользователе";
            ((System.ComponentModel.ISupportInitialize)vaccinationTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView vaccinationTable;
        private Button addVaccinationButton;
        private Label label1;
        private Label nameLabel;
        private Label label2;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn serial;
        private DataGridViewTextBoxColumn vaccine;
        private DataGridViewTextBoxColumn medOrg;
        private DataGridViewTextBoxColumn cntOfComponents;
        private DataGridViewTextBoxColumn dateOfLast;
        private DataGridViewTextBoxColumn nextDate;
        private DataGridViewButtonColumn action;
    }
}