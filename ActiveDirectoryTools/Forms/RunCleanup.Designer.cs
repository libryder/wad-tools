namespace ActiveDirectoryTools.Forms
{
    partial class RunCleanup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunCleanup));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cleanupStartButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cleanupComputerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cleanupOutputTextBox = new System.Windows.Forms.RichTextBox();
            this.cleanupCancelButton = new System.Windows.Forms.Button();
            this.attemptConnectBackground = new System.ComponentModel.BackgroundWorker();
            this.deleteDirectory = new System.ComponentModel.BackgroundWorker();
            this.cleanupProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cleanupStartButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cleanupComputerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cleanupOutputTextBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remote Disk Cleanup";
            // 
            // cleanupStartButton
            // 
            this.cleanupStartButton.Location = new System.Drawing.Point(222, 25);
            this.cleanupStartButton.Name = "cleanupStartButton";
            this.cleanupStartButton.Size = new System.Drawing.Size(64, 23);
            this.cleanupStartButton.TabIndex = 4;
            this.cleanupStartButton.Text = "Start";
            this.cleanupStartButton.UseVisualStyleBackColor = true;
            this.cleanupStartButton.Click += new System.EventHandler(this.cleanupStartButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output:";
            // 
            // cleanupComputerName
            // 
            this.cleanupComputerName.Enabled = false;
            this.cleanupComputerName.Location = new System.Drawing.Point(79, 27);
            this.cleanupComputerName.Name = "cleanupComputerName";
            this.cleanupComputerName.Size = new System.Drawing.Size(126, 20);
            this.cleanupComputerName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Running on:";
            // 
            // cleanupOutputTextBox
            // 
            this.cleanupOutputTextBox.DetectUrls = false;
            this.cleanupOutputTextBox.Location = new System.Drawing.Point(6, 78);
            this.cleanupOutputTextBox.Name = "cleanupOutputTextBox";
            this.cleanupOutputTextBox.ReadOnly = true;
            this.cleanupOutputTextBox.Size = new System.Drawing.Size(383, 141);
            this.cleanupOutputTextBox.TabIndex = 0;
            this.cleanupOutputTextBox.Text = "";
            // 
            // cleanupCancelButton
            // 
            this.cleanupCancelButton.Location = new System.Drawing.Point(331, 247);
            this.cleanupCancelButton.Name = "cleanupCancelButton";
            this.cleanupCancelButton.Size = new System.Drawing.Size(75, 23);
            this.cleanupCancelButton.TabIndex = 1;
            this.cleanupCancelButton.Text = "Cancel";
            this.cleanupCancelButton.UseVisualStyleBackColor = true;
            this.cleanupCancelButton.Click += new System.EventHandler(this.cleanupCancelButton_Click);
            // 
            // attemptConnectBackground
            // 
            this.attemptConnectBackground.DoWork += new System.ComponentModel.DoWorkEventHandler(this.attemptConnectBackground_DoWork);
            this.attemptConnectBackground.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.attemptConnectBackground_RunWorkerCompleted);
            // 
            // deleteDirectory
            // 
            this.deleteDirectory.WorkerReportsProgress = true;
            this.deleteDirectory.WorkerSupportsCancellation = true;
            this.deleteDirectory.DoWork += new System.ComponentModel.DoWorkEventHandler(this.deleteDirectory_DoWork);
            this.deleteDirectory.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.deleteDirectory_RunWorkerCompleted);
            this.deleteDirectory.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.deleteDirectory_ProgressChanged);
            // 
            // cleanupProgressBar
            // 
            this.cleanupProgressBar.Location = new System.Drawing.Point(73, 254);
            this.cleanupProgressBar.Name = "cleanupProgressBar";
            this.cleanupProgressBar.Size = new System.Drawing.Size(167, 11);
            this.cleanupProgressBar.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Progress:";
            // 
            // RunCleanup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 284);
            this.Controls.Add(this.cleanupProgressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cleanupCancelButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RunCleanup";
            this.Text = "Cleanup Progress";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox cleanupOutputTextBox;
        private System.Windows.Forms.TextBox cleanupComputerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cleanupStartButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cleanupCancelButton;
        private System.ComponentModel.BackgroundWorker attemptConnectBackground;
        private System.ComponentModel.BackgroundWorker deleteDirectory;
        private System.Windows.Forms.ProgressBar cleanupProgressBar;
        private System.Windows.Forms.Label label3;
    }
}