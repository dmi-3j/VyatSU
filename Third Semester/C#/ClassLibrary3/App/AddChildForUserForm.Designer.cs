namespace App
{
    partial class AddChildForUserForm
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
            addButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lastNameTextBox = new TextBox();
            firstNameTextBox = new TextBox();
            middleNameTextBox = new TextBox();
            DoBTextBox = new TextBox();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 231);
            addButton.Name = "addButton";
            addButton.Size = new Size(281, 31);
            addButton.TabIndex = 0;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(191, 30);
            label1.TabIndex = 1;
            label1.Text = "Добавить ребёнка";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 61);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 2;
            label2.Text = "Фамилия:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 91);
            label3.Name = "label3";
            label3.Size = new Size(44, 21);
            label3.TabIndex = 3;
            label3.Text = "Имя:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 121);
            label4.Name = "label4";
            label4.Size = new Size(80, 21);
            label4.TabIndex = 4;
            label4.Text = "Отчество:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 151);
            label5.Name = "label5";
            label5.Size = new Size(124, 21);
            label5.TabIndex = 5;
            label5.Text = "Дата рождения:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(142, 61);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(151, 23);
            lastNameTextBox.TabIndex = 6;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(142, 93);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(151, 23);
            firstNameTextBox.TabIndex = 7;
            // 
            // middleNameTextBox
            // 
            middleNameTextBox.Location = new Point(142, 119);
            middleNameTextBox.Name = "middleNameTextBox";
            middleNameTextBox.Size = new Size(151, 23);
            middleNameTextBox.TabIndex = 8;
            // 
            // DoBTextBox
            // 
            DoBTextBox.Location = new Point(142, 149);
            DoBTextBox.Name = "DoBTextBox";
            DoBTextBox.Size = new Size(151, 23);
            DoBTextBox.TabIndex = 9;
            // 
            // AddChildForUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 274);
            Controls.Add(DoBTextBox);
            Controls.Add(middleNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(addButton);
            Name = "AddChildForUserForm";
            Text = "Добавить ребёнка";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox lastNameTextBox;
        private TextBox firstNameTextBox;
        private TextBox middleNameTextBox;
        private TextBox DoBTextBox;
    }
}