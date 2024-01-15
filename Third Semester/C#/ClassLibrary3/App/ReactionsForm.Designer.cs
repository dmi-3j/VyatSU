namespace App
{
    partial class ReactionsForm
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
            label1 = new Label();
            reactionsTable = new DataGridView();
            idr = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            text = new DataGridViewTextBoxColumn();
            action = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)reactionsTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(118, 9);
            label1.Name = "label1";
            label1.Size = new Size(286, 30);
            label1.TabIndex = 0;
            label1.Text = "Реакции на эту вакцинацию";
            // 
            // reactionsTable
            // 
            reactionsTable.AllowUserToAddRows = false;
            reactionsTable.AllowUserToDeleteRows = false;
            reactionsTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            reactionsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reactionsTable.Columns.AddRange(new DataGridViewColumn[] { idr, date, text, action });
            reactionsTable.Location = new Point(12, 58);
            reactionsTable.Name = "reactionsTable";
            reactionsTable.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            reactionsTable.RowsDefaultCellStyle = dataGridViewCellStyle1;
            reactionsTable.RowTemplate.Height = 25;
            reactionsTable.Size = new Size(504, 209);
            reactionsTable.TabIndex = 1;
            reactionsTable.CellContentClick += reactionsTable_CellContentClick;
            // 
            // idr
            // 
            idr.HeaderText = "idr";
            idr.Name = "idr";
            idr.ReadOnly = true;
            idr.Visible = false;
            // 
            // date
            // 
            date.HeaderText = "Дата реакции";
            date.Name = "date";
            date.ReadOnly = true;
            // 
            // text
            // 
            text.HeaderText = "Текст реакции";
            text.Name = "text";
            text.ReadOnly = true;
            text.Width = 300;
            // 
            // action
            // 
            action.HeaderText = "Действие";
            action.Name = "action";
            action.ReadOnly = true;
            action.Resizable = DataGridViewTriState.True;
            action.SortMode = DataGridViewColumnSortMode.Automatic;
            action.Text = "Удалить";
            action.UseColumnTextForButtonValue = true;
            // 
            // ReactionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 294);
            Controls.Add(reactionsTable);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(541, 333);
            MinimumSize = new Size(541, 333);
            Name = "ReactionsForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Реакции";
            Load += ReactionsForm_Load;
            ((System.ComponentModel.ISupportInitialize)reactionsTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView reactionsTable;
        private DataGridViewTextBoxColumn idr;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn text;
        private DataGridViewButtonColumn action;
    }
}