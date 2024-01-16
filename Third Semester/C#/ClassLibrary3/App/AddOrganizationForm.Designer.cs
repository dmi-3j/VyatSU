namespace App
{
    partial class AddOrganizationForm
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
            NameTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            addressTextBox = new TextBox();
            label4 = new Label();
            phoneTextBox = new TextBox();
            addButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(22, 9);
            label1.Name = "label1";
            label1.Size = new Size(275, 32);
            label1.TabIndex = 0;
            label1.Text = "Добавить организацию";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(25, 82);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(272, 23);
            NameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(22, 58);
            label2.Name = "label2";
            label2.Size = new Size(178, 21);
            label2.TabIndex = 2;
            label2.Text = "Название организации:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(25, 124);
            label3.Name = "label3";
            label3.Size = new Size(153, 21);
            label3.TabIndex = 3;
            label3.Text = "Адрес организации:";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(25, 148);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(272, 23);
            addressTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(25, 195);
            label4.Name = "label4";
            label4.Size = new Size(230, 21);
            label4.TabIndex = 5;
            label4.Text = "Номер телефона организации:";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(25, 219);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(272, 23);
            phoneTextBox.TabIndex = 6;
            // 
            // addButton
            // 
            addButton.Location = new Point(25, 271);
            addButton.Name = "addButton";
            addButton.Size = new Size(273, 35);
            addButton.TabIndex = 7;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // AddOrganizationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 318);
            Controls.Add(addButton);
            Controls.Add(phoneTextBox);
            Controls.Add(label4);
            Controls.Add(addressTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(NameTextBox);
            Controls.Add(label1);
            MaximumSize = new Size(340, 357);
            MinimumSize = new Size(340, 357);
            Name = "AddOrganizationForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Добавление организации";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox NameTextBox;
        private Label label2;
        private Label label3;
        private TextBox addressTextBox;
        private Label label4;
        private TextBox phoneTextBox;
        private Button addButton;
    }
}