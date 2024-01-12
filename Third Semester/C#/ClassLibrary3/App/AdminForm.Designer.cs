namespace App
{
    partial class AdminForm
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
            addOrganizationButton = new Button();
            logoutButton = new Button();
            button1 = new Button();
            button2 = new Button();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { userNameLabel });
            statusStrip.Location = new Point(0, 168);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(327, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // userNameLabel
            // 
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(0, 17);
            // 
            // addOrganizationButton
            // 
            addOrganizationButton.Location = new Point(12, 21);
            addOrganizationButton.Name = "addOrganizationButton";
            addOrganizationButton.Size = new Size(304, 31);
            addOrganizationButton.TabIndex = 1;
            addOrganizationButton.Text = "Добавить медицинскую организацию";
            addOrganizationButton.UseVisualStyleBackColor = true;
            addOrganizationButton.Click += addOrganizationButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(12, 132);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(304, 31);
            logoutButton.TabIndex = 2;
            logoutButton.Text = "Выйти из аккаунта";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 58);
            button1.Name = "button1";
            button1.Size = new Size(304, 31);
            button1.TabIndex = 3;
            button1.Text = "Добавить пользователя";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 95);
            button2.Name = "button2";
            button2.Size = new Size(304, 31);
            button2.TabIndex = 4;
            button2.Text = "Добавить прививку";
            button2.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 190);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(logoutButton);
            Controls.Add(addOrganizationButton);
            Controls.Add(statusStrip);
            Name = "AdminForm";
            Text = "Администрирование";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStripStatusLabel userNameLabel;
        private Button addOrganizationButton;
        private Button logoutButton;
        private Button button1;
        private Button button2;
    }
}