namespace App
{
    partial class addInventoryForm
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
            logoutButton = new Button();
            usernameLabel = new Label();
            label1 = new Label();
            titleTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            comboBox1 = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            uploadPhotoButton = new Button();
            pictureBox1 = new PictureBox();
            addButton = new Button();
            backButton = new Button();
            numericUpDown2 = new NumericUpDown();
            label5 = new Label();
            linkLabel1 = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(logoutButton);
            panel1.Controls.Add(usernameLabel);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1125, 36);
            panel1.TabIndex = 2;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(1041, 5);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 2;
            logoutButton.Text = "Выйти";
            logoutButton.UseVisualStyleBackColor = true;
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
            label1.Location = new Point(46, 65);
            label1.Name = "label1";
            label1.Size = new Size(328, 40);
            label1.TabIndex = 3;
            label1.Text = "Добавление инвентаря";
            // 
            // titleTextBox
            // 
            titleTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            titleTextBox.Location = new Point(46, 150);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.PlaceholderText = "Лыжи беговые";
            titleTextBox.Size = new Size(292, 29);
            titleTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(46, 126);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 7;
            label2.Text = "Название:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(46, 321);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 8;
            label3.Text = "Цена аренды:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericUpDown1.Location = new Point(46, 345);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(292, 29);
            numericUpDown1.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(46, 254);
            label4.Name = "label4";
            label4.Size = new Size(118, 21);
            label4.TabIndex = 10;
            label4.Text = "Тип инвентаря:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Лыжи", "Лыжные ботинки", "Лыжные палки" });
            comboBox1.Location = new Point(46, 278);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(292, 29);
            comboBox1.TabIndex = 11;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // uploadPhotoButton
            // 
            uploadPhotoButton.Location = new Point(659, 358);
            uploadPhotoButton.Name = "uploadPhotoButton";
            uploadPhotoButton.Size = new Size(140, 35);
            uploadPhotoButton.TabIndex = 12;
            uploadPhotoButton.Text = "Загрузить фото";
            uploadPhotoButton.UseVisualStyleBackColor = true;
            uploadPhotoButton.Click += uploadPhotoButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(599, 145);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(258, 197);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // addButton
            // 
            addButton.Location = new Point(38, 456);
            addButton.Name = "addButton";
            addButton.Size = new Size(116, 47);
            addButton.TabIndex = 14;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(38, 520);
            backButton.Name = "backButton";
            backButton.Size = new Size(116, 47);
            backButton.TabIndex = 15;
            backButton.Text = "Назад";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericUpDown2.Location = new Point(46, 216);
            numericUpDown2.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(292, 29);
            numericUpDown2.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(46, 192);
            label5.Name = "label5";
            label5.Size = new Size(65, 21);
            label5.TabIndex = 17;
            label5.Text = "Размер:";
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
            // addInventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 605);
            Controls.Add(label5);
            Controls.Add(numericUpDown2);
            Controls.Add(backButton);
            Controls.Add(addButton);
            Controls.Add(pictureBox1);
            Controls.Add(uploadPhotoButton);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(titleTextBox);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "addInventoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "addInventoryForm";
            Load += addInventoryForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button logoutButton;
        private Label usernameLabel;
        private Label label1;
        private TextBox titleTextBox;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private ComboBox comboBox1;
        private OpenFileDialog openFileDialog1;
        private Button uploadPhotoButton;
        private PictureBox pictureBox1;
        private Button addButton;
        private Button backButton;
        private NumericUpDown numericUpDown2;
        private Label label5;
        private LinkLabel linkLabel1;
    }
}