namespace App
{
    partial class MedPersonalForm
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
            statusStrip = new StatusStrip();
            userNameLabel = new ToolStripStatusLabel();
            logoutButton = new Button();
            viewRecordsButton = new Button();
            findUserButton = new Button();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { userNameLabel });
            statusStrip.Location = new Point(0, 142);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(330, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // userNameLabel
            // 
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(118, 17);
            userNameLabel.Text = "toolStripStatusLabel1";
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(25, 94);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(274, 35);
            logoutButton.TabIndex = 1;
            logoutButton.Text = "Выйти из аккаунта";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // viewRecordsButton
            // 
            viewRecordsButton.Location = new Point(25, 12);
            viewRecordsButton.Name = "viewRecordsButton";
            viewRecordsButton.Size = new Size(274, 35);
            viewRecordsButton.TabIndex = 2;
            viewRecordsButton.Text = "Посмотреть записи на вакцинацию";
            viewRecordsButton.UseVisualStyleBackColor = true;
            viewRecordsButton.Click += viewRecordsButton_Click;
            // 
            // findUserButton
            // 
            findUserButton.Location = new Point(25, 53);
            findUserButton.Name = "findUserButton";
            findUserButton.Size = new Size(274, 35);
            findUserButton.TabIndex = 3;
            findUserButton.Text = "Найти пользователя";
            findUserButton.UseVisualStyleBackColor = true;
            findUserButton.Click += findUserButton_Click;
            // 
            // MedPersonalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 164);
            Controls.Add(findUserButton);
            Controls.Add(viewRecordsButton);
            Controls.Add(logoutButton);
            Controls.Add(statusStrip);
            MaximizeBox = false;
            Name = "MedPersonalForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Медицинский работник";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private Button logoutButton;
        private Button viewRecordsButton;
        private Button findUserButton;
        private ToolStripStatusLabel userNameLabel;
    }
}