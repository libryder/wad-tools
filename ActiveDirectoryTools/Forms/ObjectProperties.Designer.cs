namespace ActiveDirectoryTools
{
    partial class ObjectProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectProperties));
            this.userBasicInfoGroup = new System.Windows.Forms.GroupBox();
            this.userStatusLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userDisplayNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userUserNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userFolderCombo = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.userDescriptionBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.userMiddleInitBox = new System.Windows.Forms.TextBox();
            this.userLastNameBox = new System.Windows.Forms.TextBox();
            this.userFirstNameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userCancelButton = new System.Windows.Forms.Button();
            this.userSaveButton = new System.Windows.Forms.Button();
            this.loadUserPropertiesThread = new System.ComponentModel.BackgroundWorker();
            this.userTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userGroupList = new System.Windows.Forms.ListBox();
            this.userGroupRemButton = new System.Windows.Forms.Button();
            this.userGroupAddButton = new System.Windows.Forms.Button();
            this.userBasicInfoGroup.SuspendLayout();
            this.userTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userBasicInfoGroup
            // 
            this.userBasicInfoGroup.Controls.Add(this.userStatusLabel);
            this.userBasicInfoGroup.Controls.Add(this.label4);
            this.userBasicInfoGroup.Controls.Add(this.userDisplayNameBox);
            this.userBasicInfoGroup.Controls.Add(this.label3);
            this.userBasicInfoGroup.Controls.Add(this.userUserNameBox);
            this.userBasicInfoGroup.Controls.Add(this.label1);
            this.userBasicInfoGroup.Controls.Add(this.userFolderCombo);
            this.userBasicInfoGroup.Controls.Add(this.label21);
            this.userBasicInfoGroup.Controls.Add(this.userDescriptionBox);
            this.userBasicInfoGroup.Controls.Add(this.label20);
            this.userBasicInfoGroup.Controls.Add(this.label8);
            this.userBasicInfoGroup.Controls.Add(this.userMiddleInitBox);
            this.userBasicInfoGroup.Controls.Add(this.userLastNameBox);
            this.userBasicInfoGroup.Controls.Add(this.userFirstNameBox);
            this.userBasicInfoGroup.Controls.Add(this.label7);
            this.userBasicInfoGroup.Controls.Add(this.label2);
            this.userBasicInfoGroup.Location = new System.Drawing.Point(3, 6);
            this.userBasicInfoGroup.Name = "userBasicInfoGroup";
            this.userBasicInfoGroup.Size = new System.Drawing.Size(345, 305);
            this.userBasicInfoGroup.TabIndex = 5;
            this.userBasicInfoGroup.TabStop = false;
            this.userBasicInfoGroup.Text = "Basic Info";
            // 
            // userStatusLabel
            // 
            this.userStatusLabel.AutoSize = true;
            this.userStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userStatusLabel.Location = new System.Drawing.Point(56, 276);
            this.userStatusLabel.Name = "userStatusLabel";
            this.userStatusLabel.Size = new System.Drawing.Size(72, 13);
            this.userStatusLabel.TabIndex = 39;
            this.userStatusLabel.Text = "[ENABLED]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Status:";
            // 
            // userDisplayNameBox
            // 
            this.userDisplayNameBox.Location = new System.Drawing.Point(88, 99);
            this.userDisplayNameBox.Name = "userDisplayNameBox";
            this.userDisplayNameBox.Size = new System.Drawing.Size(121, 20);
            this.userDisplayNameBox.TabIndex = 37;
            this.userDisplayNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userDisplayNameBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Display Name:";
            // 
            // userUserNameBox
            // 
            this.userUserNameBox.Location = new System.Drawing.Point(88, 175);
            this.userUserNameBox.Name = "userUserNameBox";
            this.userUserNameBox.Size = new System.Drawing.Size(121, 20);
            this.userUserNameBox.TabIndex = 32;
            this.userUserNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userUserNameBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Username:";
            // 
            // userFolderCombo
            // 
            this.userFolderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userFolderCombo.FormattingEnabled = true;
            this.userFolderCombo.Location = new System.Drawing.Point(88, 134);
            this.userFolderCombo.Name = "userFolderCombo";
            this.userFolderCombo.Size = new System.Drawing.Size(165, 21);
            this.userFolderCombo.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 137);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 13);
            this.label21.TabIndex = 30;
            this.label21.Text = "OU:";
            // 
            // userDescriptionBox
            // 
            this.userDescriptionBox.Location = new System.Drawing.Point(88, 215);
            this.userDescriptionBox.Name = "userDescriptionBox";
            this.userDescriptionBox.Size = new System.Drawing.Size(224, 20);
            this.userDescriptionBox.TabIndex = 12;
            this.userDescriptionBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userDescriptionBox_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 218);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 13);
            this.label20.TabIndex = 30;
            this.label20.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Middle Initial:";
            // 
            // userMiddleInitBox
            // 
            this.userMiddleInitBox.Location = new System.Drawing.Point(294, 27);
            this.userMiddleInitBox.Name = "userMiddleInitBox";
            this.userMiddleInitBox.Size = new System.Drawing.Size(28, 20);
            this.userMiddleInitBox.TabIndex = 6;
            this.userMiddleInitBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userMiddleInitBox_KeyDown);
            // 
            // userLastNameBox
            // 
            this.userLastNameBox.Location = new System.Drawing.Point(88, 65);
            this.userLastNameBox.Name = "userLastNameBox";
            this.userLastNameBox.Size = new System.Drawing.Size(121, 20);
            this.userLastNameBox.TabIndex = 5;
            this.userLastNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userLastNameBox_KeyDown);
            // 
            // userFirstNameBox
            // 
            this.userFirstNameBox.Location = new System.Drawing.Point(88, 27);
            this.userFirstNameBox.Name = "userFirstNameBox";
            this.userFirstNameBox.Size = new System.Drawing.Size(121, 20);
            this.userFirstNameBox.TabIndex = 4;
            this.userFirstNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userFirstNameBox_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Last:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "First:";
            // 
            // userCancelButton
            // 
            this.userCancelButton.Location = new System.Drawing.Point(226, 365);
            this.userCancelButton.Name = "userCancelButton";
            this.userCancelButton.Size = new System.Drawing.Size(75, 23);
            this.userCancelButton.TabIndex = 33;
            this.userCancelButton.Text = "Close";
            this.userCancelButton.UseVisualStyleBackColor = true;
            this.userCancelButton.Click += new System.EventHandler(this.userCancelButton_Click);
            // 
            // userSaveButton
            // 
            this.userSaveButton.Enabled = false;
            this.userSaveButton.Location = new System.Drawing.Point(307, 365);
            this.userSaveButton.Name = "userSaveButton";
            this.userSaveButton.Size = new System.Drawing.Size(75, 23);
            this.userSaveButton.TabIndex = 31;
            this.userSaveButton.Text = "Apply";
            this.userSaveButton.UseVisualStyleBackColor = true;
            this.userSaveButton.Click += new System.EventHandler(this.userSaveButton_Click);
            // 
            // loadUserPropertiesThread
            // 
            this.loadUserPropertiesThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadUserPropertiesThread_DoWork);
            this.loadUserPropertiesThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.loadUserPropertiesThread_RunWorkerCompleted);
            // 
            // userTab
            // 
            this.userTab.Controls.Add(this.tabPage1);
            this.userTab.Controls.Add(this.tabPage3);
            this.userTab.Location = new System.Drawing.Point(13, 12);
            this.userTab.Name = "userTab";
            this.userTab.SelectedIndex = 0;
            this.userTab.Size = new System.Drawing.Size(374, 347);
            this.userTab.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.userBasicInfoGroup);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(366, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(366, 321);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Groups";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userGroupList);
            this.groupBox1.Controls.Add(this.userGroupRemButton);
            this.groupBox1.Controls.Add(this.userGroupAddButton);
            this.groupBox1.Location = new System.Drawing.Point(47, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 284);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Member Of";
            // 
            // userGroupList
            // 
            this.userGroupList.FormattingEnabled = true;
            this.userGroupList.Location = new System.Drawing.Point(6, 19);
            this.userGroupList.Name = "userGroupList";
            this.userGroupList.Size = new System.Drawing.Size(256, 225);
            this.userGroupList.TabIndex = 2;
            // 
            // userGroupRemButton
            // 
            this.userGroupRemButton.Location = new System.Drawing.Point(141, 250);
            this.userGroupRemButton.Name = "userGroupRemButton";
            this.userGroupRemButton.Size = new System.Drawing.Size(60, 23);
            this.userGroupRemButton.TabIndex = 1;
            this.userGroupRemButton.Text = "Remove";
            this.userGroupRemButton.UseVisualStyleBackColor = true;
            this.userGroupRemButton.Click += new System.EventHandler(this.userGroupRemButton_Click);
            // 
            // userGroupAddButton
            // 
            this.userGroupAddButton.Location = new System.Drawing.Point(73, 250);
            this.userGroupAddButton.Name = "userGroupAddButton";
            this.userGroupAddButton.Size = new System.Drawing.Size(62, 23);
            this.userGroupAddButton.TabIndex = 0;
            this.userGroupAddButton.Text = "Add";
            this.userGroupAddButton.UseVisualStyleBackColor = true;
            this.userGroupAddButton.Click += new System.EventHandler(this.userGroupAddButton_Click);
            // 
            // ObjectProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 402);
            this.Controls.Add(this.userTab);
            this.Controls.Add(this.userCancelButton);
            this.Controls.Add(this.userSaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ObjectProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Properties";
            this.Load += new System.EventHandler(this.ObjectProperties_Load);
            this.userBasicInfoGroup.ResumeLayout(false);
            this.userBasicInfoGroup.PerformLayout();
            this.userTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox userBasicInfoGroup;
        private System.Windows.Forms.ComboBox userFolderCombo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox userDescriptionBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox userMiddleInitBox;
        private System.Windows.Forms.TextBox userLastNameBox;
        private System.Windows.Forms.TextBox userFirstNameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button userSaveButton;
        private System.Windows.Forms.Button userCancelButton;
        private System.Windows.Forms.TextBox userUserNameBox;
        private System.ComponentModel.BackgroundWorker loadUserPropertiesThread;
        private System.Windows.Forms.TextBox userDisplayNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label userStatusLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl userTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button userGroupRemButton;
        private System.Windows.Forms.Button userGroupAddButton;
        private System.Windows.Forms.ListBox userGroupList;

    }
}