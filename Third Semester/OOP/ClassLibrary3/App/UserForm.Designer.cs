﻿namespace App
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            statusStrip = new StatusStrip();
            userNameLabel = new ToolStripStatusLabel();
            tabControl1 = new TabControl();
            profileTab = new TabPage();
            inshuranceNumberLabel = new Label();
            label3 = new Label();
            updateUserDataButton = new Button();
            addChildForUserButton = new Button();
            logoutButton = new Button();
            label2 = new Label();
            label1 = new Label();
            addressLabel = new Label();
            phoneLabel = new Label();
            dobLabel = new Label();
            lastNameLabel = new Label();
            firstNameLabel = new Label();
            profilePicture = new PictureBox();
            userVaccinationTab = new TabPage();
            addUserRecordToVaccination = new Button();
            userVaccinationTable = new DataGridView();
            VaccinationSerial = new DataGridViewTextBoxColumn();
            VaccineName = new DataGridViewTextBoxColumn();
            countOfCompleteComponents = new DataGridViewTextBoxColumn();
            dateLastComponent = new DataGridViewTextBoxColumn();
            nextRecommendDate = new DataGridViewTextBoxColumn();
            MedicalOrganizatiin = new DataGridViewTextBoxColumn();
            fllagIsDone = new DataGridViewTextBoxColumn();
            infoVaccinaton = new DataGridViewButtonColumn();
            childVaccinationTab = new TabPage();
            addChildRecordButton = new Button();
            displayButton = new Button();
            childChoiceComboBox = new ComboBox();
            childVaccinationTable = new DataGridView();
            childVaccinationSerial = new DataGridViewTextBoxColumn();
            childVaccineName = new DataGridViewTextBoxColumn();
            countOfChildCompleteComponents = new DataGridViewTextBoxColumn();
            dateChildLastComponent = new DataGridViewTextBoxColumn();
            nextChildRecommendDate = new DataGridViewTextBoxColumn();
            medicalOrganization = new DataGridViewTextBoxColumn();
            fllagChildIsDone = new DataGridViewTextBoxColumn();
            infoChildVaccinaton = new DataGridViewButtonColumn();
            statusStrip.SuspendLayout();
            tabControl1.SuspendLayout();
            profileTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profilePicture).BeginInit();
            userVaccinationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userVaccinationTable).BeginInit();
            childVaccinationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)childVaccinationTable).BeginInit();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { userNameLabel });
            statusStrip.Location = new Point(0, 505);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(904, 22);
            statusStrip.TabIndex = 1;
            // 
            // userNameLabel
            // 
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(89, 17);
            userNameLabel.Text = "userNameLabel";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(profileTab);
            tabControl1.Controls.Add(userVaccinationTab);
            tabControl1.Controls.Add(childVaccinationTab);
            tabControl1.Location = new Point(0, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(904, 501);
            tabControl1.TabIndex = 5;
            // 
            // profileTab
            // 
            profileTab.Controls.Add(inshuranceNumberLabel);
            profileTab.Controls.Add(label3);
            profileTab.Controls.Add(updateUserDataButton);
            profileTab.Controls.Add(addChildForUserButton);
            profileTab.Controls.Add(logoutButton);
            profileTab.Controls.Add(label2);
            profileTab.Controls.Add(label1);
            profileTab.Controls.Add(addressLabel);
            profileTab.Controls.Add(phoneLabel);
            profileTab.Controls.Add(dobLabel);
            profileTab.Controls.Add(lastNameLabel);
            profileTab.Controls.Add(firstNameLabel);
            profileTab.Controls.Add(profilePicture);
            profileTab.Location = new Point(4, 24);
            profileTab.Name = "profileTab";
            profileTab.Size = new Size(896, 473);
            profileTab.TabIndex = 3;
            profileTab.Text = "Профиль";
            profileTab.UseVisualStyleBackColor = true;
            // 
            // inshuranceNumberLabel
            // 
            inshuranceNumberLabel.AutoSize = true;
            inshuranceNumberLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            inshuranceNumberLabel.Location = new Point(280, 314);
            inshuranceNumberLabel.Name = "inshuranceNumberLabel";
            inshuranceNumberLabel.Size = new Size(61, 30);
            inshuranceNumberLabel.TabIndex = 12;
            inshuranceNumberLabel.Text = "ОМС";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(32, 314);
            label3.Name = "label3";
            label3.Size = new Size(211, 30);
            label3.TabIndex = 11;
            label3.Text = "Номер полиса ОМС:";
            // 
            // updateUserDataButton
            // 
            updateUserDataButton.Location = new Point(358, 428);
            updateUserDataButton.Name = "updateUserDataButton";
            updateUserDataButton.Size = new Size(167, 33);
            updateUserDataButton.TabIndex = 10;
            updateUserDataButton.Text = "Изменить личные данные";
            updateUserDataButton.UseVisualStyleBackColor = true;
            updateUserDataButton.Click += updateUserDataButton_Click;
            // 
            // addChildForUserButton
            // 
            addChildForUserButton.Location = new Point(531, 428);
            addChildForUserButton.Name = "addChildForUserButton";
            addChildForUserButton.Size = new Size(212, 33);
            addChildForUserButton.TabIndex = 9;
            addChildForUserButton.Text = "Добавить информацию о ребёнке";
            addChildForUserButton.UseVisualStyleBackColor = true;
            addChildForUserButton.Click += addChildForUserButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(749, 428);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(139, 33);
            logoutButton.TabIndex = 8;
            logoutButton.Text = "Выйти из профиля";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 259);
            label2.Name = "label2";
            label2.Size = new Size(185, 30);
            label2.TabIndex = 7;
            label2.Text = "Домашний адрес:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(32, 197);
            label1.Name = "label1";
            label1.Size = new Size(180, 30);
            label1.TabIndex = 6;
            label1.Text = "Номер телефона:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            addressLabel.Location = new Point(280, 259);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(71, 30);
            addressLabel.TabIndex = 5;
            addressLabel.Text = "Адрес";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            phoneLabel.Location = new Point(280, 197);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(175, 30);
            phoneLabel.TabIndex = 4;
            phoneLabel.Text = "Номер телефона";
            // 
            // dobLabel
            // 
            dobLabel.AutoSize = true;
            dobLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            dobLabel.Location = new Point(221, 124);
            dobLabel.Name = "dobLabel";
            dobLabel.Size = new Size(162, 30);
            dobLabel.TabIndex = 3;
            dobLabel.Text = "Дата Рождения";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.Location = new Point(221, 71);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(70, 37);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Имя";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.Location = new Point(221, 23);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(130, 37);
            firstNameLabel.TabIndex = 1;
            firstNameLabel.Text = "Фамилия";
            // 
            // profilePicture
            // 
            profilePicture.Image = (Image)resources.GetObject("profilePicture.Image");
            profilePicture.Location = new Point(32, 23);
            profilePicture.Name = "profilePicture";
            profilePicture.Size = new Size(119, 131);
            profilePicture.SizeMode = PictureBoxSizeMode.Zoom;
            profilePicture.TabIndex = 0;
            profilePicture.TabStop = false;
            // 
            // userVaccinationTab
            // 
            userVaccinationTab.Controls.Add(addUserRecordToVaccination);
            userVaccinationTab.Controls.Add(userVaccinationTable);
            userVaccinationTab.Location = new Point(4, 24);
            userVaccinationTab.Name = "userVaccinationTab";
            userVaccinationTab.Padding = new Padding(3);
            userVaccinationTab.Size = new Size(896, 473);
            userVaccinationTab.TabIndex = 1;
            userVaccinationTab.Text = "Мои вакцинации";
            userVaccinationTab.UseVisualStyleBackColor = true;
            // 
            // addUserRecordToVaccination
            // 
            addUserRecordToVaccination.Location = new Point(699, 426);
            addUserRecordToVaccination.Name = "addUserRecordToVaccination";
            addUserRecordToVaccination.Size = new Size(175, 32);
            addUserRecordToVaccination.TabIndex = 6;
            addUserRecordToVaccination.Text = "Записаться на вакцинацию";
            addUserRecordToVaccination.UseVisualStyleBackColor = true;
            addUserRecordToVaccination.Click += addUserRecordToVaccination_Click;
            // 
            // userVaccinationTable
            // 
            userVaccinationTable.AllowUserToAddRows = false;
            userVaccinationTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            userVaccinationTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            userVaccinationTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userVaccinationTable.Columns.AddRange(new DataGridViewColumn[] { VaccinationSerial, VaccineName, countOfCompleteComponents, dateLastComponent, nextRecommendDate, MedicalOrganizatiin, fllagIsDone, infoVaccinaton });
            userVaccinationTable.Location = new Point(8, 6);
            userVaccinationTable.Name = "userVaccinationTable";
            userVaccinationTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            userVaccinationTable.RowHeadersVisible = false;
            userVaccinationTable.RowTemplate.Height = 25;
            userVaccinationTable.Size = new Size(866, 369);
            userVaccinationTable.TabIndex = 5;
            userVaccinationTable.CellContentClick += userVaccinationTable_CellContentClick;
            // 
            // VaccinationSerial
            // 
            VaccinationSerial.HeaderText = "Серия";
            VaccinationSerial.Name = "VaccinationSerial";
            VaccinationSerial.ReadOnly = true;
            // 
            // VaccineName
            // 
            VaccineName.HeaderText = "Вакцина";
            VaccineName.Name = "VaccineName";
            VaccineName.ReadOnly = true;
            // 
            // countOfCompleteComponents
            // 
            countOfCompleteComponents.HeaderText = "Поставленные компоненты";
            countOfCompleteComponents.Name = "countOfCompleteComponents";
            countOfCompleteComponents.ReadOnly = true;
            // 
            // dateLastComponent
            // 
            dateLastComponent.HeaderText = "Дата постановки последнего компонента";
            dateLastComponent.Name = "dateLastComponent";
            dateLastComponent.ReadOnly = true;
            // 
            // nextRecommendDate
            // 
            nextRecommendDate.HeaderText = "Рекомендуемая дата постановки следующего компонента";
            nextRecommendDate.Name = "nextRecommendDate";
            nextRecommendDate.ReadOnly = true;
            // 
            // MedicalOrganizatiin
            // 
            MedicalOrganizatiin.HeaderText = "Медицинская организация";
            MedicalOrganizatiin.Name = "MedicalOrganizatiin";
            MedicalOrganizatiin.ReadOnly = true;
            // 
            // fllagIsDone
            // 
            fllagIsDone.HeaderText = "Завершена";
            fllagIsDone.Name = "fllagIsDone";
            fllagIsDone.ReadOnly = true;
            // 
            // infoVaccinaton
            // 
            infoVaccinaton.HeaderText = "Действие";
            infoVaccinaton.Name = "infoVaccinaton";
            infoVaccinaton.Resizable = DataGridViewTriState.True;
            infoVaccinaton.Text = "Подробнее";
            infoVaccinaton.ToolTipText = "Подробная информация";
            infoVaccinaton.UseColumnTextForButtonValue = true;
            // 
            // childVaccinationTab
            // 
            childVaccinationTab.Controls.Add(addChildRecordButton);
            childVaccinationTab.Controls.Add(displayButton);
            childVaccinationTab.Controls.Add(childChoiceComboBox);
            childVaccinationTab.Controls.Add(childVaccinationTable);
            childVaccinationTab.Location = new Point(4, 24);
            childVaccinationTab.Name = "childVaccinationTab";
            childVaccinationTab.Size = new Size(896, 473);
            childVaccinationTab.TabIndex = 2;
            childVaccinationTab.Text = "Вакцинации моих детей";
            childVaccinationTab.UseVisualStyleBackColor = true;
            // 
            // addChildRecordButton
            // 
            addChildRecordButton.Location = new Point(685, 425);
            addChildRecordButton.Name = "addChildRecordButton";
            addChildRecordButton.Size = new Size(203, 36);
            addChildRecordButton.TabIndex = 9;
            addChildRecordButton.Text = "Записать ребёнка на вакцинацию";
            addChildRecordButton.UseVisualStyleBackColor = true;
            addChildRecordButton.Click += addChildRecordButton_Click;
            // 
            // displayButton
            // 
            displayButton.Location = new Point(152, 16);
            displayButton.Name = "displayButton";
            displayButton.Size = new Size(75, 23);
            displayButton.TabIndex = 8;
            displayButton.Text = "Показать";
            displayButton.UseVisualStyleBackColor = true;
            displayButton.Click += displayButton_Click;
            // 
            // childChoiceComboBox
            // 
            childChoiceComboBox.FormattingEnabled = true;
            childChoiceComboBox.Location = new Point(3, 16);
            childChoiceComboBox.Name = "childChoiceComboBox";
            childChoiceComboBox.Size = new Size(143, 23);
            childChoiceComboBox.TabIndex = 7;
            // 
            // childVaccinationTable
            // 
            childVaccinationTable.AllowUserToAddRows = false;
            childVaccinationTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            childVaccinationTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            childVaccinationTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            childVaccinationTable.Columns.AddRange(new DataGridViewColumn[] { childVaccinationSerial, childVaccineName, countOfChildCompleteComponents, dateChildLastComponent, nextChildRecommendDate, medicalOrganization, fllagChildIsDone, infoChildVaccinaton });
            childVaccinationTable.Location = new Point(3, 45);
            childVaccinationTable.Name = "childVaccinationTable";
            childVaccinationTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            childVaccinationTable.RowHeadersVisible = false;
            childVaccinationTable.RowTemplate.Height = 25;
            childVaccinationTable.Size = new Size(885, 320);
            childVaccinationTable.TabIndex = 6;
            childVaccinationTable.CellContentClick += childVaccinationTable_CellContentClick;
            // 
            // childVaccinationSerial
            // 
            childVaccinationSerial.HeaderText = "Серия";
            childVaccinationSerial.Name = "childVaccinationSerial";
            childVaccinationSerial.ReadOnly = true;
            // 
            // childVaccineName
            // 
            childVaccineName.HeaderText = "Вакцина";
            childVaccineName.Name = "childVaccineName";
            childVaccineName.ReadOnly = true;
            // 
            // countOfChildCompleteComponents
            // 
            countOfChildCompleteComponents.HeaderText = "Поставленные компоненты";
            countOfChildCompleteComponents.Name = "countOfChildCompleteComponents";
            countOfChildCompleteComponents.ReadOnly = true;
            // 
            // dateChildLastComponent
            // 
            dateChildLastComponent.HeaderText = "Дата постановки последнего компонента";
            dateChildLastComponent.Name = "dateChildLastComponent";
            dateChildLastComponent.ReadOnly = true;
            // 
            // nextChildRecommendDate
            // 
            nextChildRecommendDate.HeaderText = "Рекомендуемая дата постановки следующего компонента";
            nextChildRecommendDate.Name = "nextChildRecommendDate";
            nextChildRecommendDate.ReadOnly = true;
            // 
            // medicalOrganization
            // 
            medicalOrganization.HeaderText = "Медицинская организация";
            medicalOrganization.Name = "medicalOrganization";
            medicalOrganization.ReadOnly = true;
            // 
            // fllagChildIsDone
            // 
            fllagChildIsDone.HeaderText = "Завершена";
            fllagChildIsDone.Name = "fllagChildIsDone";
            fllagChildIsDone.ReadOnly = true;
            // 
            // infoChildVaccinaton
            // 
            infoChildVaccinaton.HeaderText = "Действие";
            infoChildVaccinaton.Name = "infoChildVaccinaton";
            infoChildVaccinaton.ReadOnly = true;
            infoChildVaccinaton.Resizable = DataGridViewTriState.True;
            infoChildVaccinaton.SortMode = DataGridViewColumnSortMode.Automatic;
            infoChildVaccinaton.Text = "Подробнее";
            infoChildVaccinaton.UseColumnTextForButtonValue = true;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 527);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip);
            MaximizeBox = false;
            MaximumSize = new Size(920, 566);
            MinimumSize = new Size(920, 566);
            Name = "UserForm";
            Text = "Вакцинации";
            Load += UserForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            tabControl1.ResumeLayout(false);
            profileTab.ResumeLayout(false);
            profileTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)profilePicture).EndInit();
            userVaccinationTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)userVaccinationTable).EndInit();
            childVaccinationTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)childVaccinationTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip;
        private ToolStripStatusLabel userNameLabel;
        private TabControl tabControl1;
        private TabPage userVaccinationTab;
        private TabPage childVaccinationTab;
        private TabPage profileTab;
        private Label firstNameLabel;
        private PictureBox profilePicture;
        private Label addressLabel;
        private Label phoneLabel;
        private Label dobLabel;
        private Label lastNameLabel;
        private Label label2;
        private Label label1;
        private DataGridView userVaccinationTable;
        private ComboBox childChoiceComboBox;
        private DataGridView childVaccinationTable;
        private Button displayButton;
        private Button logoutButton;
        private Button addChildForUserButton;
        private DataGridViewTextBoxColumn VaccinationSerial;
        private DataGridViewTextBoxColumn VaccineName;
        private DataGridViewTextBoxColumn countOfCompleteComponents;
        private DataGridViewTextBoxColumn dateLastComponent;
        private DataGridViewTextBoxColumn nextRecommendDate;
        private DataGridViewTextBoxColumn MedicalOrganizatiin;
        private DataGridViewTextBoxColumn fllagIsDone;
        private DataGridViewButtonColumn infoVaccinaton;
        private Button updateUserDataButton;
        private Button addUserRecordToVaccination;
        private Button addChildRecordButton;
        private DataGridViewTextBoxColumn childVaccinationSerial;
        private DataGridViewTextBoxColumn childVaccineName;
        private DataGridViewTextBoxColumn countOfChildCompleteComponents;
        private DataGridViewTextBoxColumn dateChildLastComponent;
        private DataGridViewTextBoxColumn nextChildRecommendDate;
        private DataGridViewTextBoxColumn medicalOrganization;
        private DataGridViewTextBoxColumn fllagChildIsDone;
        private DataGridViewButtonColumn infoChildVaccinaton;
        private Label inshuranceNumberLabel;
        private Label label3;
    }
}