namespace App
{
    partial class FindUserForm
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
            label1 = new Label();
            label2 = new Label();
            inshuranceNumberTextBox = new TextBox();
            findButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(40, 9);
            label1.Name = "label1";
            label1.Size = new Size(209, 30);
            label1.TabIndex = 0;
            label1.Text = "Найти пользователя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(155, 21);
            label2.TabIndex = 1;
            label2.Text = "Номер полиса ОМС:";
            // 
            // inshuranceNumberTextBox
            // 
            inshuranceNumberTextBox.Location = new Point(12, 79);
            inshuranceNumberTextBox.Name = "inshuranceNumberTextBox";
            inshuranceNumberTextBox.Size = new Size(276, 23);
            inshuranceNumberTextBox.TabIndex = 2;
            // 
            // findButton
            // 
            findButton.Location = new Point(12, 128);
            findButton.Name = "findButton";
            findButton.Size = new Size(276, 37);
            findButton.TabIndex = 3;
            findButton.Text = "Найти";
            findButton.UseVisualStyleBackColor = true;
            findButton.Click += findButton_Click;
            // 
            // FindUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 189);
            Controls.Add(findButton);
            Controls.Add(inshuranceNumberTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(316, 228);
            MinimumSize = new Size(316, 228);
            Name = "FindUserForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Найти пользователя";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox inshuranceNumberTextBox;
        private Button findButton;
    }
}