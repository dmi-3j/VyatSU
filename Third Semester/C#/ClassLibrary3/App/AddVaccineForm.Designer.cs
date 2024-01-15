namespace App
{
    partial class AddVaccineForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            vaccineNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            countryTextBox = new TextBox();
            validPeriodComboBox = new ComboBox();
            mainInfoGroup = new GroupBox();
            groupBox1 = new GroupBox();
            label9 = new Label();
            componentPreView = new DataGridView();
            compName = new DataGridViewTextBoxColumn();
            compStructure = new DataGridViewTextBoxColumn();
            compType = new DataGridViewTextBoxColumn();
            compInterval = new DataGridViewTextBoxColumn();
            action = new DataGridViewButtonColumn();
            addComponentButton = new Button();
            comoonentTypeTextBox = new TextBox();
            componentStructureTextBox = new TextBox();
            componentNameTextBox = new TextBox();
            componentIntervalСomboBox = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            addVaccineButton = new Button();
            mainInfoGroup.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)componentPreView).BeginInit();
            SuspendLayout();
            // 
            // vaccineNameTextBox
            // 
            vaccineNameTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            vaccineNameTextBox.Location = new Point(266, 52);
            vaccineNameTextBox.Name = "vaccineNameTextBox";
            vaccineNameTextBox.Size = new Size(183, 25);
            vaccineNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 50);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 1;
            label1.Text = "Название:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(27, 9);
            label2.Name = "label2";
            label2.Size = new Size(221, 30);
            label2.TabIndex = 2;
            label2.Text = "Добавление вакцины";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(18, 84);
            label3.Name = "label3";
            label3.Size = new Size(177, 21);
            label3.TabIndex = 3;
            label3.Text = "Страна производитель:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(18, 121);
            label4.Name = "label4";
            label4.Size = new Size(137, 21);
            label4.TabIndex = 4;
            label4.Text = "Период действия:";
            // 
            // countryTextBox
            // 
            countryTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            countryTextBox.Location = new Point(266, 86);
            countryTextBox.Name = "countryTextBox";
            countryTextBox.Size = new Size(183, 25);
            countryTextBox.TabIndex = 5;
            // 
            // validPeriodComboBox
            // 
            validPeriodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            validPeriodComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            validPeriodComboBox.FormattingEnabled = true;
            validPeriodComboBox.Items.AddRange(new object[] { "6 месяцев", "1 год", "2 года", "5 лет", "10 лет" });
            validPeriodComboBox.Location = new Point(266, 119);
            validPeriodComboBox.Name = "validPeriodComboBox";
            validPeriodComboBox.Size = new Size(183, 25);
            validPeriodComboBox.TabIndex = 6;
            // 
            // mainInfoGroup
            // 
            mainInfoGroup.Controls.Add(validPeriodComboBox);
            mainInfoGroup.Controls.Add(vaccineNameTextBox);
            mainInfoGroup.Controls.Add(label1);
            mainInfoGroup.Controls.Add(label3);
            mainInfoGroup.Controls.Add(countryTextBox);
            mainInfoGroup.Controls.Add(label4);
            mainInfoGroup.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            mainInfoGroup.Location = new Point(27, 69);
            mainInfoGroup.Name = "mainInfoGroup";
            mainInfoGroup.Size = new Size(621, 181);
            mainInfoGroup.TabIndex = 9;
            mainInfoGroup.TabStop = false;
            mainInfoGroup.Text = "Общие данные";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(componentPreView);
            groupBox1.Controls.Add(addComponentButton);
            groupBox1.Controls.Add(comoonentTypeTextBox);
            groupBox1.Controls.Add(componentStructureTextBox);
            groupBox1.Controls.Add(componentNameTextBox);
            groupBox1.Controls.Add(componentIntervalСomboBox);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(27, 273);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(621, 431);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Компоненты вакцины";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(18, 239);
            label9.Name = "label9";
            label9.Size = new Size(218, 21);
            label9.TabIndex = 13;
            label9.Text = "Предварительный просмотр:";
            // 
            // componentPreView
            // 
            componentPreView.AllowUserToAddRows = false;
            componentPreView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            componentPreView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            componentPreView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            componentPreView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            componentPreView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            componentPreView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            componentPreView.Columns.AddRange(new DataGridViewColumn[] { compName, compStructure, compType, compInterval, action });
            componentPreView.Location = new Point(18, 263);
            componentPreView.Name = "componentPreView";
            componentPreView.ReadOnly = true;
            componentPreView.RowHeadersVisible = false;
            componentPreView.RowTemplate.Height = 25;
            componentPreView.Size = new Size(461, 150);
            componentPreView.TabIndex = 12;
            componentPreView.CellContentClick += componentPreView_CellContentClick_1;
            // 
            // compName
            // 
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            compName.DefaultCellStyle = dataGridViewCellStyle3;
            compName.HeaderText = "Название";
            compName.Name = "compName";
            compName.ReadOnly = true;
            compName.Width = 103;
            // 
            // compStructure
            // 
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            compStructure.DefaultCellStyle = dataGridViewCellStyle4;
            compStructure.HeaderText = "Состав";
            compStructure.Name = "compStructure";
            compStructure.ReadOnly = true;
            compStructure.Width = 84;
            // 
            // compType
            // 
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            compType.DefaultCellStyle = dataGridViewCellStyle5;
            compType.HeaderText = "Тип";
            compType.Name = "compType";
            compType.ReadOnly = true;
            compType.Width = 61;
            // 
            // compInterval
            // 
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            compInterval.DefaultCellStyle = dataGridViewCellStyle6;
            compInterval.HeaderText = "Интервал";
            compInterval.Name = "compInterval";
            compInterval.ReadOnly = true;
            compInterval.Width = 104;
            // 
            // action
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            action.DefaultCellStyle = dataGridViewCellStyle7;
            action.HeaderText = "Действие";
            action.Name = "action";
            action.ReadOnly = true;
            action.Resizable = DataGridViewTriState.True;
            action.SortMode = DataGridViewColumnSortMode.Automatic;
            action.Text = "Удалить";
            action.UseColumnTextForButtonValue = true;
            action.Width = 102;
            // 
            // addComponentButton
            // 
            addComponentButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            addComponentButton.Location = new Point(324, 185);
            addComponentButton.Name = "addComponentButton";
            addComponentButton.Size = new Size(155, 33);
            addComponentButton.TabIndex = 11;
            addComponentButton.Text = "Добавить компонент";
            addComponentButton.UseVisualStyleBackColor = true;
            addComponentButton.Click += addComponentButton_Click;
            // 
            // comoonentTypeTextBox
            // 
            comoonentTypeTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            comoonentTypeTextBox.Location = new Point(296, 112);
            comoonentTypeTextBox.Name = "comoonentTypeTextBox";
            comoonentTypeTextBox.Size = new Size(183, 25);
            comoonentTypeTextBox.TabIndex = 10;
            // 
            // componentStructureTextBox
            // 
            componentStructureTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            componentStructureTextBox.Location = new Point(296, 85);
            componentStructureTextBox.Name = "componentStructureTextBox";
            componentStructureTextBox.Size = new Size(183, 25);
            componentStructureTextBox.TabIndex = 9;
            // 
            // componentNameTextBox
            // 
            componentNameTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            componentNameTextBox.Location = new Point(296, 54);
            componentNameTextBox.Name = "componentNameTextBox";
            componentNameTextBox.Size = new Size(183, 25);
            componentNameTextBox.TabIndex = 8;
            // 
            // componentIntervalСomboBox
            // 
            componentIntervalСomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            componentIntervalСomboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            componentIntervalСomboBox.FormattingEnabled = true;
            componentIntervalСomboBox.Items.AddRange(new object[] { "2 недели", "1 месяц", "2 месяца" });
            componentIntervalСomboBox.Location = new Point(296, 145);
            componentIntervalСomboBox.Name = "componentIntervalСomboBox";
            componentIntervalСomboBox.Size = new Size(183, 25);
            componentIntervalСomboBox.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(18, 149);
            label8.Name = "label8";
            label8.Size = new Size(228, 21);
            label8.TabIndex = 5;
            label8.Text = "Следующий компонент через:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(18, 116);
            label7.Name = "label7";
            label7.Size = new Size(39, 21);
            label7.TabIndex = 4;
            label7.Text = "Тип:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(18, 85);
            label6.Name = "label6";
            label6.Size = new Size(62, 21);
            label6.TabIndex = 3;
            label6.Text = "Состав:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(18, 54);
            label5.Name = "label5";
            label5.Size = new Size(81, 21);
            label5.TabIndex = 2;
            label5.Text = "Название:";
            // 
            // addVaccineButton
            // 
            addVaccineButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addVaccineButton.Location = new Point(654, 665);
            addVaccineButton.Name = "addVaccineButton";
            addVaccineButton.Size = new Size(138, 61);
            addVaccineButton.TabIndex = 11;
            addVaccineButton.Text = "Добавить вакцину";
            addVaccineButton.UseVisualStyleBackColor = true;
            addVaccineButton.Click += addVaccineButton_Click;
            // 
            // AddVaccineForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 738);
            Controls.Add(addVaccineButton);
            Controls.Add(groupBox1);
            Controls.Add(mainInfoGroup);
            Controls.Add(label2);
            MaximizeBox = false;
            MaximumSize = new Size(820, 777);
            MinimumSize = new Size(820, 777);
            Name = "AddVaccineForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Добавление вакцины";
            mainInfoGroup.ResumeLayout(false);
            mainInfoGroup.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)componentPreView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox vaccineNameTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox countryTextBox;
        private ComboBox validPeriodComboBox;
        private GroupBox mainInfoGroup;
        private GroupBox groupBox1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox comoonentTypeTextBox;
        private TextBox componentStructureTextBox;
        private TextBox componentNameTextBox;
        private ComboBox componentIntervalСomboBox;
        private Button addComponentButton;
        private DataGridView componentPreView;
        private DataGridViewTextBoxColumn compName;
        private DataGridViewTextBoxColumn compStructure;
        private DataGridViewTextBoxColumn compType;
        private DataGridViewTextBoxColumn compInterval;
        private DataGridViewButtonColumn action;
        private Label label9;
        private Button addVaccineButton;
    }
}