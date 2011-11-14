namespace ActiveDirectoryTools.Forms
{
    partial class SelectGroup
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
            this.groupListBox = new System.Windows.Forms.ListBox();
            this.groupOkButton = new System.Windows.Forms.Button();
            this.groupCancelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupSearchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupListBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 161);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Group:";
            // 
            // groupListBox
            // 
            this.groupListBox.FormattingEnabled = true;
            this.groupListBox.Location = new System.Drawing.Point(7, 19);
            this.groupListBox.Name = "groupListBox";
            this.groupListBox.Size = new System.Drawing.Size(209, 134);
            this.groupListBox.TabIndex = 4;
            this.groupListBox.SelectedIndexChanged += new System.EventHandler(this.groupListBox_SelectedIndexChanged);
            this.groupListBox.DoubleClick += new System.EventHandler(this.groupListBox_DoubleClick);
            // 
            // groupOkButton
            // 
            this.groupOkButton.Enabled = false;
            this.groupOkButton.Location = new System.Drawing.Point(172, 255);
            this.groupOkButton.Name = "groupOkButton";
            this.groupOkButton.Size = new System.Drawing.Size(56, 23);
            this.groupOkButton.TabIndex = 5;
            this.groupOkButton.Text = "Ok";
            this.groupOkButton.UseVisualStyleBackColor = true;
            this.groupOkButton.Click += new System.EventHandler(this.groupOkButton_Click);
            // 
            // groupCancelButton
            // 
            this.groupCancelButton.Location = new System.Drawing.Point(102, 255);
            this.groupCancelButton.Name = "groupCancelButton";
            this.groupCancelButton.Size = new System.Drawing.Size(64, 23);
            this.groupCancelButton.TabIndex = 6;
            this.groupCancelButton.Text = "Cancel";
            this.groupCancelButton.UseVisualStyleBackColor = true;
            this.groupCancelButton.Click += new System.EventHandler(this.groupCancelButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.searchButton);
            this.groupBox2.Controls.Add(this.groupSearchBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 70);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enter partial group name";
            // 
            // groupSearchBox
            // 
            this.groupSearchBox.Location = new System.Drawing.Point(7, 30);
            this.groupSearchBox.Name = "groupSearchBox";
            this.groupSearchBox.Size = new System.Drawing.Size(144, 20);
            this.groupSearchBox.TabIndex = 0;
            this.groupSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.groupSearchBox_KeyDown);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(157, 28);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(53, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Find";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // SelectGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 290);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupCancelButton);
            this.Controls.Add(this.groupOkButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "SelectGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Group";
            this.Load += new System.EventHandler(this.SelectGroup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox groupListBox;
        private System.Windows.Forms.Button groupOkButton;
        private System.Windows.Forms.Button groupCancelButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox groupSearchBox;
    }
}