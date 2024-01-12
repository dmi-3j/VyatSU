namespace App
{
    partial class addReactionForm
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
            reactionTextBox = new RichTextBox();
            label = new Label();
            addReactionButton = new Button();
            SuspendLayout();
            // 
            // reactionTextBox
            // 
            reactionTextBox.Location = new Point(12, 53);
            reactionTextBox.Name = "reactionTextBox";
            reactionTextBox.Size = new Size(511, 291);
            reactionTextBox.TabIndex = 0;
            reactionTextBox.Text = "";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label.Location = new Point(12, 25);
            label.Name = "label";
            label.Size = new Size(140, 25);
            label.TabIndex = 1;
            label.Text = "Текст реакции:";
            // 
            // addReactionButton
            // 
            addReactionButton.Location = new Point(397, 350);
            addReactionButton.Name = "addReactionButton";
            addReactionButton.Size = new Size(126, 23);
            addReactionButton.TabIndex = 2;
            addReactionButton.Text = "Добавить";
            addReactionButton.UseVisualStyleBackColor = true;
            addReactionButton.Click += addReactionButton_Click;
            // 
            // addReactionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 385);
            Controls.Add(addReactionButton);
            Controls.Add(label);
            Controls.Add(reactionTextBox);
            Name = "addReactionForm";
            Text = "Реакция на вакцинацию";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox reactionTextBox;
        private Label label;
        private Button addReactionButton;
    }
}