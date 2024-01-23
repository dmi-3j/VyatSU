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
            TitleLabel = new Label();
            loginLabel = new Label();
            passwordLabel = new Label();
            loginField = new TextBox();
            passwordField = new TextBox();
            loginButton = new Button();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            TitleLabel.Location = new Point(70, 27);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(179, 37);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Авторизация";
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            loginLabel.Location = new Point(12, 94);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(57, 21);
            loginLabel.TabIndex = 1;
            loginLabel.Text = "Логин:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordLabel.Location = new Point(12, 147);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(66, 21);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Пароль:";
            // 
            // loginField
            // 
            loginField.Location = new Point(124, 96);
            loginField.Name = "loginField";
            loginField.Size = new Size(185, 23);
            loginField.TabIndex = 3;
            // 
            // passwordField
            // 
            passwordField.Location = new Point(124, 149);
            passwordField.Name = "passwordField";
            passwordField.Size = new Size(185, 23);
            passwordField.TabIndex = 4;
            passwordField.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(91, 218);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(134, 41);
            loginButton.TabIndex = 5;
            loginButton.Text = "Войти";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 284);
            Controls.Add(loginButton);
            Controls.Add(passwordField);
            Controls.Add(loginField);
            Controls.Add(passwordLabel);
            Controls.Add(loginLabel);
            Controls.Add(TitleLabel);
            MaximizeBox = false;
            MaximumSize = new Size(341, 323);
            MinimumSize = new Size(341, 323);
            Name = "LoginForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label loginLabel;
        private Label passwordLabel;
        private TextBox loginField;
        private TextBox passwordField;
        private Button loginButton;
    }
}