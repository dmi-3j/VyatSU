namespace App
{
    partial class medicalOrganizationInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(medicalOrganizationInfoForm));
            nameLabel = new Label();
            addressLabel = new Label();
            phoneLabel = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.Location = new Point(191, 19);
            nameLabel.Name = "nameLabel";
            nameLabel.RightToLeft = RightToLeft.No;
            nameLabel.Size = new Size(120, 32);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Название";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            addressLabel.Location = new Point(191, 72);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(71, 30);
            addressLabel.TabIndex = 1;
            addressLabel.Text = "Адрес";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            phoneLabel.Location = new Point(191, 111);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(175, 30);
            phoneLabel.TabIndex = 2;
            phoneLabel.Text = "Номер телефона";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 122);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // medicalOrganizationInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 194);
            Controls.Add(pictureBox1);
            Controls.Add(phoneLabel);
            Controls.Add(addressLabel);
            Controls.Add(nameLabel);
            Name = "medicalOrganizationInfoForm";
            Text = "Информация о медицинской организации";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private Label addressLabel;
        private Label phoneLabel;
        private PictureBox pictureBox1;
    }
}