namespace App
{
    partial class stats
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
            backButton = new Button();
            groupBox1 = new GroupBox();
            statsall = new Button();
            statsmonth = new Button();
            stasweek = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
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
            panel1.TabIndex = 2;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Blue;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            linkLabel1.LinkColor = Color.Blue;
            linkLabel1.Location = new Point(44, 5);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(75, 21);
            linkLabel1.TabIndex = 6;
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
            // backButton
            // 
            backButton.Location = new Point(44, 524);
            backButton.Name = "backButton";
            backButton.Size = new Size(116, 47);
            backButton.TabIndex = 16;
            backButton.Text = "Назад";
            backButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(statsall);
            groupBox1.Controls.Add(statsmonth);
            groupBox1.Controls.Add(stasweek);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(56, 102);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(503, 145);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Статистика";
            // 
            // statsall
            // 
            statsall.Location = new Point(316, 66);
            statsall.Name = "statsall";
            statsall.Size = new Size(127, 33);
            statsall.TabIndex = 2;
            statsall.Text = "За всё время";
            statsall.UseVisualStyleBackColor = true;
            statsall.Click += statsall_Click;
            // 
            // statsmonth
            // 
            statsmonth.Location = new Point(169, 66);
            statsmonth.Name = "statsmonth";
            statsmonth.Size = new Size(127, 33);
            statsmonth.TabIndex = 1;
            statsmonth.Text = "За месяц";
            statsmonth.UseVisualStyleBackColor = true;
            statsmonth.Click += statsmonth_Click;
            // 
            // stasweek
            // 
            stasweek.Location = new Point(15, 66);
            stasweek.Name = "stasweek";
            stasweek.Size = new Size(127, 33);
            stasweek.TabIndex = 0;
            stasweek.Text = "За неделю";
            stasweek.UseVisualStyleBackColor = true;
            stasweek.Click += stasweek_Click;
            // 
            // stats
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 605);
            Controls.Add(groupBox1);
            Controls.Add(backButton);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "stats";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "stats";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private LinkLabel linkLabel1;
        private Button logoutButton;
        private Label usernameLabel;
        private Button backButton;
        private GroupBox groupBox1;
        private Button stasweek;
        private Button statsall;
        private Button statsmonth;
    }
}