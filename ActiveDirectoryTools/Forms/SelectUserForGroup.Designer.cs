namespace ActiveDirectoryTools
{
    partial class SelectUserForGroup
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
            this.findUserText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.findUserButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.userResultBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backgroundUserSearch = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // findUserText
            // 
            this.findUserText.Location = new System.Drawing.Point(6, 32);
            this.findUserText.Name = "findUserText";
            this.findUserText.Size = new System.Drawing.Size(124, 20);
            this.findUserText.TabIndex = 0;
            this.findUserText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.findUserText_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.findUserButton);
            this.groupBox1.Controls.Add(this.findUserText);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 70);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find User";
            // 
            // findUserButton
            // 
            this.findUserButton.Location = new System.Drawing.Point(136, 30);
            this.findUserButton.Name = "findUserButton";
            this.findUserButton.Size = new System.Drawing.Size(65, 23);
            this.findUserButton.TabIndex = 1;
            this.findUserButton.Text = "Find";
            this.findUserButton.UseVisualStyleBackColor = true;
            this.findUserButton.Click += new System.EventHandler(this.findUserButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(138, 253);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Cancel";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // userResultBox
            // 
            this.userResultBox.FormattingEnabled = true;
            this.userResultBox.Location = new System.Drawing.Point(10, 19);
            this.userResultBox.Name = "userResultBox";
            this.userResultBox.Size = new System.Drawing.Size(191, 134);
            this.userResultBox.TabIndex = 3;
            this.userResultBox.DoubleClick += new System.EventHandler(this.userResultBox_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userResultBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 159);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select User";
            // 
            // backgroundUserSearch
            // 
            this.backgroundUserSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundUserSearch_DoWork);
            this.backgroundUserSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundUserSearch_RunWorkerCompleted);
            // 
            // SelectUserForGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 288);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SelectUserForGroup";
            this.Text = "Add User";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox findUserText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button findUserButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ListBox userResultBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundUserSearch;
    }
}