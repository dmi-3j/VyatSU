namespace App
{
    partial class vaccineInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vaccineInfoForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            nameLabel = new Label();
            countryLabel = new Label();
            validPeriodLabel = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(245, 30);
            label1.TabIndex = 0;
            label1.Text = "Информация о вакцине";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(176, 63);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 1;
            label2.Text = "Название:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(176, 100);
            label3.Name = "label3";
            label3.Size = new Size(177, 21);
            label3.TabIndex = 2;
            label3.Text = "Страна производитель:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(176, 133);
            label4.Name = "label4";
            label4.Size = new Size(137, 21);
            label4.TabIndex = 3;
            label4.Text = "Период действия:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.Location = new Point(387, 63);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(78, 21);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Название";
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            countryLabel.Location = new Point(387, 100);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new Size(61, 21);
            countryLabel.TabIndex = 5;
            countryLabel.Text = "Страна";
            // 
            // validPeriodLabel
            // 
            validPeriodLabel.AutoSize = true;
            validPeriodLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            validPeriodLabel.Location = new Point(387, 133);
            validPeriodLabel.Name = "validPeriodLabel";
            validPeriodLabel.Size = new Size(115, 21);
            validPeriodLabel.TabIndex = 6;
            validPeriodLabel.Text = "Срок действия";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(16, 63);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 91);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // vaccineInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 192);
            Controls.Add(pictureBox1);
            Controls.Add(validPeriodLabel);
            Controls.Add(countryLabel);
            Controls.Add(nameLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(653, 231);
            MinimumSize = new Size(653, 231);
            Name = "vaccineInfoForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Информация о вакцине";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label nameLabel;
        private Label countryLabel;
        private Label validPeriodLabel;
        private PictureBox pictureBox1;
    }
}