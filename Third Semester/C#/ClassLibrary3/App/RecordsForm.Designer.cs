namespace App
{
    partial class RecordsForm
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
            label1 = new Label();
            choiceOrganizationComboBox = new ComboBox();
            label2 = new Label();
            displayButton = new Button();
            recordsTable = new DataGridView();
            RecordId = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            DateOfBirth = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            InshuraneNumber = new DataGridViewTextBoxColumn();
            VaccineName = new DataGridViewTextBoxColumn();
            DateOfRecord = new DataGridViewTextBoxColumn();
            Action = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)recordsTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(238, 30);
            label1.TabIndex = 0;
            label1.Text = "Записи на вакцинацию";
            // 
            // choiceOrganizationComboBox
            // 
            choiceOrganizationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            choiceOrganizationComboBox.FormattingEnabled = true;
            choiceOrganizationComboBox.Location = new Point(12, 82);
            choiceOrganizationComboBox.Name = "choiceOrganizationComboBox";
            choiceOrganizationComboBox.Size = new Size(208, 23);
            choiceOrganizationComboBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 58);
            label2.Name = "label2";
            label2.Size = new Size(208, 21);
            label2.TabIndex = 2;
            label2.Text = "Медицинская организация:";
            // 
            // displayButton
            // 
            displayButton.Location = new Point(245, 82);
            displayButton.Name = "displayButton";
            displayButton.Size = new Size(101, 23);
            displayButton.TabIndex = 3;
            displayButton.Text = "Показать";
            displayButton.UseVisualStyleBackColor = true;
            displayButton.Click += displayButton_Click;
            // 
            // recordsTable
            // 
            recordsTable.AllowUserToAddRows = false;
            recordsTable.AllowUserToDeleteRows = false;
            recordsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recordsTable.Columns.AddRange(new DataGridViewColumn[] { RecordId, LastName, FirstName, DateOfBirth, PhoneNumber, InshuraneNumber, VaccineName, DateOfRecord, Action });
            recordsTable.Location = new Point(12, 124);
            recordsTable.Name = "recordsTable";
            recordsTable.RowHeadersVisible = false;
            recordsTable.RowTemplate.Height = 25;
            recordsTable.Size = new Size(806, 276);
            recordsTable.TabIndex = 4;
            recordsTable.CellContentClick += recordsTable_CellContentClick;
            // 
            // RecordId
            // 
            RecordId.HeaderText = "Id";
            RecordId.Name = "RecordId";
            RecordId.ReadOnly = true;
            RecordId.Visible = false;
            // 
            // LastName
            // 
            LastName.HeaderText = "Фамилия";
            LastName.Name = "LastName";
            LastName.ReadOnly = true;
            // 
            // FirstName
            // 
            FirstName.HeaderText = "Имя";
            FirstName.Name = "FirstName";
            FirstName.ReadOnly = true;
            // 
            // DateOfBirth
            // 
            DateOfBirth.HeaderText = "Дата рождения";
            DateOfBirth.Name = "DateOfBirth";
            DateOfBirth.ReadOnly = true;
            // 
            // PhoneNumber
            // 
            PhoneNumber.HeaderText = "Номер телефона";
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.ReadOnly = true;
            // 
            // InshuraneNumber
            // 
            InshuraneNumber.HeaderText = "Номер полиса";
            InshuraneNumber.Name = "InshuraneNumber";
            InshuraneNumber.ReadOnly = true;
            // 
            // VaccineName
            // 
            VaccineName.HeaderText = "Вакцина";
            VaccineName.Name = "VaccineName";
            VaccineName.ReadOnly = true;
            // 
            // DateOfRecord
            // 
            DateOfRecord.HeaderText = "Дата записи";
            DateOfRecord.Name = "DateOfRecord";
            DateOfRecord.ReadOnly = true;
            // 
            // Action
            // 
            Action.HeaderText = "Действие";
            Action.Name = "Action";
            Action.ReadOnly = true;
            Action.Text = "Удалить";
            Action.UseColumnTextForButtonValue = true;
            // 
            // RecordsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 541);
            Controls.Add(recordsTable);
            Controls.Add(displayButton);
            Controls.Add(label2);
            Controls.Add(choiceOrganizationComboBox);
            Controls.Add(label1);
            Name = "RecordsForm";
            Text = "Записи на вакцинацию";
            ((System.ComponentModel.ISupportInitialize)recordsTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox choiceOrganizationComboBox;
        private Label label2;
        private Button displayButton;
        private DataGridView recordsTable;
        private DataGridViewTextBoxColumn RecordId;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn DateOfBirth;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn InshuraneNumber;
        private DataGridViewTextBoxColumn VaccineName;
        private DataGridViewTextBoxColumn DateOfRecord;
        private DataGridViewButtonColumn Action;
    }
}