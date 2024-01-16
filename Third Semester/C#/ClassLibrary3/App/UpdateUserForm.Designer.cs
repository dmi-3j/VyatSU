namespace App
{
    partial class UpdateUserForm
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
            label5 = new Label();
            label6 = new Label();
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            middleNameTextBox = new TextBox();
            addressTextBox = new TextBox();
            phoneTextBox = new TextBox();
            saveButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(53, 9);
            label1.Name = "label1";
            label1.Size = new Size(265, 30);
            label1.TabIndex = 0;
            label1.Text = "Изменить личные данные";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(13, 53);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 1;
            label2.Text = "Фамилия:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(13, 87);
            label3.Name = "label3";
            label3.Size = new Size(41, 21);
            label3.TabIndex = 2;
            label3.Text = "Имя";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(13, 120);
            label4.Name = "label4";
            label4.Size = new Size(77, 21);
            label4.TabIndex = 3;
            label4.Text = "Отчество";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(13, 150);
            label5.Name = "label5";
            label5.Size = new Size(53, 21);
            label5.TabIndex = 4;
            label5.Text = "Адрес";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(13, 183);
            label6.Name = "label6";
            label6.Size = new Size(130, 21);
            label6.TabIndex = 5;
            label6.Text = "Номер телефона";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(200, 89);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(169, 23);
            firstNameTextBox.TabIndex = 6;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(200, 55);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(169, 23);
            lastNameTextBox.TabIndex = 7;
            // 
            // middleNameTextBox
            // 
            middleNameTextBox.Location = new Point(200, 122);
            middleNameTextBox.Name = "middleNameTextBox";
            middleNameTextBox.Size = new Size(169, 23);
            middleNameTextBox.TabIndex = 8;
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(200, 152);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(169, 23);
            addressTextBox.TabIndex = 9;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(200, 181);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(169, 23);
            phoneTextBox.TabIndex = 10;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(91, 229);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(197, 30);
            saveButton.TabIndex = 11;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // UpdateUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 283);
            Controls.Add(saveButton);
            Controls.Add(phoneTextBox);
            Controls.Add(addressTextBox);
            Controls.Add(middleNameTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(401, 322);
            MinimumSize = new Size(401, 322);
            Name = "UpdateUserForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "UpdateUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox middleNameTextBox;
        private TextBox addressTextBox;
        private TextBox phoneTextBox;
        private Button saveButton;
    }
}