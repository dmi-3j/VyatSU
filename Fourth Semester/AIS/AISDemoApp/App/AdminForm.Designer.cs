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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            linkLabel1 = new LinkLabel();
            logoutButton = new Button();
            usernameLabel = new Label();
            addButton = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            photo = new DataGridViewImageColumn();
            name = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            size = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            actionRed = new DataGridViewButtonColumn();
            actionDel = new DataGridViewButtonColumn();
            clearButton = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            panel1.TabIndex = 1;
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
            usernameLabel.Click += usernameLabel_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(929, 515);
            addButton.Name = "addButton";
            addButton.Size = new Size(161, 60);
            addButton.TabIndex = 2;
            addButton.Text = "Добавить ";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(44, 73);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Название инвентаря";
            textBox1.Size = new Size(319, 29);
            textBox1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(405, 73);
            button2.Name = "button2";
            button2.Size = new Size(89, 29);
            button2.TabIndex = 4;
            button2.Text = "Найти";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, photo, name, type, size, price, actionRed, actionDel });
            dataGridView1.Location = new Point(48, 130);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1034, 351);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Id
            // 
            Id.FillWeight = 200F;
            Id.HeaderText = "";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 200;
            // 
            // photo
            // 
            photo.HeaderText = "";
            photo.ImageLayout = DataGridViewImageCellLayout.Zoom;
            photo.Name = "photo";
            photo.ReadOnly = true;
            photo.Width = 200;
            // 
            // name
            // 
            name.HeaderText = "Название";
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 250;
            // 
            // type
            // 
            type.HeaderText = "Тип";
            type.Name = "type";
            type.ReadOnly = true;
            type.Width = 120;
            // 
            // size
            // 
            size.HeaderText = "Размер";
            size.Name = "size";
            size.ReadOnly = true;
            // 
            // price
            // 
            price.HeaderText = "Цена аренды";
            price.Name = "price";
            price.ReadOnly = true;
            // 
            // actionRed
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.SelectionBackColor = Color.Green;
            actionRed.DefaultCellStyle = dataGridViewCellStyle3;
            actionRed.HeaderText = "";
            actionRed.Name = "actionRed";
            actionRed.ReadOnly = true;
            actionRed.Text = "Редактировать";
            actionRed.UseColumnTextForButtonValue = true;
            // 
            // actionDel
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.ForeColor = Color.Red;
            dataGridViewCellStyle4.SelectionBackColor = Color.Red;
            actionDel.DefaultCellStyle = dataGridViewCellStyle4;
            actionDel.HeaderText = "";
            actionDel.Name = "actionDel";
            actionDel.ReadOnly = true;
            actionDel.Text = "Удалить";
            actionDel.UseColumnTextForButtonValue = true;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(500, 73);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(89, 29);
            clearButton.TabIndex = 6;
            clearButton.Text = "Сбросить";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 605);
            Controls.Add(clearButton);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(addButton);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm";
            Load += AdminForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label usernameLabel;
        private Button logoutButton;
        private Button addButton;
        private TextBox textBox1;
        private Button button2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewImageColumn photo;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn size;
        private DataGridViewTextBoxColumn price;
        private DataGridViewButtonColumn actionRed;
        private DataGridViewButtonColumn actionDel;
        private LinkLabel linkLabel1;
        private Button clearButton;
    }
}