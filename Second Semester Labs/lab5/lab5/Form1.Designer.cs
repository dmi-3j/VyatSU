namespace BinaryTree
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.solution = new System.Windows.Forms.ToolStripMenuItem();
            this.Load = new System.Windows.Forms.ToolStripMenuItem();
            this.bypass = new System.Windows.Forms.ToolStripMenuItem();
            this.LNR = new System.Windows.Forms.ToolStripMenuItem();
            this.NLR = new System.Windows.Forms.ToolStripMenuItem();
            this.LRN = new System.Windows.Forms.ToolStripMenuItem();
            this.RNL = new System.Windows.Forms.ToolStripMenuItem();
            this.BFS = new System.Windows.Forms.ToolStripMenuItem();
            this.All = new System.Windows.Forms.ToolStripMenuItem();
            this.HomeTask = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.Close = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTree = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxBypass = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solution,
            this.Help,
            this.Close});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1115, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // solution
            // 
            this.solution.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Load,
            this.bypass,
            this.HomeTask});
            this.solution.Name = "solution";
            this.solution.Size = new System.Drawing.Size(134, 21);
            this.solution.Text = "Обработка данных";
            // 
            // Load
            // 
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(307, 22);
            this.Load.Text = "Загрузить данные";
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // bypass
            // 
            this.bypass.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LNR,
            this.NLR,
            this.LRN,
            this.RNL,
            this.BFS,
            this.All});
            this.bypass.Name = "bypass";
            this.bypass.Size = new System.Drawing.Size(307, 22);
            this.bypass.Text = "Выполнить обход";
            // 
            // LNR
            // 
            this.LNR.Name = "LNR";
            this.LNR.Size = new System.Drawing.Size(250, 22);
            this.LNR.Text = "Симметричный метод - LNR";
            this.LNR.Click += new System.EventHandler(this.LNR_Click);
            // 
            // NLR
            // 
            this.NLR.Name = "NLR";
            this.NLR.Size = new System.Drawing.Size(250, 22);
            this.NLR.Text = "Прямой метод - NLR";
            this.NLR.Click += new System.EventHandler(this.NLR_Click);
            // 
            // LRN
            // 
            this.LRN.Name = "LRN";
            this.LRN.Size = new System.Drawing.Size(250, 22);
            this.LRN.Text = " Обратный метод - LRN";
            this.LRN.Click += new System.EventHandler(this.LRN_Click);
            // 
            // RNL
            // 
            this.RNL.Name = "RNL";
            this.RNL.Size = new System.Drawing.Size(250, 22);
            this.RNL.Text = "Метод справа-налево -  RNL";
            this.RNL.Click += new System.EventHandler(this.RNL_Click);
            // 
            // BFS
            // 
            this.BFS.Name = "BFS";
            this.BFS.Size = new System.Drawing.Size(250, 22);
            this.BFS.Text = "Обход в ширину - BFS";
            this.BFS.Click += new System.EventHandler(this.BFS_Click);
            // 
            // All
            // 
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(250, 22);
            this.All.Text = "Все..";
            this.All.Click += new System.EventHandler(this.All_Click);
            // 
            // HomeTask
            // 
            this.HomeTask.Name = "HomeTask";
            this.HomeTask.Size = new System.Drawing.Size(307, 22);
            this.HomeTask.Text = "Вывести слой с минимальным ключом";
            this.HomeTask.Click += new System.EventHandler(this.HomeTask_Click);
            // 
            // Help
            // 
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(70, 21);
            this.Help.Text = "Справка";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Close
            // 
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(57, 21);
            this.Close.Text = "Выход";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTree);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 507);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дерево";
            // 
            // textBoxTree
            // 
            this.textBoxTree.Location = new System.Drawing.Point(7, 20);
            this.textBoxTree.Multiline = true;
            this.textBoxTree.Name = "textBoxTree";
            this.textBoxTree.ReadOnly = true;
            this.textBoxTree.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTree.Size = new System.Drawing.Size(472, 481);
            this.textBoxTree.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxBypass);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(530, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 295);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Обходы";
            // 
            // textBoxBypass
            // 
            this.textBoxBypass.Location = new System.Drawing.Point(7, 20);
            this.textBoxBypass.Multiline = true;
            this.textBoxBypass.Name = "textBoxBypass";
            this.textBoxBypass.ReadOnly = true;
            this.textBoxBypass.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBypass.Size = new System.Drawing.Size(560, 257);
            this.textBoxBypass.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxSearch);
            this.groupBox3.Controls.Add(this.buttonSearch);
            this.groupBox3.Controls.Add(this.textBoxKey);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(530, 358);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(573, 186);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поиск ключа";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(7, 69);
            this.textBoxSearch.Multiline = true;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.ReadOnly = true;
            this.textBoxSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSearch.Size = new System.Drawing.Size(560, 114);
            this.textBoxSearch.TabIndex = 2;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(398, 32);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(169, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(6, 34);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(373, 22);
            this.textBoxKey.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1115, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(131, 17);
            this.statusLabel.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 574);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1131, 613);
            this.MinimumSize = new System.Drawing.Size(1131, 613);
            this.Name = "Form1";
            this.Text = "Бинарные деревья";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem solution;
        private System.Windows.Forms.ToolStripMenuItem Close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxTree;
        private System.Windows.Forms.TextBox textBoxBypass;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ToolStripMenuItem Load;
        private System.Windows.Forms.ToolStripMenuItem bypass;
        private System.Windows.Forms.ToolStripMenuItem LNR;
        private System.Windows.Forms.ToolStripMenuItem NLR;
        private System.Windows.Forms.ToolStripMenuItem LRN;
        private System.Windows.Forms.ToolStripMenuItem RNL;
        private System.Windows.Forms.ToolStripMenuItem BFS;
        private System.Windows.Forms.ToolStripMenuItem All;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem HomeTask;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem Help;
    }
}

