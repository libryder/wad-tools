namespace ActiveDirectoryTools.Forms
{
    partial class TermUser
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
            this.termDescText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.termUserWorker = new System.ComponentModel.BackgroundWorker();
            this.userBusyGraphic = new System.Windows.Forms.PictureBox();
            this.descriptionUpdateBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.userBusyGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // termDescText
            // 
            this.termDescText.Location = new System.Drawing.Point(15, 35);
            this.termDescText.Name = "termDescText";
            this.termDescText.Size = new System.Drawing.Size(310, 20);
            this.termDescText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter description:";
            // 
            // resultTextBox
            // 
            this.resultTextBox.DetectUrls = false;
            this.resultTextBox.Location = new System.Drawing.Point(15, 102);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(388, 141);
            this.resultTextBox.TabIndex = 2;
            this.resultTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result:";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(354, 249);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(49, 23);
            this.goButton.TabIndex = 4;
            this.goButton.Text = "Go!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // termUserWorker
            // 
            this.termUserWorker.WorkerReportsProgress = true;
            this.termUserWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.termUserWorker_DoWork);
            this.termUserWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.termUserWorker_ProgressChanged);
            // 
            // userBusyGraphic
            // 
            this.userBusyGraphic.Image = global::ActiveDirectoryTools.Properties.Resources._17_11;
            this.userBusyGraphic.Location = new System.Drawing.Point(354, 35);
            this.userBusyGraphic.Name = "userBusyGraphic";
            this.userBusyGraphic.Size = new System.Drawing.Size(15, 15);
            this.userBusyGraphic.TabIndex = 16;
            this.userBusyGraphic.TabStop = false;
            this.userBusyGraphic.Visible = false;
            // 
            // descriptionUpdateBox
            // 
            this.descriptionUpdateBox.AutoSize = true;
            this.descriptionUpdateBox.Location = new System.Drawing.Point(21, 61);
            this.descriptionUpdateBox.Name = "descriptionUpdateBox";
            this.descriptionUpdateBox.Size = new System.Drawing.Size(148, 17);
            this.descriptionUpdateBox.TabIndex = 17;
            this.descriptionUpdateBox.Text = "Do not update description";
            this.descriptionUpdateBox.UseVisualStyleBackColor = true;
            this.descriptionUpdateBox.CheckedChanged += new System.EventHandler(this.descriptionUpdateBox_CheckedChanged);
            // 
            // TermUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 283);
            this.Controls.Add(this.descriptionUpdateBox);
            this.Controls.Add(this.userBusyGraphic);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.termDescText);
            this.Name = "TermUser";
            this.Text = "Term Users";
            ((System.ComponentModel.ISupportInitialize)(this.userBusyGraphic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox termDescText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox resultTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button goButton;
        private System.ComponentModel.BackgroundWorker termUserWorker;
        private System.Windows.Forms.PictureBox userBusyGraphic;
        private System.Windows.Forms.CheckBox descriptionUpdateBox;
    }
}