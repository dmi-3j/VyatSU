namespace App
{
    partial class AddUserForm
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
            addButton = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            lastNameTextBox = new TextBox();
            firstNameTextBox = new TextBox();
            middleNameTextBox = new TextBox();
            addressTextBox = new TextBox();
            phoneTextBox = new TextBox();
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            roleComboBox = new ComboBox();
            label11 = new Label();
            inshuranceNumberTextBox = new TextBox();
            dobPicker = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(22, 19);
            label1.Name = "label1";
            label1.Size = new Size(278, 32);
            label1.TabIndex = 0;
            label1.Text = "Добавить пользователя";
            // 
            // addButton
            // 
            addButton.Location = new Point(22, 463);
            addButton.Name = "addButton";
            addButton.Size = new Size(440, 34);
            addButton.TabIndex = 1;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(22, 67);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 2;
            label2.Text = "Фамилия:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(22, 102);
            label3.Name = "label3";
            label3.Size = new Size(44, 21);
            label3.TabIndex = 3;
            label3.Text = "Имя:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(22, 130);
            label4.Name = "label4";
            label4.Size = new Size(80, 21);
            label4.TabIndex = 4;
            label4.Text = "Отчество:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(22, 162);
            label5.Name = "label5";
            label5.Size = new Size(124, 21);
            label5.TabIndex = 5;
            label5.Text = "Дата рождения:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(22, 197);
            label6.Name = "label6";
            label6.Size = new Size(153, 21);
            label6.TabIndex = 6;
            label6.Text = "Адрес проживания::";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(22, 230);
            label7.Name = "label7";
            label7.Size = new Size(133, 21);
            label7.TabIndex = 7;
            label7.Text = "Номер телефона:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(22, 293);
            label8.Name = "label8";
            label8.Size = new Size(145, 21);
            label8.TabIndex = 8;
            label8.Text = "Имя пользователя:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(22, 323);
            label9.Name = "label9";
            label9.Size = new Size(66, 21);
            label9.TabIndex = 9;
            label9.Text = "Пароль:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(22, 355);
            label10.Name = "label10";
            label10.Size = new Size(47, 21);
            label10.TabIndex = 10;
            label10.Text = "Роль:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(216, 65);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(246, 23);
            lastNameTextBox.TabIndex = 11;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(216, 94);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(246, 23);
            firstNameTextBox.TabIndex = 12;
            // 
            // middleNameTextBox
            // 
            middleNameTextBox.Location = new Point(216, 128);
            middleNameTextBox.Name = "middleNameTextBox";
            middleNameTextBox.Size = new Size(246, 23);
            middleNameTextBox.TabIndex = 13;
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(216, 195);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(246, 23);
            addressTextBox.TabIndex = 15;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(216, 228);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(246, 23);
            phoneTextBox.TabIndex = 16;
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(216, 293);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(246, 23);
            loginTextBox.TabIndex = 17;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(216, 324);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(246, 23);
            passwordTextBox.TabIndex = 18;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // roleComboBox
            // 
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Items.AddRange(new object[] { "USER", "MED_PERSONAL" });
            roleComboBox.Location = new Point(216, 353);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(246, 23);
            roleComboBox.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(22, 260);
            label11.Name = "label11";
            label11.Size = new Size(97, 21);
            label11.TabIndex = 20;
            label11.Text = "Полис ОМС:";
            // 
            // inshuranceNumberTextBox
            // 
            inshuranceNumberTextBox.Location = new Point(216, 262);
            inshuranceNumberTextBox.Name = "inshuranceNumberTextBox";
            inshuranceNumberTextBox.Size = new Size(246, 23);
            inshuranceNumberTextBox.TabIndex = 21;
            // 
            // dobPicker
            // 
            dobPicker.Location = new Point(218, 162);
            dobPicker.MinDate = new DateTime(1913, 1, 1, 0, 0, 0, 0);
            dobPicker.Name = "dobPicker";
            dobPicker.Size = new Size(244, 23);
            dobPicker.TabIndex = 22;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 516);
            Controls.Add(dobPicker);
            Controls.Add(inshuranceNumberTextBox);
            Controls.Add(label11);
            Controls.Add(roleComboBox);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            Controls.Add(phoneTextBox);
            Controls.Add(addressTextBox);
            Controls.Add(middleNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(addButton);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(504, 555);
            MinimumSize = new Size(504, 555);
            Name = "AddUserForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Добавление пользователя";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button addButton;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox lastNameTextBox;
        private TextBox firstNameTextBox;
        private TextBox middleNameTextBox;
        private TextBox addressTextBox;
        private TextBox phoneTextBox;
        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private ComboBox roleComboBox;
        private Label label11;
        private TextBox inshuranceNumberTextBox;
        private DateTimePicker dobPicker;
    }
}