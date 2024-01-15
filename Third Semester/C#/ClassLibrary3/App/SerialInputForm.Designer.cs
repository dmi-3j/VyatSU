namespace App
{
    partial class SerialInputForm
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
            okButton = new Button();
            label1 = new Label();
            input = new TextBox();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Location = new Point(86, 76);
            okButton.Name = "okButton";
            okButton.Size = new Size(109, 34);
            okButton.TabIndex = 0;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(226, 21);
            label1.TabIndex = 1;
            label1.Text = "Серия для новой вакцинации:";
            // 
            // input
            // 
            input.Location = new Point(8, 33);
            input.Name = "input";
            input.Size = new Size(274, 23);
            input.TabIndex = 2;
            // 
            // SerialInputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(290, 122);
            Controls.Add(input);
            Controls.Add(label1);
            Controls.Add(okButton);
            MaximizeBox = false;
            MaximumSize = new Size(306, 161);
            MinimumSize = new Size(306, 161);
            Name = "SerialInputForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Серия для новой вакцинации";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button okButton;
        private Label label1;
        private TextBox input;
    }
}