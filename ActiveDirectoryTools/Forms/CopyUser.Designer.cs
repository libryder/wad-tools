namespace ActiveDirectoryTools.Forms
{
    partial class CopyUser
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.defaultPassCheck = new System.Windows.Forms.CheckBox();
            this.passwordVerifyBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.middleBox = new System.Windows.Forms.TextBox();
            this.lastBox = new System.Windows.Forms.TextBox();
            this.firstBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.exchangeCheck = new System.Windows.Forms.CheckBox();
            this.exchangeDropDown = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(206, 280);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(125, 280);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Middle";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exchangeDropDown);
            this.groupBox1.Controls.Add(this.exchangeCheck);
            this.groupBox1.Controls.Add(this.defaultPassCheck);
            this.groupBox1.Controls.Add(this.passwordVerifyBox);
            this.groupBox1.Controls.Add(this.passwordBox);
            this.groupBox1.Controls.Add(this.middleBox);
            this.groupBox1.Controls.Add(this.lastBox);
            this.groupBox1.Controls.Add(this.firstBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 262);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter All Information";
            // 
            // defaultPassCheck
            // 
            this.defaultPassCheck.AutoSize = true;
            this.defaultPassCheck.Location = new System.Drawing.Point(194, 148);
            this.defaultPassCheck.Name = "defaultPassCheck";
            this.defaultPassCheck.Size = new System.Drawing.Size(60, 17);
            this.defaultPassCheck.TabIndex = 3;
            this.defaultPassCheck.Text = "Default";
            this.defaultPassCheck.UseVisualStyleBackColor = true;
            this.defaultPassCheck.CheckedChanged += new System.EventHandler(this.defaultPassCheck_CheckedChanged);
            // 
            // passwordVerifyBox
            // 
            this.passwordVerifyBox.Location = new System.Drawing.Point(90, 182);
            this.passwordVerifyBox.Name = "passwordVerifyBox";
            this.passwordVerifyBox.PasswordChar = '*';
            this.passwordVerifyBox.Size = new System.Drawing.Size(100, 20);
            this.passwordVerifyBox.TabIndex = 5;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(90, 146);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 4;
            // 
            // middleBox
            // 
            this.middleBox.Location = new System.Drawing.Point(90, 102);
            this.middleBox.Name = "middleBox";
            this.middleBox.Size = new System.Drawing.Size(29, 20);
            this.middleBox.TabIndex = 2;
            // 
            // lastBox
            // 
            this.lastBox.Location = new System.Drawing.Point(90, 62);
            this.lastBox.Name = "lastBox";
            this.lastBox.Size = new System.Drawing.Size(100, 20);
            this.lastBox.TabIndex = 1;
            // 
            // firstBox
            // 
            this.firstBox.Location = new System.Drawing.Point(90, 25);
            this.firstBox.Name = "firstBox";
            this.firstBox.Size = new System.Drawing.Size(100, 20);
            this.firstBox.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Verify";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Password";
            // 
            // exchangeCheck
            // 
            this.exchangeCheck.AutoSize = true;
            this.exchangeCheck.Location = new System.Drawing.Point(18, 223);
            this.exchangeCheck.Name = "exchangeCheck";
            this.exchangeCheck.Size = new System.Drawing.Size(95, 17);
            this.exchangeCheck.TabIndex = 56;
            this.exchangeCheck.Text = "Create mailbox";
            this.exchangeCheck.UseVisualStyleBackColor = true;
            this.exchangeCheck.CheckedChanged += new System.EventHandler(this.exchangeCheck_CheckedChanged);
            // 
            // exchangeDropDown
            // 
            this.exchangeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exchangeDropDown.Enabled = false;
            this.exchangeDropDown.FormattingEnabled = true;
            this.exchangeDropDown.Location = new System.Drawing.Point(119, 221);
            this.exchangeDropDown.Name = "exchangeDropDown";
            this.exchangeDropDown.Size = new System.Drawing.Size(135, 21);
            this.exchangeDropDown.TabIndex = 57;
            // 
            // CopyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "CopyUser";
            this.Text = "User Details";
            this.Load += new System.EventHandler(this.CopyUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox lastBox;
        private System.Windows.Forms.TextBox firstBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox defaultPassCheck;
        private System.Windows.Forms.TextBox passwordVerifyBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox middleBox;
        private System.Windows.Forms.ComboBox exchangeDropDown;
        private System.Windows.Forms.CheckBox exchangeCheck;
    }
}