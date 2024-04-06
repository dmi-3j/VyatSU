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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            linkLabel1 = new LinkLabel();
            logoutButton = new Button();
            usernameLabel = new Label();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            photo = new DataGridViewImageColumn();
            name = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            size = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            actionCart = new DataGridViewButtonColumn();
            clearButton = new Button();
            finaButton = new Button();
            searchTextBox = new TextBox();
            groupBox1 = new GroupBox();
            resBut = new Button();
            filterButton = new Button();
            label23 = new Label();
            typeComboBox = new ComboBox();
            priceTo = new TextBox();
            priceFrom = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            panel1.TabIndex = 5;
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
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, photo, name, type, size, price, actionCart });
            dataGridView1.Location = new Point(45, 152);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1034, 400);
            dataGridView1.TabIndex = 6;
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
            // actionCart
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.SelectionBackColor = Color.Green;
            actionCart.DefaultCellStyle = dataGridViewCellStyle1;
            actionCart.HeaderText = "";
            actionCart.Name = "actionCart";
            actionCart.ReadOnly = true;
            actionCart.Text = "В корзину";
            actionCart.UseColumnTextForButtonValue = true;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(520, 58);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(89, 29);
            clearButton.TabIndex = 9;
            clearButton.Text = "Сбросить";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // finaButton
            // 
            finaButton.Location = new Point(425, 58);
            finaButton.Name = "finaButton";
            finaButton.Size = new Size(89, 29);
            finaButton.TabIndex = 8;
            finaButton.Text = "Найти";
            finaButton.UseVisualStyleBackColor = true;
            finaButton.Click += finaButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            searchTextBox.Location = new Point(45, 58);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Название инвентаря";
            searchTextBox.Size = new Size(319, 29);
            searchTextBox.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(resBut);
            groupBox1.Controls.Add(filterButton);
            groupBox1.Controls.Add(label23);
            groupBox1.Controls.Add(typeComboBox);
            groupBox1.Controls.Add(priceTo);
            groupBox1.Controls.Add(priceFrom);
            groupBox1.Location = new Point(47, 93);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(562, 53);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Фильтры";
            // 
            // resBut
            // 
            resBut.Location = new Point(481, 22);
            resBut.Name = "resBut";
            resBut.Size = new Size(75, 23);
            resBut.TabIndex = 5;
            resBut.Text = "Сбросить";
            resBut.UseVisualStyleBackColor = true;
            resBut.Click += resBut_Click;
            // 
            // filterButton
            // 
            filterButton.Location = new Point(367, 21);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(108, 23);
            filterButton.TabIndex = 4;
            filterButton.Text = "Отфильтровать";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += filterButton_Click;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(237, 4);
            label23.Name = "label23";
            label23.Size = new Size(27, 15);
            label23.TabIndex = 3;
            label23.Text = "Тип";
            // 
            // typeComboBox
            // 
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(237, 22);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(124, 23);
            typeComboBox.TabIndex = 2;
            // 
            // priceTo
            // 
            priceTo.Location = new Point(122, 22);
            priceTo.Name = "priceTo";
            priceTo.PlaceholderText = "Цена от";
            priceTo.Size = new Size(100, 23);
            priceTo.TabIndex = 1;
            // 
            // priceFrom
            // 
            priceFrom.Location = new Point(6, 22);
            priceFrom.Name = "priceFrom";
            priceFrom.PlaceholderText = "Цена от";
            priceFrom.Size = new Size(100, 23);
            priceFrom.TabIndex = 0;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 605);
            Controls.Add(groupBox1);
            Controls.Add(clearButton);
            Controls.Add(finaButton);
            Controls.Add(searchTextBox);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserForm";
            Load += UserForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private LinkLabel linkLabel1;
        private Button logoutButton;
        private Label usernameLabel;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewImageColumn photo;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn size;
        private DataGridViewTextBoxColumn price;
        private DataGridViewButtonColumn actionCart;
        private Button clearButton;
        private Button finaButton;
        private TextBox searchTextBox;
        private GroupBox groupBox1;
        private Label label23;
        private ComboBox typeComboBox;
        private TextBox priceTo;
        private TextBox priceFrom;
        private Button resBut;
        private Button filterButton;
    }
}