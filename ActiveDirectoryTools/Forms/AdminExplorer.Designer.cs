namespace ActiveDirectoryTools
{
    partial class ElevateExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElevateExplorer));
            this.adminLoginBox = new System.Windows.Forms.GroupBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.adminPassLabel = new System.Windows.Forms.Label();
            this.adminUserLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.adminLoginBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminLoginBox
            // 
            this.adminLoginBox.Controls.Add(this.loginButton);
            this.adminLoginBox.Controls.Add(this.passTextBox);
            this.adminLoginBox.Controls.Add(this.userTextBox);
            this.adminLoginBox.Controls.Add(this.adminPassLabel);
            this.adminLoginBox.Controls.Add(this.adminUserLabel);
            this.adminLoginBox.Location = new System.Drawing.Point(12, 12);
            this.adminLoginBox.Name = "adminLoginBox";
            this.adminLoginBox.Size = new System.Drawing.Size(260, 147);
            this.adminLoginBox.TabIndex = 0;
            this.adminLoginBox.TabStop = false;
            this.adminLoginBox.Text = "Enter admin credentials";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(156, 111);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(86, 75);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(145, 20);
            this.passTextBox.TabIndex = 3;
            this.passTextBox.TextChanged += new System.EventHandler(this.passTextBox_TextChanged);
            this.passTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passTextBox_KeyDown);
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(86, 34);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(145, 20);
            this.userTextBox.TabIndex = 2;
            this.userTextBox.TextChanged += new System.EventHandler(this.userTextBox_TextChanged);
            // 
            // adminPassLabel
            // 
            this.adminPassLabel.AutoSize = true;
            this.adminPassLabel.Location = new System.Drawing.Point(25, 78);
            this.adminPassLabel.Name = "adminPassLabel";
            this.adminPassLabel.Size = new System.Drawing.Size(56, 13);
            this.adminPassLabel.TabIndex = 1;
            this.adminPassLabel.Text = "Password:";
            // 
            // adminUserLabel
            // 
            this.adminUserLabel.AutoSize = true;
            this.adminUserLabel.Location = new System.Drawing.Point(22, 37);
            this.adminUserLabel.Name = "adminUserLabel";
            this.adminUserLabel.Size = new System.Drawing.Size(58, 13);
            this.adminUserLabel.TabIndex = 0;
            this.adminUserLabel.Text = "Username:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(197, 165);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ElevateExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(284, 200);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.adminLoginBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ElevateExplorer";
            this.Text = "Open explorer as user";
            this.adminLoginBox.ResumeLayout(false);
            this.adminLoginBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox adminLoginBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Label adminPassLabel;
        private System.Windows.Forms.Label adminUserLabel;
        private System.Windows.Forms.Button cancelButton;
    }
}