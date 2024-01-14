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
            dataGridView1 = new DataGridView();
            addVaccinationButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(736, 193);
            dataGridView1.TabIndex = 0;
            // 
            // addVaccinationButton
            // 
            addVaccinationButton.Location = new Point(610, 434);
            addVaccinationButton.Name = "addVaccinationButton";
            addVaccinationButton.Size = new Size(138, 42);
            addVaccinationButton.TabIndex = 1;
            addVaccinationButton.Text = "Добавить вакцинацию";
            addVaccinationButton.UseVisualStyleBackColor = true;
            addVaccinationButton.Click += addVaccinationButton_Click;
            // 
            // UserInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 488);
            Controls.Add(addVaccinationButton);
            Controls.Add(dataGridView1);
            Name = "UserInfoForm";
            Text = "Информация о пользователе";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button addVaccinationButton;
    }
}