namespace App
{
    partial class VaccinationInfoForm
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
            serialLabel = new Label();
            vaccineLabel = new Label();
            medorgLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            medorgInfoButton = new Button();
            addReactionButton = new Button();
            SuspendLayout();
            // 
            // serialLabel
            // 
            serialLabel.AutoSize = true;
            serialLabel.Location = new Point(191, 32);
            serialLabel.Name = "serialLabel";
            serialLabel.Size = new Size(110, 15);
            serialLabel.TabIndex = 0;
            serialLabel.Text = "Серия вакцинации";
            // 
            // vaccineLabel
            // 
            vaccineLabel.AutoSize = true;
            vaccineLabel.Location = new Point(191, 71);
            vaccineLabel.Name = "vaccineLabel";
            vaccineLabel.Size = new Size(53, 15);
            vaccineLabel.TabIndex = 1;
            vaccineLabel.Text = "Вакцина";
            // 
            // medorgLabel
            // 
            medorgLabel.AutoSize = true;
            medorgLabel.Location = new Point(191, 107);
            medorgLabel.Name = "medorgLabel";
            medorgLabel.Size = new Size(155, 15);
            medorgLabel.TabIndex = 2;
            medorgLabel.Text = "Медицинская организация";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 3;
            label1.Text = "Серия вакцинации:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 4;
            label2.Text = "Вакцина:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 107);
            label3.Name = "label3";
            label3.Size = new Size(158, 15);
            label3.TabIndex = 5;
            label3.Text = "Медицинская организация:";
            // 
            // medorgInfoButton
            // 
            medorgInfoButton.Location = new Point(373, 95);
            medorgInfoButton.Name = "medorgInfoButton";
            medorgInfoButton.Size = new Size(113, 38);
            medorgInfoButton.TabIndex = 6;
            medorgInfoButton.Text = "Подробнее \r\nоб организации";
            medorgInfoButton.UseVisualStyleBackColor = true;
            medorgInfoButton.Click += medorgInfoButton_Click;
            // 
            // addReactionButton
            // 
            addReactionButton.Location = new Point(373, 254);
            addReactionButton.Name = "addReactionButton";
            addReactionButton.Size = new Size(148, 23);
            addReactionButton.TabIndex = 7;
            addReactionButton.Text = "Добавить реакцию";
            addReactionButton.UseVisualStyleBackColor = true;
            addReactionButton.Click += addReactionButton_Click;
            // 
            // VaccinationInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 289);
            Controls.Add(addReactionButton);
            Controls.Add(medorgInfoButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(medorgLabel);
            Controls.Add(vaccineLabel);
            Controls.Add(serialLabel);
            Name = "VaccinationInfoForm";
            Text = "VaccinationInfoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label serialLabel;
        private Label vaccineLabel;
        private Label medorgLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button medorgInfoButton;
        private Button addReactionButton;
    }
}