using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveDirectoryTools.Classes;
using System.DirectoryServices;
using System.Threading;
using System.IO;

namespace ActiveDirectoryTools.Forms
{
    public partial class TermUser : Form
    {
        public static ListView.SelectedListViewItemCollection ListViewList;
        public static Dictionary<string, string> CurrentUsers;
        public static string statusString = string.Empty;

        public TermUser(ListView.SelectedListViewItemCollection sender, Dictionary<string, string> currentUsers)
        {
            InitializeComponent();
            ListViewList = sender;
            CurrentUsers = currentUsers;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            userBusyGraphic.Show();
            goButton.Enabled = false;
            termDescText.Enabled = false;

            foreach (ListViewItem user in ListViewList)
            {
                string userPath = CurrentUsers[user.Text];

                if (!UserControls.isGroup(CurrentUsers[user.Text]))
                {
                    while (termUserWorker.IsBusy)
                    {
                        Application.DoEvents();
                    }
                    termUserWorker.RunWorkerAsync(user.Text);
                }
            }
            userBusyGraphic.Hide();
        }

        private void termUserWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string user = e.Argument.ToString();
            string userPath = CurrentUsers[user];
            
            statusString = "-----Processing " + user + "-----\n";
            termUserWorker.ReportProgress(5);

            DirectoryEntry termUser = new DirectoryEntry("LDAP://" + userPath);
            string userName = termUser.Properties["samaccountname"].Value.ToString();

            //update description
            if (!descriptionUpdateBox.Checked)
            {
                termUser.Properties["description"].Value = termDescText.Text;
                statusString = "Updating description... Done!\n";
                termUserWorker.ReportProgress(10);
            }
            //remove phone extension
            termUser.Properties["telephoneNumber"].Value = " ";
            statusString = "Removing phone extension from active directory... Done!\n";
            termUserWorker.ReportProgress(20);

            termUser.CommitChanges();


            //move documents folder to _DISABLED directory on ratchet
            string dateMonth = DateTime.Now.Month.ToString();
            if (dateMonth.Length == 1)
            {
                dateMonth = "0" + dateMonth;
            }
            string dateString = dateMonth + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString();
            string srcPath = DirectoryReport.findUserFolder(userName);
            string trgtPath = @"\\ratchet\users\_DISABLED\" + userName;
            string datedTrgtPath = dateString + " " + trgtPath;

            if (!srcPath.Equals(string.Empty) && !srcPath.Equals(trgtPath))
            {
                Directory.Move(srcPath, trgtPath);
                statusString = "Successfully moved user's document folder!\n";
            }
            else if (srcPath.Equals(trgtPath))
            {
                statusString = "User's document folder has already been moved!\n";
            }
            else
            {
                statusString = "Could not locate user directory on ratchet!\n";
            }
            termUserWorker.ReportProgress(30);
            
            //MessageBox.Show(DirectoryReport.findUserFolder(termUser.Properties["samaccountname"].Value.ToString()));
            
            //hide mailbox
            if (ExchangeMgmt.hideMailbox(userPath, true))
            {
                statusString = "Hiding mailbox from address list... Done!\n";
                termUserWorker.ReportProgress(40);

            }

            //remove group membership
            if (UserControls.removeAllGroups(userPath))
            {
                statusString = "Removing group membership... Done!\n";
                termUserWorker.ReportProgress(60);
            }

            //disable account
            if (UserControls.disableAccount(userPath))
            {
                statusString = "Disabling user account... Done!\n";
                termUserWorker.ReportProgress(80);
            }

            //move user to *Disabled
            DirectoryEntry moveTo = new DirectoryEntry("LDAP://" + Settings.DISABLEDOU);
            termUser.MoveTo(moveTo);
            termUser.CommitChanges();

            moveTo.Close();

            statusString = "Moving user to *Disabled OU... Done!\n";
            termUserWorker.ReportProgress(90);
            
            statusString = "-----Complete-----\n\n";
        }

        private void termUserWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultTextBox.AppendText(statusString);
            resultTextBox.ScrollToCaret();
        }

        private void descriptionUpdateBox_CheckedChanged(object sender, EventArgs e)
        {
            if (descriptionUpdateBox.Checked)
            {
                termDescText.Enabled = false;
            }
            else
            {
                termDescText.Enabled = true;
            }
        }
    }
}
