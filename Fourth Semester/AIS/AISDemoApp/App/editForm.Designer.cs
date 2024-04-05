namespace App
{
    partial class editForm
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
            panel1 = new Panel();
            logoutButton = new Button();
            usernameLabel = new Label();
            label5 = new Label();
            numericUpDown2 = new NumericUpDown();
            backButton = new Button();
            saveButton = new Button();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            titleTextBox = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(logoutButton);
            panel1.Controls.Add(usernameLabel);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1125, 36);
            panel1.TabIndex = 3;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(1041, 5);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 2;
            logoutButton.Text = "Выйти";
            logoutButton.UseVisualStyleBackColor = true;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            usernameLabel.Location = new Point(963, 5);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(79, 21);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "username";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(56, 187);
            label5.Name = "label5";
            label5.Size = new Size(65, 21);
            label5.TabIndex = 28;
            label5.Text = "Размер:";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericUpDown2.Location = new Point(56, 211);
            numericUpDown2.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(292, 29);
            numericUpDown2.TabIndex = 27;
            // 
            // backButton
            // 
            backButton.Location = new Point(48, 515);
            backButton.Name = "backButton";
            backButton.Size = new Size(116, 47);
            backButton.TabIndex = 26;
            backButton.Text = "Назад";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(48, 451);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(116, 47);
            saveButton.TabIndex = 25;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericUpDown1.Location = new Point(56, 280);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(292, 29);
            numericUpDown1.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(56, 256);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 21;
            label3.Text = "Цена аренды:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(56, 121);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 20;
            label2.Text = "Название:";
            // 
            // titleTextBox
            // 
            titleTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            titleTextBox.Location = new Point(56, 145);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.PlaceholderText = "Лыжи беговые";
            titleTextBox.Size = new Size(292, 29);
            titleTextBox.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(48, 60);
            label1.Name = "label1";
            label1.Size = new Size(417, 40);
            label1.TabIndex = 18;
            label1.Text = "Редактирование информации";
            // 
            // editForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 605);
            Controls.Add(label5);
            Controls.Add(numericUpDown2);
            Controls.Add(backButton);
            Controls.Add(saveButton);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(titleTextBox);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "editForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "editForm";
            Load += editForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button logoutButton;
        private Label usernameLabel;
        private Label label5;
        private NumericUpDown numericUpDown2;
        private Button backButton;
        private Button saveButton;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Label label2;
        private TextBox titleTextBox;
        private Label label1;
    }
}