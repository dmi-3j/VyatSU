namespace App
{
    partial class profile
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
            linkLabel1 = new LinkLabel();
            logoutButton = new Button();
            usernameLabel = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            fnameTB = new Label();
            lNmaeTB = new Label();
            dobTB = new Label();
            phoneTB = new Label();
            backButton = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(logoutButton);
            panel1.Controls.Add(usernameLabel);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1125, 36);
            panel1.TabIndex = 4;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Blue;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            linkLabel1.LinkColor = Color.Blue;
            linkLabel1.Location = new Point(45, 5);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(75, 21);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Профиль";
            linkLabel1.VisitedLinkColor = Color.Blue;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(1041, 5);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 2;
            logoutButton.Text = "Выйти";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(35, 67);
            label1.Name = "label1";
            label1.Size = new Size(139, 40);
            label1.TabIndex = 19;
            label1.Text = "Профиль";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.profile;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(35, 135);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(217, 182);
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // fnameTB
            // 
            fnameTB.AutoSize = true;
            fnameTB.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            fnameTB.Location = new Point(314, 135);
            fnameTB.Name = "fnameTB";
            fnameTB.Size = new Size(55, 30);
            fnameTB.TabIndex = 21;
            fnameTB.Text = "Имя";
            // 
            // lNmaeTB
            // 
            lNmaeTB.AutoSize = true;
            lNmaeTB.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lNmaeTB.Location = new Point(314, 176);
            lNmaeTB.Name = "lNmaeTB";
            lNmaeTB.Size = new Size(100, 30);
            lNmaeTB.TabIndex = 22;
            lNmaeTB.Text = "Фамилия";
            // 
            // dobTB
            // 
            dobTB.AutoSize = true;
            dobTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dobTB.Location = new Point(314, 226);
            dobTB.Name = "dobTB";
            dobTB.Size = new Size(146, 25);
            dobTB.TabIndex = 23;
            dobTB.Text = "Дата рождения";
            // 
            // phoneTB
            // 
            phoneTB.AutoSize = true;
            phoneTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            phoneTB.Location = new Point(314, 267);
            phoneTB.Name = "phoneTB";
            phoneTB.Size = new Size(158, 25);
            phoneTB.TabIndex = 24;
            phoneTB.Text = "Номер телефона";
            // 
            // backButton
            // 
            backButton.Location = new Point(35, 516);
            backButton.Name = "backButton";
            backButton.Size = new Size(116, 47);
            backButton.TabIndex = 27;
            backButton.Text = "Назад";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // profile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 605);
            Controls.Add(backButton);
            Controls.Add(phoneTB);
            Controls.Add(dobTB);
            Controls.Add(lNmaeTB);
            Controls.Add(fnameTB);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "profile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "profile";
            Load += profile_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button logoutButton;
        private Label usernameLabel;
        private Label label1;
        private PictureBox pictureBox1;
        private Label fnameTB;
        private Label lNmaeTB;
        private Label dobTB;
        private Label phoneTB;
        private Button backButton;
        private LinkLabel linkLabel1;
    }
}