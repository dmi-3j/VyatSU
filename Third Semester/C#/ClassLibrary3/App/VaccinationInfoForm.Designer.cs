namespace App
{
    partial class VaccinationInfoForm
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
            serialLabel = new Label();
            vaccineLabel = new Label();
            medorgLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            medorgInfoButton = new Button();
            addReactionButton = new Button();
            label4 = new Label();
            componentsInfoTable = new DataGridView();
            nameOfComponent = new DataGridViewTextBoxColumn();
            structureOfComponent = new DataGridViewTextBoxColumn();
            typeOfComponent = new DataGridViewTextBoxColumn();
            interevalOfComponents = new DataGridViewTextBoxColumn();
            dateOfVaccinationComponent = new DataGridViewTextBoxColumn();
            vaccineInfoButton = new Button();
            showReactionButton = new Button();
            ((System.ComponentModel.ISupportInitialize)componentsInfoTable).BeginInit();
            SuspendLayout();
            // 
            // serialLabel
            // 
            serialLabel.AutoSize = true;
            serialLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            serialLabel.Location = new Point(285, 23);
            serialLabel.Name = "serialLabel";
            serialLabel.Size = new Size(146, 21);
            serialLabel.TabIndex = 0;
            serialLabel.Text = "Серия вакцинации";
            // 
            // vaccineLabel
            // 
            vaccineLabel.AutoSize = true;
            vaccineLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            vaccineLabel.Location = new Point(285, 59);
            vaccineLabel.Name = "vaccineLabel";
            vaccineLabel.Size = new Size(71, 21);
            vaccineLabel.TabIndex = 1;
            vaccineLabel.Text = "Вакцина";
            // 
            // medorgLabel
            // 
            medorgLabel.AutoSize = true;
            medorgLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            medorgLabel.Location = new Point(285, 95);
            medorgLabel.Name = "medorgLabel";
            medorgLabel.Size = new Size(205, 21);
            medorgLabel.TabIndex = 2;
            medorgLabel.Text = "Медицинская организация";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(149, 21);
            label1.TabIndex = 3;
            label1.Text = "Серия вакцинации:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(74, 21);
            label2.TabIndex = 4;
            label2.Text = "Вакцина:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 89);
            label3.Name = "label3";
            label3.Size = new Size(208, 21);
            label3.TabIndex = 5;
            label3.Text = "Медицинская организация:";
            // 
            // medorgInfoButton
            // 
            medorgInfoButton.Location = new Point(374, 350);
            medorgInfoButton.Name = "medorgInfoButton";
            medorgInfoButton.Size = new Size(141, 53);
            medorgInfoButton.TabIndex = 6;
            medorgInfoButton.Text = "Подробнее \r\nо медицинской организации";
            medorgInfoButton.UseVisualStyleBackColor = true;
            medorgInfoButton.Click += medorgInfoButton_Click;
            // 
            // addReactionButton
            // 
            addReactionButton.Location = new Point(12, 350);
            addReactionButton.Name = "addReactionButton";
            addReactionButton.Size = new Size(114, 53);
            addReactionButton.TabIndex = 7;
            addReactionButton.Text = "Добавить реакцию";
            addReactionButton.UseVisualStyleBackColor = true;
            addReactionButton.Click += addReactionButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 138);
            label4.Name = "label4";
            label4.Size = new Size(210, 21);
            label4.TabIndex = 8;
            label4.Text = "Поставленные компоненты:";
            // 
            // componentsInfoTable
            // 
            componentsInfoTable.AllowUserToAddRows = false;
            componentsInfoTable.AllowUserToDeleteRows = false;
            componentsInfoTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            componentsInfoTable.Columns.AddRange(new DataGridViewColumn[] { nameOfComponent, structureOfComponent, typeOfComponent, interevalOfComponents, dateOfVaccinationComponent });
            componentsInfoTable.Location = new Point(12, 162);
            componentsInfoTable.Name = "componentsInfoTable";
            componentsInfoTable.RowHeadersVisible = false;
            componentsInfoTable.RowTemplate.Height = 25;
            componentsInfoTable.Size = new Size(503, 169);
            componentsInfoTable.TabIndex = 9;
            // 
            // nameOfComponent
            // 
            nameOfComponent.HeaderText = "Название";
            nameOfComponent.Name = "nameOfComponent";
            nameOfComponent.ReadOnly = true;
            // 
            // structureOfComponent
            // 
            structureOfComponent.HeaderText = "Состав";
            structureOfComponent.Name = "structureOfComponent";
            structureOfComponent.ReadOnly = true;
            // 
            // typeOfComponent
            // 
            typeOfComponent.HeaderText = "Тип";
            typeOfComponent.Name = "typeOfComponent";
            typeOfComponent.ReadOnly = true;
            // 
            // interevalOfComponents
            // 
            interevalOfComponents.HeaderText = "Интервал";
            interevalOfComponents.Name = "interevalOfComponents";
            interevalOfComponents.ReadOnly = true;
            // 
            // dateOfVaccinationComponent
            // 
            dateOfVaccinationComponent.HeaderText = "Дата постановки";
            dateOfVaccinationComponent.Name = "dateOfVaccinationComponent";
            dateOfVaccinationComponent.ReadOnly = true;
            // 
            // vaccineInfoButton
            // 
            vaccineInfoButton.Location = new Point(250, 350);
            vaccineInfoButton.Name = "vaccineInfoButton";
            vaccineInfoButton.Size = new Size(118, 53);
            vaccineInfoButton.TabIndex = 10;
            vaccineInfoButton.Text = "Подробнее о вакцине";
            vaccineInfoButton.UseVisualStyleBackColor = true;
            vaccineInfoButton.Click += vaccineInfoButton_Click;
            // 
            // showReactionButton
            // 
            showReactionButton.Location = new Point(132, 350);
            showReactionButton.Name = "showReactionButton";
            showReactionButton.Size = new Size(112, 53);
            showReactionButton.TabIndex = 11;
            showReactionButton.Text = "Посмотреть реакции";
            showReactionButton.UseVisualStyleBackColor = true;
            showReactionButton.Click += showReactionButton_Click;
            // 
            // VaccinationInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 415);
            Controls.Add(showReactionButton);
            Controls.Add(vaccineInfoButton);
            Controls.Add(componentsInfoTable);
            Controls.Add(label4);
            Controls.Add(addReactionButton);
            Controls.Add(medorgInfoButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(medorgLabel);
            Controls.Add(vaccineLabel);
            Controls.Add(serialLabel);
            MaximizeBox = false;
            MaximumSize = new Size(548, 454);
            MinimumSize = new Size(548, 454);
            Name = "VaccinationInfoForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Информация о вакцинации";
            Load += VaccinationInfoForm_Load;
            ((System.ComponentModel.ISupportInitialize)componentsInfoTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label serialLabel;
        private Label vaccineLabel;
        private Label medorgLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button medorgInfoButton;
        private Button addReactionButton;
        private Label label4;
        private DataGridView componentsInfoTable;
        private DataGridViewTextBoxColumn nameOfComponent;
        private DataGridViewTextBoxColumn structureOfComponent;
        private DataGridViewTextBoxColumn typeOfComponent;
        private DataGridViewTextBoxColumn interevalOfComponents;
        private DataGridViewTextBoxColumn dateOfVaccinationComponent;
        private Button vaccineInfoButton;
        private Button showReactionButton;
    }
}