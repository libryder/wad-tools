namespace ActiveDirectoryTools.Forms
{
    partial class GetTextInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetTextInput));
            this.textInputLabel = new System.Windows.Forms.Label();
            this.textInputBox = new System.Windows.Forms.TextBox();
            this.textInputButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textInputLabel
            // 
            this.textInputLabel.AutoSize = true;
            this.textInputLabel.Location = new System.Drawing.Point(13, 13);
            this.textInputLabel.Name = "textInputLabel";
            this.textInputLabel.Size = new System.Drawing.Size(89, 13);
            this.textInputLabel.TabIndex = 5;
            this.textInputLabel.Text = "Enter information:";
            // 
            // textInputBox
            // 
            this.textInputBox.Location = new System.Drawing.Point(16, 38);
            this.textInputBox.Name = "textInputBox";
            this.textInputBox.Size = new System.Drawing.Size(246, 20);
            this.textInputBox.TabIndex = 0;
            // 
            // textInputButton
            // 
            this.textInputButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.textInputButton.Location = new System.Drawing.Point(227, 64);
            this.textInputButton.Name = "textInputButton";
            this.textInputButton.Size = new System.Drawing.Size(35, 23);
            this.textInputButton.TabIndex = 1;
            this.textInputButton.Text = "Ok";
            this.textInputButton.UseVisualStyleBackColor = true;
            this.textInputButton.Click += new System.EventHandler(this.textInputButton_Click);
            // 
            // GetTextInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 95);
            this.Controls.Add(this.textInputButton);
            this.Controls.Add(this.textInputBox);
            this.Controls.Add(this.textInputLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetTextInput";
            this.Text = "Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textInputLabel;
        private System.Windows.Forms.TextBox textInputBox;
        private System.Windows.Forms.Button textInputButton;
    }
}