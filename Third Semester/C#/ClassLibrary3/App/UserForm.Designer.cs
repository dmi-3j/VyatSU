namespace App
{
    partial class UserForm
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
            menuStrip1 = new MenuStrip();
            statusStrip = new StatusStrip();
            userNameLabel = new ToolStripStatusLabel();
            vaccinationBox = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { userNameLabel });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 1;
            // 
            // userNameLabel
            // 
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(89, 17);
            userNameLabel.Text = "userNameLabel";
            // 
            // vaccinationBox
            // 
            vaccinationBox.Location = new Point(33, 24);
            vaccinationBox.Name = "vaccinationBox";
            vaccinationBox.Size = new Size(305, 354);
            vaccinationBox.TabIndex = 2;
            vaccinationBox.Text = "";
            vaccinationBox.Click += vaccinationBox_Click;
            // 
            // button1
            // 
            button1.Location = new Point(446, 195);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(446, 233);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(vaccinationBox);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "UserForm";
            Text = "UserForm";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel userNameLabel;
        private RichTextBox vaccinationBox;
        private Button button1;
        private Button button2;
    }
}