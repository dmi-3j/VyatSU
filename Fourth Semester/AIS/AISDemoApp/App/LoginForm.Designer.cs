namespace App
{
    partial class LoginForm
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
            loginTextBox = new TextBox();
            passwoedTextBox = new TextBox();
            loginProcessButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(442, 120);
            label1.Name = "label1";
            label1.Size = new Size(179, 37);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(289, 235);
            label2.Name = "label2";
            label2.Size = new Size(76, 30);
            label2.TabIndex = 1;
            label2.Text = "Логин:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(275, 295);
            label3.Name = "label3";
            label3.Size = new Size(90, 30);
            label3.TabIndex = 2;
            label3.Text = "Пароль:";
            // 
            // loginTextBox
            // 
            loginTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            loginTextBox.Location = new Point(429, 235);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(352, 35);
            loginTextBox.TabIndex = 3;
            // 
            // passwoedTextBox
            // 
            passwoedTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            passwoedTextBox.Location = new Point(429, 295);
            passwoedTextBox.Name = "passwoedTextBox";
            passwoedTextBox.Size = new Size(352, 35);
            passwoedTextBox.TabIndex = 4;
            passwoedTextBox.UseSystemPasswordChar = true;
            // 
            // loginProcessButton
            // 
            loginProcessButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            loginProcessButton.Location = new Point(442, 372);
            loginProcessButton.Name = "loginProcessButton";
            loginProcessButton.Size = new Size(179, 65);
            loginProcessButton.TabIndex = 5;
            loginProcessButton.Text = "Войти";
            loginProcessButton.TextImageRelation = TextImageRelation.ImageAboveText;
            loginProcessButton.UseVisualStyleBackColor = true;
            loginProcessButton.Click += loginProcessButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1100, 600);
            Controls.Add(loginProcessButton);
            Controls.Add(passwoedTextBox);
            Controls.Add(loginTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "LoginForm";
            WindowState = FormWindowState.Maximized;
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox loginTextBox;
        private TextBox passwoedTextBox;
        private Button loginProcessButton;
    }
}