using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Security.Permissions;
using System.IO;
using System.Management;


namespace ActiveDirectoryTools.Forms
{
    public partial class RunCleanup : Form
    {
        public string Computer;
        public string DirectoryToDelete = "";
        public bool RequestCancel = false;
        public bool Connected = false;

        public RunCleanup(string computer)
        {
            Computer = computer;
            InitializeComponent();
            cleanupComputerName.Text = computer;
        }

        private void cleanupStartButton_Click(object sender, EventArgs e)
        {
            cleanupStartButton.Enabled = false;
            cleanupOutputTextBox.AppendText("Attempting to connect. . .\n\n");
            cleanupOutputTextBox.ScrollToCaret();
            attemptConnectBackground.RunWorkerAsync();

            Application.DoEvents();

        }

        public void DeleteFiles(string computer, string dir, string subDir)
        {
            decimal beforeDiskSize = DirectoryReport.getFreeDiskSpace(computer);
            string baseDir = @"\\" + computer + @"\c$" + dir;
            
            FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.Write, baseDir);

            string[] tmpDir = Directory.GetDirectories(baseDir);
            int totalDirectories = tmpDir.Count();
            cleanupProgressBar.Maximum = totalDirectories;

            string currentUser = Environment.UserName;
            string combinedPath;
            string eachUser;

            cleanupOutputTextBox.AppendText("Initializing. . .\n");
            foreach (string fileName in tmpDir)
            {
                cleanupProgressBar.Increment(1);
                eachUser = fileName.Substring(fileName.LastIndexOf("\\"),fileName.Length - fileName.LastIndexOf("\\"));
                if (!RequestCancel && !eachUser.Equals("\\Administrator") && !eachUser.Equals(@"\All Users") && !eachUser.Equals("\\Default User") && !eachUser.Equals("\\" + currentUser))
                {

                        combinedPath = fileName + subDir + @"\";
                        if (Directory.Exists(combinedPath))
                        {
                            cleanupOutputTextBox.ScrollToCaret();
                            cleanupOutputTextBox.AppendText("Deleting: " + computer + @"\c$" + eachUser + "\\Local Settings. . . \n");
                            DirectoryToDelete = combinedPath;
                            deleteDirectory.RunWorkerAsync();

                            while (deleteDirectory.IsBusy)
                            {
                                Application.DoEvents();
                            }
                        }
                }

            }
            decimal afterDiskSize = DirectoryReport.getFreeDiskSpace(computer);
            decimal totalFreedSpace = afterDiskSize - beforeDiskSize;
            string sFreedSpace = DirectoryReport.convertDecToSize(totalFreedSpace);
            cleanupOutputTextBox.AppendText("\nCleanup Complete\nDiskspace before: " + DirectoryReport.convertDecToSize(beforeDiskSize) +
                "\nDiskspace after: " + DirectoryReport.convertDecToSize(afterDiskSize) + "\n\nTotal space freed: " + sFreedSpace);
            cleanupOutputTextBox.ScrollToCaret();
        }

        private void deleteDirectory_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Directory.Delete(DirectoryToDelete, true);
            }
            catch { }
        }

        private void cleanupCancelButton_Click(object sender, EventArgs e)
        {
            cleanupCancelButton.Enabled = false;
            RequestCancel = true;
            if (deleteDirectory.IsBusy)
            {
                deleteDirectory.CancelAsync();
                cleanupOutputTextBox.AppendText("Canceling. . . please allow current directory to finish deletion.");
                cleanupOutputTextBox.ScrollToCaret();
            }
            else
            {
                this.Close();
            }
        }

        private void deleteDirectory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (RequestCancel)
            {
                this.Close();
            }
            else
            {
                cleanupStartButton.Enabled = true;
            }
        }

        private void attemptConnectBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ManagementScope scope = new ManagementScope(@"\\" + Computer);
                scope.Connect();
                Connected = true;
                DialogResult t = MessageBox.Show("There is currently " + DirectoryReport.convertDecToSize(DirectoryReport.getFreeDiskSpace(Computer)) + " free space\non machine. Press OK to continue", "Confirm cleanup", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (t == DialogResult.OK)
                {
                    DeleteFiles(Computer, @"\Documents and Settings\", @"\Local Settings");
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception e2)
            {
                Connected = false;
                MessageBox.Show("Error: " + e2.ToString());
            }
        }

        private void attemptConnectBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Connected)
            {
                cleanupOutputTextBox.ScrollToCaret();
                cleanupOutputTextBox.AppendText("Connect failed! Is the computer on?\n\n");
                cleanupStartButton.Enabled = true;
            }
            attemptConnectBackground.Dispose();
        }

        private void deleteDirectory_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
 
        }

    }
}
