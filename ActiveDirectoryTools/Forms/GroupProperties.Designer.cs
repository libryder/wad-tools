namespace ActiveDirectoryTools
{
    partial class GroupProperties
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userCancelButton = new System.Windows.Forms.Button();
            this.userGroupList = new System.Windows.Forms.ListBox();
            this.userGroupAddButton = new System.Windows.Forms.Button();
            this.userGroupRemButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userGroupRemButton);
            this.groupBox1.Controls.Add(this.userGroupAddButton);
            this.groupBox1.Controls.Add(this.userGroupList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 284);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Members";
            // 
            // userCancelButton
            // 
            this.userCancelButton.Location = new System.Drawing.Point(115, 302);
            this.userCancelButton.Name = "userCancelButton";
            this.userCancelButton.Size = new System.Drawing.Size(75, 23);
            this.userCancelButton.TabIndex = 35;
            this.userCancelButton.Text = "Close";
            this.userCancelButton.UseVisualStyleBackColor = true;
            this.userCancelButton.Click += new System.EventHandler(this.userCancelButton_Click);
            // 
            // userGroupList
            // 
            this.userGroupList.FormattingEnabled = true;
            this.userGroupList.Location = new System.Drawing.Point(6, 19);
            this.userGroupList.Name = "userGroupList";
            this.userGroupList.Size = new System.Drawing.Size(172, 225);
            this.userGroupList.TabIndex = 0;
            // 
            // userGroupAddButton
            // 
            this.userGroupAddButton.Location = new System.Drawing.Point(64, 250);
            this.userGroupAddButton.Name = "userGroupAddButton";
            this.userGroupAddButton.Size = new System.Drawing.Size(51, 23);
            this.userGroupAddButton.TabIndex = 1;
            this.userGroupAddButton.Text = "Add";
            this.userGroupAddButton.UseVisualStyleBackColor = true;
            this.userGroupAddButton.Click += new System.EventHandler(this.userGroupAddButton_Click);
            // 
            // userGroupRemButton
            // 
            this.userGroupRemButton.Location = new System.Drawing.Point(121, 250);
            this.userGroupRemButton.Name = "userGroupRemButton";
            this.userGroupRemButton.Size = new System.Drawing.Size(57, 23);
            this.userGroupRemButton.TabIndex = 2;
            this.userGroupRemButton.Text = "Remove";
            this.userGroupRemButton.UseVisualStyleBackColor = true;
            this.userGroupRemButton.Click += new System.EventHandler(this.userGroupRemButton_Click);
            // 
            // GroupProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 337);
            this.Controls.Add(this.userCancelButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "GroupProperties";
            this.RightToLeftLayout = true;
            this.Text = "Group Properties";
            this.Load += new System.EventHandler(this.GroupProperties_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button userCancelButton;
        private System.Windows.Forms.ListBox userGroupList;
        private System.Windows.Forms.Button userGroupRemButton;
        private System.Windows.Forms.Button userGroupAddButton;
    }
}