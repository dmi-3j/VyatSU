namespace App
{
    partial class addVaccinationForm
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
            label2 = new Label();
            medOrgComboBox = new ComboBox();
            label3 = new Label();
            vaccineComboBox = new ComboBox();
            addButton = new Button();
            resetButton = new Button();
            vaccineGroup = new GroupBox();
            saveVaccineButton = new Button();
            groupBox1 = new GroupBox();
            label4 = new Label();
            vaccineComponentComboBox = new ComboBox();
            vaccineGroup.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(254, 30);
            label1.TabIndex = 0;
            label1.Text = "Добавление вакцинации";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(27, 60);
            label2.Name = "label2";
            label2.Size = new Size(208, 21);
            label2.TabIndex = 1;
            label2.Text = "Медицинская организация:";
            // 
            // medOrgComboBox
            // 
            medOrgComboBox.FormattingEnabled = true;
            medOrgComboBox.Location = new Point(269, 62);
            medOrgComboBox.Name = "medOrgComboBox";
            medOrgComboBox.RightToLeft = RightToLeft.No;
            medOrgComboBox.Size = new Size(186, 23);
            medOrgComboBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(15, 19);
            label3.Name = "label3";
            label3.Size = new Size(74, 21);
            label3.TabIndex = 3;
            label3.Text = "Вакцина:";
            // 
            // vaccineComboBox
            // 
            vaccineComboBox.FormattingEnabled = true;
            vaccineComboBox.Location = new Point(257, 22);
            vaccineComboBox.Name = "vaccineComboBox";
            vaccineComboBox.Size = new Size(186, 23);
            vaccineComboBox.TabIndex = 4;
            // 
            // addButton
            // 
            addButton.Location = new Point(470, 294);
            addButton.Name = "addButton";
            addButton.Size = new Size(109, 35);
            addButton.TabIndex = 5;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(356, 294);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(109, 35);
            resetButton.TabIndex = 6;
            resetButton.Text = "Сбросить";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // vaccineGroup
            // 
            vaccineGroup.Controls.Add(saveVaccineButton);
            vaccineGroup.Controls.Add(label3);
            vaccineGroup.Controls.Add(vaccineComboBox);
            vaccineGroup.Location = new Point(12, 119);
            vaccineGroup.Name = "vaccineGroup";
            vaccineGroup.Size = new Size(567, 62);
            vaccineGroup.TabIndex = 8;
            vaccineGroup.TabStop = false;
            // 
            // saveVaccineButton
            // 
            saveVaccineButton.Location = new Point(459, 22);
            saveVaccineButton.Name = "saveVaccineButton";
            saveVaccineButton.Size = new Size(75, 23);
            saveVaccineButton.TabIndex = 4;
            saveVaccineButton.Text = "Сохранить";
            saveVaccineButton.UseVisualStyleBackColor = true;
            saveVaccineButton.Click += saveVaccineButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(vaccineComponentComboBox);
            groupBox1.Location = new Point(12, 187);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(567, 62);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(15, 19);
            label4.Name = "label4";
            label4.Size = new Size(160, 21);
            label4.TabIndex = 3;
            label4.Text = "Компонент вакцины:";
            // 
            // vaccineComponentComboBox
            // 
            vaccineComponentComboBox.FormattingEnabled = true;
            vaccineComponentComboBox.Location = new Point(257, 22);
            vaccineComponentComboBox.Name = "vaccineComponentComboBox";
            vaccineComponentComboBox.Size = new Size(186, 23);
            vaccineComponentComboBox.TabIndex = 4;
            // 
            // addVaccinationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 350);
            Controls.Add(groupBox1);
            Controls.Add(medOrgComboBox);
            Controls.Add(label2);
            Controls.Add(vaccineGroup);
            Controls.Add(resetButton);
            Controls.Add(addButton);
            Controls.Add(label1);
            Name = "addVaccinationForm";
            Text = "Добавление вакцинации";
            vaccineGroup.ResumeLayout(false);
            vaccineGroup.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox medOrgComboBox;
        private Label label3;
        private ComboBox vaccineComboBox;
        private Button addButton;
        private Button resetButton;
        private GroupBox vaccineGroup;
        private Button saveVaccineButton;
        private GroupBox groupBox1;
        private Label label4;
        private ComboBox vaccineComponentComboBox;
    }
}