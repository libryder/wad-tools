namespace ActiveDirectoryTools.Forms
{
    partial class SetPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.defaultCheck = new System.Windows.Forms.CheckBox();
            this.passwordConfirmBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.applyButton);
            this.groupBox1.Controls.Add(this.defaultCheck);
            this.groupBox1.Controls.Add(this.passwordConfirmBox);
            this.groupBox1.Controls.Add(this.passwordBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset Password";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(109, 97);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(59, 23);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // defaultCheck
            // 
            this.defaultCheck.AutoSize = true;
            this.defaultCheck.Location = new System.Drawing.Point(9, 84);
            this.defaultCheck.Name = "defaultCheck";
            this.defaultCheck.Size = new System.Drawing.Size(60, 17);
            this.defaultCheck.TabIndex = 2;
            this.defaultCheck.Text = "Default";
            this.defaultCheck.UseVisualStyleBackColor = true;
            this.defaultCheck.CheckedChanged += new System.EventHandler(this.defaultCheck_CheckedChanged);
            // 
            // passwordConfirmBox
            // 
            this.passwordConfirmBox.Location = new System.Drawing.Point(69, 58);
            this.passwordConfirmBox.Name = "passwordConfirmBox";
            this.passwordConfirmBox.PasswordChar = '*';
            this.passwordConfirmBox.Size = new System.Drawing.Size(100, 20);
            this.passwordConfirmBox.TabIndex = 1;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(69, 24);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Confirm:";
            // 
            // SetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 154);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Password";
            this.Load += new System.EventHandler(this.SetPassword_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetPassword_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.CheckBox defaultCheck;
        private System.Windows.Forms.TextBox passwordConfirmBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label2;
    }
}