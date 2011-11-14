namespace ActiveDirectoryTools.Forms
{
    partial class FindRep
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
            this.processButton = new System.Windows.Forms.Button();
            this.resultsCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.namesLabel = new System.Windows.Forms.Label();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.searchRegionalCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(189, 364);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(106, 23);
            this.processButton.TabIndex = 5;
            this.processButton.Text = "Copy To Clipboard";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // resultsCheckListBox
            // 
            this.resultsCheckListBox.FormattingEnabled = true;
            this.resultsCheckListBox.Location = new System.Drawing.Point(6, 24);
            this.resultsCheckListBox.Name = "resultsCheckListBox";
            this.resultsCheckListBox.Size = new System.Drawing.Size(271, 139);
            this.resultsCheckListBox.TabIndex = 3;
            this.resultsCheckListBox.SelectedValueChanged += new System.EventHandler(this.resultsCheckListBox_SelectedValueChanged);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(153, 142);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(59, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(218, 142);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(59, 23);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(6, 19);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(141, 146);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchRegionalCheck);
            this.groupBox1.Controls.Add(this.resultsLabel);
            this.groupBox1.Controls.Add(this.namesLabel);
            this.groupBox1.Controls.Add(this.searchTextBox);
            this.groupBox1.Controls.Add(this.clearButton);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 171);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter names to find";
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(197, 35);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(54, 13);
            this.resultsLabel.TabIndex = 4;
            this.resultsLabel.Text = "Results: 0";
            // 
            // namesLabel
            // 
            this.namesLabel.AutoSize = true;
            this.namesLabel.Location = new System.Drawing.Point(199, 22);
            this.namesLabel.Name = "namesLabel";
            this.namesLabel.Size = new System.Drawing.Size(52, 13);
            this.namesLabel.TabIndex = 3;
            this.namesLabel.Text = "Names: 0";
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(18, 364);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllButton.TabIndex = 4;
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.resultsCheckListBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 169);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Results";
            // 
            // searchRegionalCheck
            // 
            this.searchRegionalCheck.AutoSize = true;
            this.searchRegionalCheck.Location = new System.Drawing.Point(154, 111);
            this.searchRegionalCheck.Name = "searchRegionalCheck";
            this.searchRegionalCheck.Size = new System.Drawing.Size(118, 17);
            this.searchRegionalCheck.TabIndex = 5;
            this.searchRegionalCheck.Text = "Search by manager";
            this.searchRegionalCheck.UseVisualStyleBackColor = true;
            // 
            // FindRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 397);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.processButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FindRep";
            this.Text = "Rep/tech Login Info";
            this.Load += new System.EventHandler(this.FindRep_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.CheckedListBox resultsCheckListBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.RichTextBox searchTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.Label namesLabel;
        private System.Windows.Forms.CheckBox searchRegionalCheck;
    }
}