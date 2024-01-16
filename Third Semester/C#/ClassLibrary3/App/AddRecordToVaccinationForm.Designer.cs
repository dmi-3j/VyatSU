namespace App
{
    partial class AddRecordToVaccinationForm
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
            label3 = new Label();
            label4 = new Label();
            vaccineComboBox = new ComboBox();
            medOrgComboBox = new ComboBox();
            datePicker = new DateTimePicker();
            recordButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(278, 30);
            label1.TabIndex = 0;
            label1.Text = "Записаться на вакцинацию";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(74, 21);
            label2.TabIndex = 1;
            label2.Text = "Вакцина:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 95);
            label3.Name = "label3";
            label3.Size = new Size(208, 21);
            label3.TabIndex = 2;
            label3.Text = "Медицинская организация:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 129);
            label4.Name = "label4";
            label4.Size = new Size(100, 21);
            label4.TabIndex = 3;
            label4.Text = "Дата записи:";
            // 
            // vaccineComboBox
            // 
            vaccineComboBox.FormattingEnabled = true;
            vaccineComboBox.Location = new Point(288, 62);
            vaccineComboBox.Name = "vaccineComboBox";
            vaccineComboBox.Size = new Size(174, 23);
            vaccineComboBox.TabIndex = 4;
            // 
            // medOrgComboBox
            // 
            medOrgComboBox.FormattingEnabled = true;
            medOrgComboBox.Location = new Point(288, 97);
            medOrgComboBox.Name = "medOrgComboBox";
            medOrgComboBox.Size = new Size(174, 23);
            medOrgComboBox.TabIndex = 5;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(288, 127);
            datePicker.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            datePicker.MinDate = new DateTime(2024, 1, 13, 0, 0, 0, 0);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(174, 23);
            datePicker.TabIndex = 6;
            // 
            // recordButton
            // 
            recordButton.Location = new Point(288, 208);
            recordButton.Name = "recordButton";
            recordButton.Size = new Size(174, 38);
            recordButton.TabIndex = 7;
            recordButton.Text = "Записаться";
            recordButton.UseVisualStyleBackColor = true;
            recordButton.Click += recordButton_Click;
            // 
            // AddRecordToVaccinationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 258);
            Controls.Add(recordButton);
            Controls.Add(datePicker);
            Controls.Add(medOrgComboBox);
            Controls.Add(vaccineComboBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(490, 297);
            MinimumSize = new Size(490, 297);
            Name = "AddRecordToVaccinationForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Запись на вакцинацию";
            Load += AddRecordToVaccinationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox vaccineComboBox;
        private ComboBox medOrgComboBox;
        private DateTimePicker datePicker;
        private Button recordButton;
    }
}