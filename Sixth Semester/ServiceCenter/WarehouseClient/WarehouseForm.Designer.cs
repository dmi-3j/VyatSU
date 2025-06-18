namespace WarehouseClient
{
    partial class WarehouseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.BtnExportToExcel = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvWarehouseParts = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnUpdateWarehouseStatus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPartModel = new System.Windows.Forms.TextBox();
            this.BtnAddPartToWarehouse = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtPartPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeletePart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouseParts)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(351, 402);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(327, 84);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // txtPartName
            // 
            this.txtPartName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPartName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPartName.Location = new System.Drawing.Point(683, 365);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(363, 22);
            this.txtPartName.TabIndex = 4;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExportToExcel.Location = new System.Drawing.Point(352, 365);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnExportToExcel.Size = new System.Drawing.Size(325, 32);
            this.BtnExportToExcel.TabIndex = 14;
            this.BtnExportToExcel.Text = "Печать";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvOrders.Location = new System.Drawing.Point(3, 25);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowHeadersWidth = 48;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(343, 334);
            this.dgvOrders.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(683, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(363, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Комплектующие на складе";
            // 
            // dgvWarehouseParts
            // 
            this.dgvWarehouseParts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvWarehouseParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouseParts.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvWarehouseParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWarehouseParts.EnableHeadersVisualStyles = false;
            this.dgvWarehouseParts.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvWarehouseParts.Location = new System.Drawing.Point(683, 25);
            this.dgvWarehouseParts.Name = "dgvWarehouseParts";
            this.dgvWarehouseParts.ReadOnly = true;
            this.dgvWarehouseParts.RowHeadersVisible = false;
            this.dgvWarehouseParts.RowHeadersWidth = 48;
            this.dgvWarehouseParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouseParts.Size = new System.Drawing.Size(363, 334);
            this.dgvWarehouseParts.TabIndex = 8;
            this.dgvWarehouseParts.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvWarehouseParts_CellMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(352, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Отчет";
            // 
            // BtnUpdateWarehouseStatus
            // 
            this.BtnUpdateWarehouseStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnUpdateWarehouseStatus.Location = new System.Drawing.Point(3, 365);
            this.BtnUpdateWarehouseStatus.Name = "BtnUpdateWarehouseStatus";
            this.BtnUpdateWarehouseStatus.Size = new System.Drawing.Size(343, 32);
            this.BtnUpdateWarehouseStatus.TabIndex = 12;
            this.BtnUpdateWarehouseStatus.Text = "Обновить";
            this.BtnUpdateWarehouseStatus.UseVisualStyleBackColor = true;
            this.BtnUpdateWarehouseStatus.Click += new System.EventHandler(this.BtnUpdateWarehouseStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Заявки на комплектующие";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.30626F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.60032F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.09342F));
            this.tableLayoutPanel1.Controls.Add(this.dgvReport, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnUpdateWarehouseStatus, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvWarehouseParts, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvOrders, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPartName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.BtnExportToExcel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.515486F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.6187F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.778638F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.08717F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1049, 496);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvReport.Location = new System.Drawing.Point(352, 25);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowHeadersWidth = 48;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(325, 334);
            this.dgvReport.TabIndex = 15;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.08614F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.91386F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPartModel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnAddPartToWarehouse, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtQuantity, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPartPrice, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnDeletePart, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(682, 402);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(365, 92);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Модель";
            // 
            // txtPartModel
            // 
            this.txtPartModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPartModel.Location = new System.Drawing.Point(86, 3);
            this.txtPartModel.Name = "txtPartModel";
            this.txtPartModel.Size = new System.Drawing.Size(179, 20);
            this.txtPartModel.TabIndex = 10;
            // 
            // BtnAddPartToWarehouse
            // 
            this.BtnAddPartToWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddPartToWarehouse.Location = new System.Drawing.Point(86, 53);
            this.BtnAddPartToWarehouse.Name = "BtnAddPartToWarehouse";
            this.BtnAddPartToWarehouse.Size = new System.Drawing.Size(179, 36);
            this.BtnAddPartToWarehouse.TabIndex = 13;
            this.BtnAddPartToWarehouse.Text = "Добавить";
            this.BtnAddPartToWarehouse.UseVisualStyleBackColor = true;
            this.BtnAddPartToWarehouse.Click += new System.EventHandler(this.BtnAddPartToWarehouse_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantity.Location = new System.Drawing.Point(271, 28);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(91, 20);
            this.txtQuantity.TabIndex = 12;
            this.txtQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPartPrice
            // 
            this.txtPartPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPartPrice.Location = new System.Drawing.Point(86, 28);
            this.txtPartPrice.Name = "txtPartPrice";
            this.txtPartPrice.Size = new System.Drawing.Size(179, 20);
            this.txtPartPrice.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Цена";
            // 
            // btnDeletePart
            // 
            this.btnDeletePart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeletePart.Location = new System.Drawing.Point(271, 53);
            this.btnDeletePart.Name = "btnDeletePart";
            this.btnDeletePart.Size = new System.Drawing.Size(91, 36);
            this.btnDeletePart.TabIndex = 16;
            this.btnDeletePart.Text = "Удалить";
            this.btnDeletePart.UseVisualStyleBackColor = true;
            this.btnDeletePart.Click += new System.EventHandler(this.BtnDeletePart_Click);
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 496);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(1053, 510);
            this.Name = "WarehouseForm";
            this.Text = "WarehouseForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouseParts)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Button BtnExportToExcel;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvWarehouseParts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnUpdateWarehouseStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPartModel;
        private System.Windows.Forms.Button BtnAddPartToWarehouse;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.TextBox txtPartPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeletePart;
    }
}

