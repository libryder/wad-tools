using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ComponentModel;
using System.DirectoryServices; //remove this or you suck
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Configuration;
using ActiveDirectoryTools.Classes;
using System.Data;
using System.Drawing;
using System.Management;
using System.Text;

namespace ActiveDirectoryTools
{
    public partial class MainWindow : Form
    {
        public static int TotalItems = 0;
        public static int TotalUsers = 0;
        public static string UserData = null;
        public static string PassData = null;
        public static string SelectedComputer;
        public static string TextInputResult = string.Empty;
        public static Dictionary<string, string> TreeOU = new Dictionary<string, string>();
        public Dictionary<string, string> groupsDict = new Dictionary<string,string>();
        public const string DEPSDIR = @"\\ironhide\public\departments\mis\remote management\dependencies\";
        public static Dictionary<string, string> exchangeDatabases = new Dictionary<string, string>();
        
        public MainWindow()
        {
            InitializeComponent();
            RemoteConnect.Summary.Add("960", 0);
            RemoteConnect.Summary.Add("760", 0);
            RemoteConnect.Summary.Add("755", 0);
            RemoteConnect.Summary.Add("740", 0);
            RemoteConnect.Summary.Add("520", 0);
            RemoteConnect.Summary.Add("other", 0);
            RemoteConnect.Summary.Add("errors", 0);
            lvwColumnSorter = new ListViewColumnSorter();
            resultListColumnSorter = new ListViewColumnSorter();
            resultList.ListViewItemSorter = resultListColumnSorter;
            userGroupChangeList.ListViewItemSorter = lvwColumnSorter;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            exchangeDatabases = ExchangeMgmt.getExchangeDatabases();
            foreach (string exDatabase in exchangeDatabases.Keys)
            {
                enableMailboxToolStripMenuItem.DropDownItems.Add(exDatabase.Remove(0,3));
                ExchangeMgmt.Databases.Add(exDatabase.Remove(0, 3), exchangeDatabases[exDatabase]);
            }

            RemoteConnect.createDataTable();
            getComputers.RunWorkerAsync();
            mapDriveTextBox.SelectedItem = "P:";
            remoteInstallComboBox.SelectedIndex = 0;
            exportTypeCombo.SelectedIndex = 0;

            if (!File.Exists(Environment.SystemDirectory + @"\psexec.exe"))
            {
                if (File.Exists(DEPSDIR + "psexec.exe"))
                {
                    File.Copy(DEPSDIR + "psexec.exe", Environment.SystemDirectory + @"\psexec.exe");
                    MessageBox.Show("Successfully installed PSExec!", "Initial startup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult tmp = MessageBox.Show("Unable to copy PSExec.exe into " + Environment.SystemDirectory + "\nFeatures will be limited. \nWould you like to download and install now?", "PSExec", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == tmp && DirectoryReport.DownloadFile("http://live.sysinternals.com/psexec.exe", Environment.SystemDirectory + @"\psexec.exe"))
                    {
                        MessageBox.Show("Successfully installed PSExec!", "Initial startup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            loadingGraphic.Show();
            if (!backgroundLoadObjects.IsBusy)
            {
                backgroundLoadObjects.RunWorkerAsync("Workstations");
            }

            DirectoryEntry ldapEntry = new DirectoryEntry(Settings.LDAPSTRING);
            TreeNode entireTree = new TreeNode("Apex");
            foreach (DirectoryEntry tmp in ldapEntry.Children)
            {
                TreeNode treeNode = new TreeNode(tmp.Name.Remove(0, 3));
                moveToToolStripMenuItem.DropDownItems.Add(tmp.Name.Remove(0, 3));
                TreeOU.Add(tmp.Name.Remove(0, 3), tmp.Path);
                foreach (DirectoryEntry child in tmp.Children)
                {
                    if (child.Path.Substring(0, 10).Equals("LDAP://OU="))
                    {
                        moveToToolStripMenuItem.DropDownItems.Add(tmp.Name.Remove(0, 3) + "\\" + child.Name.Remove(0, 3));
                        TreeOU.Add(tmp.Name.Remove(0,3) + "\\" + child.Name.Remove(0, 3), child.Path);
                        TreeNode nodeChild = new TreeNode(child.Name.Remove(0, 3));
                        treeNode.Nodes.Add(nodeChild);
                    }
                }
                entireTree.Nodes.Add(treeNode);
            }
            userOuTreeView.Nodes.Add(entireTree);
            userOuTreeView.Nodes[0].Expand();
        }

        private void applicationClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            /*List<string> newList = getObjectList();
            if (exportTypeCombo.Text.Equals("Excel"))
            {
                int i = 1;
                CreateExcelWorksheet excelSheet = new CreateExcelWorksheet();
                //create column headers
                Object[] newRow = new string[] { "Computer Name", "Model", "Memory", "Current User", "Status", "Free Space", "Service Tag" };
                excelSheet.WriteRow(i, newRow);
                i++;

                //add resultList items to excel sheet
                foreach (string arg in newList)
                {
                    newRow = arg.Split('\t');
                    excelSheet.WriteRow(i, newRow);
                    i++;
                }
                //show the application
                excelSheet.AutoFit();
                excelSheet.Commit();
            }
            else
            {
                DirectoryReport.exportToTxtFile(exportFileBox.Text, newList);
            }*/
        }

        private void runCleanupButton_Click(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count >= 1 || ipEnterCheckBox.Checked)
            {
                if (resultList.SelectedItems.Count >= 1)
                {
                    SelectedComputer = resultList.SelectedItems[0].Text;
                }
                if (ipEnterCheckBox.Checked)
                {
                    SelectedComputer = getHostName(ipEnterTextBox.Text);
                }
                Forms.RunCleanup cleanupWindow = new Forms.RunCleanup(SelectedComputer);
                cleanupWindow.Show();
            }
            else
            {
                MessageBox.Show("Computer must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //initiates background worker to fill objectListBox

        private void backgroundLoadObjects_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryReport.getDirectoryReport(e.Argument.ToString(), "null");
        }

        private void backgroundLoadObjects_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TotalItems = 0;

            resultList.Items.Clear();

            groupsDict = UserControls.getAllGroups();
            
            List<string> sortedGroups = new List<string>();
            foreach (KeyValuePair<string, string> tmp in groupsDict)
            {
                sortedGroups.Add(tmp.Key);
            }
            sortedGroups.Sort();
            foreach (string group in sortedGroups)
            {
                userGroupAddGroupCombo.Items.Add(group);
            }
            userGroupAddGroupCombo.SelectedIndex = 0;

            if (DirectoryReport.ObjectList.Count > 0)
            {
                foreach (string objectName in DirectoryReport.ObjectList.Keys)
                {
                    TotalItems++;
                    resultList.Items.Add(new ListViewItem(new string[]{ objectName, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty }) );
                }
            }
            RemoteConnect.cancelRequest = false;
            countProgressLabel.Text = 0 + " of " + TotalItems;
            runButton.Enabled = true;
            probeClearButton.Enabled = true;
            progressBar.Maximum = TotalItems;
            progressBar.Value = 0;
            totalCompText.Text = TotalItems.ToString();
            totalItemsLabel.Text = "Total Items: " + TotalItems;
            loadingGraphic.Hide();
        }

        private void enableRD(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count >= 1 || ipEnterCheckBox.Checked)
            {
                if (resultList.SelectedItems.Count >= 1)
                {
                    SelectedComputer = resultList.SelectedItems[0].Text;
                }
                if (ipEnterCheckBox.Checked)
                {
                    string computerHostName = getHostName(ipEnterTextBox.Text);
                    SelectedComputer = computerHostName.Substring(0,
                        computerHostName.IndexOf("."));
                }
                bool tmp = RegistryControl.changeRemoteDesktop(SelectedComputer, "0");
                if (tmp)
                {
                    MessageBox.Show("Remote desktop on " + SelectedComputer + " has\nbeen successfully enabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Computer must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //enable remote desktop
        private void enableRemoteButton_Click(object sender, EventArgs e)
        {
            enableRD(null, null);
        }

        private void disableRD(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count >= 1 || ipEnterCheckBox.Checked)
            {
                string op = "";
                if (resultList.SelectedItems.Count >= 1)
                {
                    SelectedComputer = @"\\" + resultList.SelectedItems[0].Text;
                }
                if (ipEnterCheckBox.Checked)
                {
                    SelectedComputer = getHostName(ipEnterTextBox.Text);
                    op = @"\\" + SelectedComputer.Substring(0, SelectedComputer.IndexOf("."));
                }
                bool tmp = RegistryControl.changeRemoteDesktop(SelectedComputer, "1");
                if (tmp)
                {
                    MessageBox.Show("Remote desktop on " + SelectedComputer + " has\nbeen successfully disabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Computer must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //disable remote desktop
        private void disableRemoteButton_Click(object sender, EventArgs e)
        {
            disableRD(null, null);
        }


        //function to map network drive on remote machine
        private void mapDriveButton_Click(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count >= 1 || ipEnterCheckBox.Checked)
            {
                if (resultList.SelectedItems.Count >= 1)
                {
                    SelectedComputer = "\\\\" + resultList.SelectedItems[0].Text;
                }
                if (ipEnterCheckBox.Checked)
                {
                    SelectedComputer = "\\\\" + getHostName(ipEnterTextBox.Text);
                }

                DialogResult result = MessageBox.Show("User will have to log off and log back on to see the mapped drive.", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    Process.Start("cmd", "/K psexec " + SelectedComputer + " net use " + mapDriveTextBox.Text.ToString() + " " + mapShareTextBox.Text.ToString() + @" /user:apex\" + Environment.UserName);
                }
            }
            else
            {
                MessageBox.Show("Computer must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
         }

        //this checkbox determines whether you will run the command locally or impersonate
        private void runLocallyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (runLocallyCheckBox.Checked) 
            {
                runAsButton.Enabled = false;
            }
            else 
                runAsButton.Enabled = true;

        }
        //opens authentication dialog
        private void runAsButton_Click(object sender, EventArgs e)
        {
            inputAuthDialog testDialog = new inputAuthDialog();
            testDialog.ShowDialog();
        }

        private void filterApplyButton_Click(object sender, EventArgs e)
        {
            applySearchFilter();
        }

        private void startRdSession(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count >= 1 || ipEnterCheckBox.Checked)
            {
                if (resultList.SelectedItems.Count >= 1 && !ipEnterCheckBox.Checked)
                {
                    SelectedComputer = resultList.SelectedItems[0].Text;
                }
                else if (ipEnterCheckBox.Checked)
                {
                    SelectedComputer = getHostName(ipEnterTextBox.Text);
                }
                if (SelectedComputer.Equals("INVALID"))
                {
                    MessageBox.Show("I was unable to resolve " + ipEnterTextBox.Text + ". Verify address is correct.", "Invalid host", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //verify remote desktop is enabled.
                    if (RegistryControl.checkRdEnabled(SelectedComputer))
                    {
                        Process.Start("mstsc", "/v:" + SelectedComputer);
                    }
                    else
                    {
                        DialogResult enableRd = MessageBox.Show("Remote desktop status on " + SelectedComputer + "\n either cannot be determined or is disabled.\n\nAttempt to enable remote desktop on selected machine?",
                            "Remote desktop status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == enableRd)
                        {
                            bool tmp = RegistryControl.changeRemoteDesktop(SelectedComputer, "0");
                            if (tmp)
                            {
                                MessageBox.Show("Remote desktop on " + SelectedComputer + " has\nbeen successfully enabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Process.Start("mstsc", "/v:" + SelectedComputer);
                            }
                            else
                            {
                                MessageBox.Show("Unable to enable remote desktop on " + SelectedComputer + ".", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("Computer must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void startRDSessionButton_Click(object sender, EventArgs e)
        {
            startRdSession(null, null);
        }


        private void filterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                applySearchFilter();
            }
        }

        private void customCommandRunButton_Click(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count >= 1 || ipEnterCheckBox.Checked)
            {
                if (resultList.SelectedItems.Count >= 1)
                {
                    SelectedComputer = @"\\" + resultList.SelectedItems[0].Text;
                }
                if (ipEnterCheckBox.Checked)
                {
                    SelectedComputer = @"\\" + ipEnterTextBox.Text;
                }
                DialogResult result = MessageBox.Show("Launch command:\n" + customCommandTextBox.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    try
                    {
                        launchCommand(customCommandTextBox.Text, SelectedComputer);
                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("Computer must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            resultList.Items.Clear();
            filterTextBox.Clear();
            this.backgroundLoadObjects.RunWorkerAsync("Workstations");
            Application.DoEvents();
        }

        private void ipEnterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ipEnterCheckBox.Checked)
            {
                resultList.Enabled = false;
                ipEnterTextBox.Enabled = true;
            }
            else
            {
                resultList.Enabled = true;
                ipEnterTextBox.Enabled = false;
            }
        }

        private void resolveIPButton_Click(object sender, EventArgs e)
        {
            string hostname = getHostName(ipEnterTextBox.Text);
            if (hostname.Equals("INVALID"))
            {
                MessageBox.Show("I was unable to resolve " + ipEnterTextBox.Text + ". Verify computer is connected and actually exists.", "Invalid host", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ipEnterTextBox.Text = hostname;
            }

        }

        private void resultListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count >= 1)
            {
                ipEnterTextBox.Text = resultList.SelectedItems[0].Text;
            }
        }

        private void resolveHostButton_Click(object sender, EventArgs e)
        {
            string hostname = getIpAddress(ipEnterTextBox.Text);
            if (hostname.Equals("INVALID"))
            {
                MessageBox.Show("I was unable to resolve " + ipEnterTextBox.Text + ". Verify computer is connected and actually exists.", "Invalid host", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ipEnterTextBox.Text = hostname;
            }
        }

        private void remoteInstallButton_Click(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count >= 1 || ipEnterCheckBox.Checked)
            {
                if (resultList.SelectedItems.Count >= 1)
                {
                    if (DirectoryReport.remoteInstall(resultList.SelectedItems[0].Text,
                        remoteInstallComboBox.Text))
                    {
                        MessageBox.Show("Installation was a success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Computer must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

//ALL METHODS FOR THIS FORM BELOW

        public void launchCommand(string args, string comp)
        {
            Process.Start("cmd", "/k psexec " + comp + " " + args);
        }

        public string getHostName(string ip)
        {
            string result;
            try
            {
                string host;
                IPHostEntry hostIP = Dns.GetHostEntry(ip);
                host = hostIP.HostName;

                result = host;
            }
            catch
            {
                result = "INVALID";
            }
            return result;
        }

        public string getIpAddress(string ip)
        {
            try
            {
                string host;
                IPHostEntry hostIP = Dns.GetHostEntry(ip);
                System.Net.IPAddress[] ipArray = hostIP.AddressList;
                host = ipArray[0].ToString();

                return host;
            }
            catch
            {
                return "INVALID";
            }
        }

        private void registerCompButton_Click(object sender, EventArgs e)
        {
            if (ipEnterTextBox.Text.Length > 1 && ipEnterCheckBox.Checked)
            {
                DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + Settings.ComputersDN);
                DirectoryEntry newComp = ldapEntry.Children.Add("cn=" + ipEnterTextBox.Text, "computer");
                newComp.Properties["sAMAccountName"].Value = ipEnterTextBox.Text;

                newComp.CommitChanges();
                ldapEntry.CommitChanges();


                if (UserControls.enableAccount(newComp.Path) && UserControls.addToGroup(newComp.Path.Remove(0, 7), "CN=Domain Computers,CN=USERS,DC=APEX,DC=Local"))
                {
                    MessageBox.Show("Computer has been successfully registered and enabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ldapEntry.Close();
            }
            else
            {
                MessageBox.Show("Please enter a computer name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

//WORKSTATION SEARCH FUNCTION

        private void applySearchFilter()
        {
            if (!applySearchBackground.IsBusy)
            {
                clearSummary();
                RemoteConnect.cancelRequest = true;
                if (fillListView.IsBusy)
                {
                    resultList.Items.Add("Cancelling probe...");
                    fillListView.CancelAsync();
                }
                while (fillListView.IsBusy)
                {
                    loadingGraphic.Show();                    
                    Application.DoEvents();
                }
                clearSummary();
                loadingGraphic.Show();
                TotalItems = 0;
                resultList.Items.Clear();
                runButton.Enabled = false;
                string[] searchFilterArray = { filterTextBox.Text.ToLower(), "Workstations" };
 
                applySearchBackground.RunWorkerAsync(searchFilterArray);
            }
        }

        private void applySearchBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] searchFilterArray = (string[])e.Argument;
            DirectoryReport.getDirectoryReport(searchFilterArray[0], searchFilterArray[1]);
        }

        private void applySearchBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RemoteConnect.cancelRequest = false;
            runButton.Enabled = true;
            probeStopButton.Text = "Pause";
            filterApplyButton.Enabled = false;
            foreach (string item in DirectoryReport.SearchList.Keys)
            {
                TotalItems++;
                resultList.Items.Add(new ListViewItem(new string[] { item, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty }));
            }
            if (resultList.Items.Count <= 0)
            {
                resultList.Items.Add("No results. . .");
            }
            filterTextBox.SelectAll();
            filterApplyButton.Enabled = true;
            totalItemsLabel.Text = "Total Items: " + TotalItems;
            countProgressLabel.Text = "0 of " + TotalItems;
            progressBar.Maximum = TotalItems;
            progressBar.Value = 0;
            totalCompText.Text = TotalItems.ToString();
            loadingGraphic.Hide();
        }

//END WORKSTATION SEARCH FUNCTION

        public static void setData(string user, string pass, bool authenticated)
        {
            if (authenticated)
            {
                UserData = user;
                PassData = pass;
            }
        }
        //export object list to text file

        private List<string> getObjectList()
        {
            List<string> newList = new List<string>();
            for (TotalItems = 0; TotalItems < resultList.Items.Count; TotalItems++ )
            {
                ListViewItem.ListViewSubItemCollection subItems = resultList.Items[TotalItems].SubItems;
                string subItemsString = string.Empty;
                foreach (ListViewItem.ListViewSubItem item in subItems)
                {
                    subItemsString += item.Text + "\t";
                }
                newList.Add(subItemsString);
            }
            return newList;
        }


//STATUS BAR TOOL TIPS
        private void enableRemoteButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Enables remote desktop on selected machine.";
        }

        private void enableRemoteButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void disableRemoteButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Disables remote desktop on selected machine.";
        }

        private void disableRemoteButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void startRDSessionButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Attempts to start a Remote Desktop session with selected machine.";
        }

        private void startRDSessionButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void mapDriveButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "After operation, user must logoff for changes to appear";
        }

        private void mapDriveButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void runCleanupButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Opens remote cleanup utility for selected machine.";
        }

        private void runCleanupButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void gpupdateButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Run GPUpdate on selected machine. Must supply admin credentials.";
        }

        private void gpupdateButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void exportButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Opens current list of objects in text editor.";
        }

        private void exportButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void objectsLoadButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Retrieves list of objects from Active Directory.";
        }

        private void objectsLoadButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void ipEnterCheckBox_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Allows you to specify IP address or computer name not listed.";
        }

        private void ipEnterCheckBox_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void resolveHostButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Resolve above address to IP.";
        }

        private void resolveHostButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void resolveIPButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Resolve above address or host to full hostname.";
        }

        private void resolveIPButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void runLocallyCheckBox_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Specify credentials to run remote command as.";
        }

        private void runLocallyCheckBox_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void customCommandRunButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Run custom command on selected machine.";
        }

        private void customCommandRunButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void runAsButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Opens login window to store credentials.";
        }

        private void runAsButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

//USER TAB

        private void userGroupChangeList_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Double click user to view/edit details";
        }

        private void userGroupChangeList_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
            //descriptionToolTip.Hide(userGroupChangeList);
        }

        private void userOuTreeView_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Selecting an item will load all users from that OU";
        }

        private void userOuTreeView_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void userChangePwButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Multiple users may be selected for this operation.";
        }

        private void userChangePwButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void userEnableButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Enables all selected user's accounts.";
        }

        private void userEnableButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void userDisableButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Disables all selected user's accounts.";
        }

        private void userDisableButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void userTermButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Performs on selected user(s): remove groups; move to *Disabled; disables account.";
        }

        private void userTermButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void userCopyButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Create new user and clones groups, OU, and description.";
        }

        private void userCopyButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void userAddGroupButton_MouseEnter(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "Add all selected users to selected group.";
        }

        private void userAddGroupButton_MouseLeave(object sender, EventArgs e)
        {
            mainToolStripLabel.Text = "";
        }

        private void processAddToGroup(ListView.SelectedListViewItemCollection sender, Dictionary<string, string> currentUsers)
        {
            List<string> selectedUsers = new List<string>();
            string groupToAdd = groupsDict[userGroupAddGroupCombo.Text];

            foreach (ListViewItem user in sender)
            {
                string userToAdd = currentUsers[user.Text];
                if (!userToAdd.Equals("NONE"))
                {
                    string resultString = string.Empty;
                    if (UserControls.addToGroup(userToAdd, groupToAdd))
                    {
                        resultString += "[" + user.Text;
                        while (resultString.Length < 30)
                        {
                            resultString += " ";
                        }
                        resultString += "\t Success]";
                        UserControls.GroupAddResults.Add(resultString);
                    }
                    else
                    {
                        resultString += "[" + user.Text;
                        while (resultString.Length < 30)
                        {
                            resultString += " ";
                        }
                        resultString += "\t Failed]";
                        UserControls.GroupAddResults.Add(resultString);
                    }
                }
            }
            string actionResult = string.Empty;
            foreach (string str in UserControls.GroupAddResults)
            {
                actionResult += str + "\n";
            }
            MessageBox.Show("Added [" + userGroupAddGroupCombo.Text + "] to the following users:\n\n" + actionResult, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UserControls.GroupAddResults.Clear();
        }

        private void userAddGroupButton_Click(object sender, EventArgs e)
        {
            if (userQueueList.Items.Count > 0)
            {
                for (int i = 0; i < userQueueList.Items.Count; i++)
                {
                    userQueueList.Items[i].Selected = true;
                }
                processAddToGroup(userQueueList.SelectedItems, UserControls.BatchUsers);
            }
            else
            {
                processAddToGroup(userGroupChangeList.SelectedItems, UserControls.CurrentUsers);
            }
            DialogResult clear = MessageBox.Show("Clear queue list?", "Clear list", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (clear == DialogResult.Yes)
            {
                userQueueList.Items.Clear();
                UserControls.BatchUsers.Clear();
            }
        }

        private void userFindButton_Click(object sender, EventArgs e)
        {
            if (userNameFindBox.Text.Length < 3)
            {
                MessageBox.Show("Please make your search more specific.", "Too vague", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userBusyGraphic.Visible = false;
            }
            else
            {
                DirectoryReport.UserList.Clear();
                DirectoryReport.UserList.Add(userNameFindBox.Text);
                applyUserSearchFilter(DirectoryReport.UserList);
            }
        }

        private void userNameFindBox_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    if (userNameFindBox.Text.Length < 3)
                    {
                        MessageBox.Show("Please make your search more specific.", "Too vague", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        userBusyGraphic.Visible = false;
                    }
                    else
                    {
                        e.SuppressKeyPress = true;
                        DirectoryReport.UserList.Clear();
                        DirectoryReport.UserList.Add(userNameFindBox.Text);
                        applyUserSearchFilter(DirectoryReport.UserList);
                    }
                }
            
        }

        private void applyUserSearchFilter(List<string> list)
        {
            TotalUsers = 0;
            userBusyGraphic.Visible = true;

            userGroupChangeList.Items.Clear();
            UserControls.CurrentUsers.Clear();
            UserControls.CurrentDesc.Clear();
            foreach (string user in list)
            {
                while (backgroundUserSearch.IsBusy)
                {
                    Application.DoEvents();
                }
                backgroundUserSearch.RunWorkerAsync(user);
            }
        }

        private void backgroundUserSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            UserControls.UserList = UserControls.findUserAD(e.Argument.ToString(), false);
            UserControls.UserList.Sort();
        }

        private void backgroundUserSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (string result in UserControls.UserList)
            {
                //MessageBox.Show(UserControls.CurrentDesc[result]);
                ListViewItem tmp = new ListViewItem(new string[] { result, UserControls.CurrentDesc[result][0], UserControls.CurrentDesc[result][1], UserControls.CurrentDesc[result][2], UserControls.CurrentDesc[result][3] });
                userGroupChangeList.Items.Add(tmp);
                TotalUsers++;
            }
            userTotalLabel.Text = "Items: " + TotalUsers;
            userBusyGraphic.Visible = false;
            if (userGroupChangeList.Items.Count >= 1)
            {
                userGroupChangeList.Items[0].Selected = true;
                userGroupChangeList.Focus();
            }
        }

        private void userGroupSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (userGroupSelectAll.Checked)
            {
                for (int i = 0; i < userGroupChangeList.Items.Count; i++)
                {
                    userGroupChangeList.Items[i].Selected = true;
                }
            }
            else
            {
                for (int i = 0; i < userGroupChangeList.Items.Count; i++)
                {
                    userGroupChangeList.Items[i].Selected = false;
                }
            }
        }

        public void userGroupLoadUsers()
        {
            if (!backgroundFillUserList.IsBusy)
            {
                userGroupChangeList.Items.Clear();
                TotalUsers = 0;
                string[] fullPathArray = userOuTreeView.SelectedNode.FullPath.Split('\\');
                string fullPath = string.Empty;
                for (int i = fullPathArray.Length - 1; i >= 0; i--)
                {
                    fullPath += "OU=" + fullPathArray[i] + ",";
                }
                userBusyGraphic.Visible = true;
                backgroundFillUserList.RunWorkerAsync(fullPath);
            }
            else
            {
                backgroundFillUserList.CancelAsync();
            }
        }

        private void userGroupLoadUsersButton_Click(object sender, EventArgs e)
        {
            userGroupLoadUsers();
        }

        private void userLoadPropertiesThread_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void userLoadPropertiesThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
         
        //private Dataset

        private void userGroupChangeList_DoubleClick(object sender, EventArgs e)
        {
            object[] tmp = new object[] { userGroupChangeList.SelectedItems };
            userLoadProperties(userGroupChangeList.SelectedItems[0].Text);
        }

        private void userGroupChangeList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                addToQueue();
                userNameFindBox.Focus();
                userNameFindBox.SelectAll();
            }
            if (e.KeyCode == Keys.Enter)
            {
                foreach (ListViewItem displayName in userGroupChangeList.SelectedItems)
                {
                    userLoadProperties(displayName.Text);
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                DialogResult confirmDel = MessageBox.Show("Delete selected user(s)?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmDel == DialogResult.Yes)
                {
                    foreach (ListViewItem user in userGroupChangeList.SelectedItems)
                    {
                        string userName = UserControls.getUserName(UserControls.CurrentUsers[user.Text]);
                        string folderPath = DirectoryReport.findUserFolder(userName);

                        string[] pathExploded = UserControls.CurrentUsers[user.Text].Split(',');
                        string ouPath = string.Empty;
                        foreach (string ou in pathExploded)
                        {
                            if (ou.Substring(0, 3).Equals("OU="))
                            {
                                ouPath += ou + ",";
                            }
                        }
                        //delete user
                        UserControls.remUserAD(ouPath, user.Text, UserControls.CurrentUsers[user.Text]);
                        DialogResult answer = MessageBox.Show("Place location of documents folder in clipboard?", "Delete user",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == answer)
                        {
                            if (!folderPath.Equals(string.Empty))
                            {
                                Clipboard.SetText(folderPath);
                            }
                            else
                            {
                                MessageBox.Show("No documents folder found for user.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void userLoadProperties(string displayName)
        {
            //MessageBox.Show(displayName);
            if (UserControls.isGroup(UserControls.CurrentUsers[displayName]))
            {
                GroupProperties loadGroup = new GroupProperties(UserControls.CurrentUsers[displayName]);
                loadGroup.Text = displayName;
                loadGroup.Show();
            }
            else
            {
                if (UserControls.findOneUserAD(displayName).Equals("NONE"))
                {
                    MessageBox.Show("This object no longer exists", "Quitting", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    UserControls.CurrentUsers.Remove(userGroupChangeList.SelectedItems[0].Text);
                    userGroupChangeList.Items.Remove(userGroupChangeList.SelectedItems[0]);
                }
                else
                {
                    ObjectProperties loadUser = new ObjectProperties(UserControls.CurrentUsers[displayName]);
                    loadUser.Text = displayName + " Properties";
                    loadUser.Show();
                }
            }
        }

        private void userOuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            userGroupLoadUsers();
        }

        private void termUser(ListView.SelectedListViewItemCollection sender, Dictionary<string, string> currentUsers)
        {
            Forms.TermUser TermWindow = new Forms.TermUser(sender, currentUsers);
            TermWindow.ShowDialog();
        }

        private void userTermButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < userQueueList.Items.Count; i++)
            {
                userQueueList.Items[i].Selected = true;
            }
            termUser(userQueueList.SelectedItems, UserControls.BatchUsers);
            DialogResult clear = MessageBox.Show("Clear queue list?", "Clear list", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (clear == DialogResult.Yes)
            {
                userQueueList.Items.Clear();
                UserControls.BatchUsers.Clear();
            }
        }

        private void enableUser(ListView.SelectedListViewItemCollection sender, Dictionary<string, string> currentUsers)
        {
            string resultMessage = "Enabling users resulted in:\n\n";
            foreach (ListViewItem user in sender)
            {
                if (!UserControls.isGroup(currentUsers[user.Text]))
                {
                    if (UserControls.enableAccount(currentUsers[user.Text]))
                    {
                        resultMessage += "[" + user.Text + "]\t\t Enabled\n";
                    }
                    else
                    {
                        resultMessage += "[" + user.Text + "]\t\t Failed\n";
                    }
                }
            }
            MessageBox.Show(resultMessage, "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void userEnableButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < userQueueList.Items.Count; i++)
            {
                userQueueList.Items[i].Selected = true;
            } 
            enableUser(userQueueList.SelectedItems, UserControls.BatchUsers);
            DialogResult clear = MessageBox.Show("Clear queue list?", "Clear list", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (clear == DialogResult.Yes)
            {
                userQueueList.Items.Clear();
                UserControls.BatchUsers.Clear();
            }
        }

        private void disableUser(ListView.SelectedListViewItemCollection sender, Dictionary<string, string> currentUsers)
        {
            string resultMessage = "Disabling users resulted in:\n\n";
            foreach (ListViewItem user in sender)
            {
                if (!UserControls.isGroup(currentUsers[user.Text]))
                {
                    if (UserControls.disableAccount(currentUsers[user.Text]))
                    {
                        resultMessage += "[" + user.Text + "]\t\t Disabled\n";
                    }
                    else
                    {
                        resultMessage += "[" + user.Text + "]\t\t Failed\n";
                    }
                }
            }
            MessageBox.Show(resultMessage, "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void userDisableButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < userQueueList.Items.Count; i++)
            {
                userQueueList.Items[i].Selected = true;
            } 
            disableUser(userQueueList.SelectedItems, UserControls.BatchUsers);
            DialogResult clear = MessageBox.Show("Clear queue list?", "Clear list", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (clear == DialogResult.Yes)
            {
                userQueueList.Items.Clear();
                UserControls.BatchUsers.Clear();
            }
        }

        private void backgroundFillUserList_DoWork(object sender, DoWorkEventArgs e)
        {
            UserControls.UserList = UserControls.fillUserList(e.Argument.ToString());
            UserControls.UserList.Sort();
        }

        private void backgroundFillUserList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (string user in UserControls.UserList)
            {
                ListViewItem tmp = new ListViewItem(new string[] { user, UserControls.CurrentDesc[user][0], UserControls.CurrentDesc[user][1], UserControls.CurrentDesc[user][2], UserControls.CurrentDesc[user][3] });
                userGroupChangeList.Items.Add(tmp);
                TotalUsers++;
            }
            userTotalLabel.Text = "Items: " + TotalUsers;
            userBusyGraphic.Visible = false;
        }

        private void resetPassword(ListView.SelectedListViewItemCollection sender, Dictionary<string, string> currentUsers)
        {
            string resultMessage = "Result of changing password:\n\n";
            Forms.SetPassword newPass = new Forms.SetPassword();
            newPass.ShowDialog();
            if (!UserControls.NewPass.Equals(string.Empty))
            {
                foreach (ListViewItem user in sender)
                {
                    if (!UserControls.isGroup(currentUsers[user.Text]))
                    {
                        if (UserControls.changePassword(currentUsers[user.Text], UserControls.NewPass))
                        {
                            resultMessage += "[" + user.Text + "]\t\t Success\t\n";
                        }
                        else
                        {
                            resultMessage += "[" + user.Text + "]\t\t Failed\t\n";
                        }
                    }
                }
                MessageBox.Show(resultMessage, "Change password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void userChangePwButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < userQueueList.Items.Count; i++)
            {
                userQueueList.Items[i].Selected = true;
            }
            resetPassword(userQueueList.SelectedItems, UserControls.BatchUsers);
            DialogResult clear = MessageBox.Show("Clear queue list?", "Clear list", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (clear == DialogResult.Yes)
            {
                userQueueList.Items.Clear();
                UserControls.BatchUsers.Clear();
            }
        }
        private void queueHideGal_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;
            ListView.ListViewItemCollection selectedItems = userQueueList.Items;
            foreach (ListViewItem item in selectedItems)
            {
                if (ExchangeMgmt.hideMailbox(UserControls.BatchUsers[item.Text], true))
                {
                    resultMessage += "[" + item.Text + "]\t\t Success\t\n";
                }
                else
                {
                    resultMessage += "[" + item.Text + "]\t\t Success\t\n";
                }
            }
            MessageBox.Show(resultMessage, "Hide mailbox from GAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult clear = MessageBox.Show("Clear queue list?", "Clear list", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (clear == DialogResult.Yes)
            {
                userQueueList.Items.Clear();
                UserControls.BatchUsers.Clear();
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (!DirectoryReport.powerShellInstalled())
                {
                    DialogResult answer = MessageBox.Show("Windows PowerShell is required to create Exchange mailboxes.\n\nDownload PowerShell now?", 
                        "Windows Powershell", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == answer)
                    {
                        Process.Start("iexplore.exe", "http://www.microsoft.com/windowsserver2003/technologies/management/powershell/download.mspx");
                    }
                }
                userNameFindBox.Focus();
            }
        }

        private void copySelectedUser()
        {
            if (userGroupChangeList.SelectedItems.Count == 1)
            {
                UserControls.CopyUserDetails.Clear();
                Forms.CopyUser copyUser = new Forms.CopyUser();
                copyUser.ShowDialog();
                if (!UserControls.CopyUserDetails.ContainsKey("INCOMPLETE"))
                {
                    bool success = UserControls.copyUserAd(UserControls.CurrentUsers[userGroupChangeList.SelectedItems[0].Text], UserControls.CopyUserDetails["first"],
                        UserControls.CopyUserDetails["last"], UserControls.CopyUserDetails["middle"], UserControls.CopyUserDetails["password"]);
                    if (success)
                    {
                        string newUname = UserControls.CopyUserDetails["samAccountName"];
                        string newDesc = UserControls.CopyUserDetails["description"];
                        string newDisplayName = UserControls.CopyUserDetails["displayname"];
                        string ou = UserControls.CopyUserDetails["ou"];
                        string newPath = UserControls.CopyUserDetails["path"];
                        ListViewItem newUserItem = new ListViewItem(new string[]{newDisplayName, newDesc, newUname, ou});
                        userGroupChangeList.Items.Add(newUserItem);
                        UserControls.CurrentUsers.Add(newDisplayName, newPath);

                        DialogResult answer = MessageBox.Show("Successfully copied user.\n\nPut login information in clipboard?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (answer == DialogResult.Yes)
                        {
                            string clipboardText = UserControls.getUserName(UserControls.CopyUserDetails["path"].Remove(0,7)) + "\r\n" +
                                UserControls.CopyUserDetails["password"];
                            Clipboard.SetText(clipboardText);
                        }
                        DialogResult answer2 = MessageBox.Show("Copy user again?", "Copy user", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == answer2)
                        {
                            copySelectedUser();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to copy user.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Copy user cancelled.", "User copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void userGroupChangeList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && userGroupChangeList.SelectedItems.Count > 0)
            {
                userContextMenu.Show(userGroupChangeList, e.Location); 
            }

        }

        private void userContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string selectedItem = userGroupChangeList.SelectedItems[0].Text;
            for (int i = 0; i < userGroupChangeList.SelectedItems.Count; i++)
            {
                //MessageBox.Show(userGroupChangeList.Items[i].Text);
                if (UserControls.isGroup(UserControls.CurrentUsers[userGroupChangeList.Items[i].Text]))
                {
                    //userGroupChangeList.
                }
            }
            if (e.ClickedItem.Text.Equals("Open Documents folder") && userGroupChangeList.SelectedItems.Count == 1)
            {
                userContextMenu.Close();
                string folderPath = DirectoryReport.findUserFolder(UserControls.getUserName(UserControls.CurrentUsers[userGroupChangeList.SelectedItems[0].Text]));
                if (folderPath.Equals(string.Empty))
                {
                    MessageBox.Show("No documents folder found.", "No result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Process.Start("explorer.exe", folderPath);
                }
            }
            if (e.ClickedItem.Text.Equals("Disable"))
            {
                userContextMenu.Close();
                disableUser(userGroupChangeList.SelectedItems, UserControls.CurrentUsers);
            }
            if (e.ClickedItem.Text.Equals("Enable"))
            {
                userContextMenu.Close();
                enableUser(userGroupChangeList.SelectedItems, UserControls.CurrentUsers);
            }
            if (e.ClickedItem.Text.Equals("Reset lockout"))
            {
                userContextMenu.Close();
                string resultString = "Result of resetting lockout:\n\n";
                foreach (ListViewItem displayName in userGroupChangeList.SelectedItems)
                {
                    if (UserControls.resetLockout(displayName.Text))
                    {
                        resultString += "[" + displayName.Text + "]\t\t" + "Success\n";
                    }
                    else
                    {
                        resultString += "[" + displayName.Text + "]\t\t" + "Failed\n";
                    }
                }
                MessageBox.Show(resultString, "Reset lockout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.ClickedItem.Text.Equals("View/Edit User"))
            {
                userContextMenu.Close();
                foreach (ListViewItem user in userGroupChangeList.SelectedItems)
                {
                    userLoadProperties(user.Text);
                }
            }
            if (e.ClickedItem.Text.Equals("Copy") && !UserControls.isGroup(UserControls.CurrentUsers[selectedItem]))
            {
                userContextMenu.Close();
                copySelectedUser();
            }
            else if (e.ClickedItem.Text.Equals("Change password"))
            {
                userContextMenu.Close();
                resetPassword(userGroupChangeList.SelectedItems, UserControls.CurrentUsers);
            }
            else if (e.ClickedItem.Text.Equals("Term user(s)"))
            {
                userContextMenu.Close();
                termUser(userGroupChangeList.SelectedItems, UserControls.CurrentUsers);
            }
            else if (e.ClickedItem.Text.Equals("Add to queue"))
            {
                addToQueue();
            }
            else if (e.ClickedItem.Text.Equals("Export User List"))
            {
                userContextMenu.Close();
                UserControls.exportUsers(userGroupChangeList.Items);
            }
        }

        private void addToQueue()
        {
            userContextMenu.Close();
            ListView.SelectedListViewItemCollection itemsToAdd = userGroupChangeList.SelectedItems; 
            foreach (ListViewItem item in itemsToAdd)
            {
                if (!UserControls.isGroup(UserControls.CurrentUsers[item.Text]))
                {

                    //remove line from list and add it to the queue list
                    userGroupChangeList.Items.Remove(item);
                    userQueueList.Items.Add(item);

                    UserControls.BatchUsers.Add(item.Text, UserControls.CurrentUsers[item.Text]);
                    UserControls.CurrentUsers.Remove(item.Text);

                }
            }
        }

        private void clearQueueButton_Click(object sender, EventArgs e)
        {
            userQueueList.Items.Clear();
            UserControls.BatchUsers.Clear();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> mailBoxPaths = new Dictionary<string, string>();
            string mailBoxesPath = "CN=InformationStore,CN=Mailbox,CN=Servers,CN=Exchange Administrative Group (FYDIBOHF23SPDLT)," +
                "CN=Administrative Groups,CN=APEX,CN=Microsoft Exchange,CN=Services,CN=Configuration,DC=APEX,DC=Local";
            DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + mailBoxesPath);
            foreach (DirectoryEntry entry in ldapEntry.Children)
            {
                foreach (DirectoryEntry rootEntry in entry.Children)
                {
                    mailBoxPaths.Add(rootEntry.Name, @"Mailbox\" + rootEntry.Name + @"\" + rootEntry.Name);
                }
            }
        }

        private void findRepButton_Click(object sender, EventArgs e)
        {
            Forms.FindRep findRep = new Forms.FindRep();
            findRep.Show();
        }

        public static int selectedIndex;
        public static string tooltipDescription;
        public static Point sPosition;
        public static Point sListBox;
       // public static Point sDrawTo;
        public static int hoverIndex;

        private void userGroupChangeList_MouseHover(object sender, EventArgs e)
        {
            /*
            if (!tooltipBackground.IsBusy)
            {
                //descriptionToolTip.Hide(userGroupChangeList);
                sPosition = ListBox.MousePosition;
                sPosition.X = sPosition.X + 10;
                sListBox = userGroupChangeList.PointToClient(sPosition);

                hoverIndex = userGroupChangeList.IndexFromPoint(sListBox);

                if (hoverIndex >= 0)
                {
                    //if (selectedIndex != hoverIndex)
                    {
                        descriptionToolTip.ToolTipTitle = userGroupChangeList.Items[hoverIndex] + " Description:";
                        selectedIndex = hoverIndex;

                        tooltipBackground.RunWorkerAsync();
                        //tooltipDescription = UserControls.getDescription(UserControls.CurrentUsers[userGroupChangeList.Items[hoverIndex].ToString()]);
                        //descriptionToolTip.Show(tooltipDescription, userGroupChangeList, sListBox);
                    }
                }
            }
            */
        }

        private ListViewColumnSorter resultListColumnSorter;
        private ListViewColumnSorter lvwColumnSorter;

        private void resultList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == resultListColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (resultListColumnSorter.Order == SortOrder.Ascending)
                {
                    resultListColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    resultListColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                resultListColumnSorter.SortColumn = e.Column;
                resultListColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.resultList.Sort();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (RemoteConnect.pauseRequest)
            {
                RemoteConnect.pauseRequest = false;
                probeStopButton.Text = "Pause";
            }
            else
            {
                RemoteConnect.pauseRequest = true;
                probeStopButton.Text = "Continue";
            }
            //fillListView.CancelAsync();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            resultList.Items.Clear();
        }

        private void tooltipBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            tooltipDescription = UserControls.getDescription(UserControls.CurrentUsers[userGroupChangeList.Items[hoverIndex].ToString()]);
        }

        private void tooltipBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            descriptionToolTip.Show(tooltipDescription, userGroupChangeList, sListBox);
        }

        private void userGroupChangeList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.userGroupChangeList.Sort();

        }

        private void getComputers_DoWork(object sender, DoWorkEventArgs e)
        {
            RemoteConnect.Computers = DirectoryReport.ObjectList;
        }

        private void fillListView_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string name in DirectoryReport.ObjectList.Keys)
            {
                while (RemoteConnect.pauseRequest)
                {
                    if (RemoteConnect.cancelRequest)
                    {
                        break;
                    }
                    Application.DoEvents();
                }
                if (RemoteConnect.cancelRequest)
                {
                    break;
                }
                else
                {
                    RemoteConnect.CurrentRow = RemoteConnect.getComputerListViewItem(name);
                    fillListView.ReportProgress(RemoteConnect.Count / DirectoryReport.ObjectList.Count);
                }
            }            
        }

        private void fillListView_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!resultList.Items.Contains(RemoteConnect.CurrentRow) && !RemoteConnect.cancelRequest)
            {
                countProgressLabel.Text = RemoteConnect.Count + " of " + DirectoryReport.ObjectList.Count;                
                //int index = resultList.Items.IndexOfKey(RemoteConnect.CurrentRow.Text);
                //MessageBox.Show(RemoteConnect.CurrentRow.Text);
                //resultList.Items.RemoveAt(index);
                resultList.Items.Add(RemoteConnect.CurrentRow);
                
                progressBar.Increment(1);
                total520Text.Text = RemoteConnect.Summary["520"].ToString();
                total740Text.Text = RemoteConnect.Summary["740"].ToString();
                total755Text.Text = RemoteConnect.Summary["755"].ToString();
                total760Text.Text = RemoteConnect.Summary["760"].ToString();
                total960Text.Text = RemoteConnect.Summary["960"].ToString();
                totalOtherText.Text = RemoteConnect.Summary["other"].ToString();
                totalErrorsText.Text = RemoteConnect.Summary["errors"].ToString();
            }
        }

        private void fillListView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RemoteConnect.cancelRequest = false;
            runButton.Enabled = true;
            progressBar.Value = progressBar.Maximum;
        }

        private void fillListDblClk()
        {
            if (!singleListViewBackground.IsBusy)
            {
                if (resultList.SelectedItems.Count >= 1)
                {
                    resultListColumnSorter.Order = SortOrder.None;
                    //lvwColumnSorter.SortColumn = 0;
                    //lvwColumnSorter.Order = SortOrder.Ascending;
                    singleListViewBackground.RunWorkerAsync(resultList.SelectedItems[0].Text);
                }
            }
            else
            {
                DialogResult retry = MessageBox.Show("The worker is busy retrieving information. Please try again shortly.", "Busy", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                if (retry.Equals(DialogResult.Retry))
                {
                    fillListDblClk();
                }
            }
        }

        private void resultList_DoubleClick(object sender, EventArgs e)
        {
            fillListDblClk();
        }

        private void getComputers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            countProgressLabel.Text = RemoteConnect.Count + " of " + DirectoryReport.ObjectList.Count;
            progressBar.Maximum = RemoteConnect.Computers.Count;
            totalCompText.Text = RemoteConnect.Computers.Count.ToString();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            RemoteConnect.Count = 0;
            clearSummary();
            resultList.Items.Clear();
            fillListView.RunWorkerAsync();
            runButton.Enabled = false;
        }

        private void probeStopButton_Click(object sender, EventArgs e)
        {
            if (RemoteConnect.pauseRequest)
            {
                RemoteConnect.pauseRequest = false;
                probeStopButton.Text = "Pause";
            }
            else
            {
                RemoteConnect.pauseRequest = true;
                probeStopButton.Text = "Continue";
            }
            //fillListView.CancelAsync();
        }

        public void clearSummary()
        {
            total520Text.Text = "0";
            total740Text.Text = "0";
            total755Text.Text = "0";
            total760Text.Text = "0";
            total960Text.Text = "0";
            totalOtherText.Text = "0";
            totalErrorsText.Text = "0";
            RemoteConnect.Summary["520"] = 0;
            RemoteConnect.Summary["740"] = 0;
            RemoteConnect.Summary["755"] = 0;
            RemoteConnect.Summary["760"] = 0;
            RemoteConnect.Summary["960"] = 0;
            RemoteConnect.Summary["errors"] = 0;
            RemoteConnect.Summary["other"] = 0;

            totalCompText.Text = DirectoryReport.ObjectList.Count.ToString();
            countProgressLabel.Text = "0 of " + RemoteConnect.Computers.Count.ToString();
            progressBar.Value = progressBar.Minimum;
            resultList.Items.Clear();
        }

        private void probeClearButton_Click(object sender, EventArgs e)
        {
            runButton.Enabled = false;
            probeClearButton.Enabled = false;
            clearSummary();
            RemoteConnect.cancelRequest = true;
            if (fillListView.IsBusy)
            {
                fillListView.CancelAsync();
                resultList.Items.Add("Cancelling probe...");
            }
            while (fillListView.IsBusy)
            {
                Application.DoEvents();
            }
            this.backgroundLoadObjects.RunWorkerAsync("Workstations");
            Application.DoEvents();
        }

        private void singleListViewBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            RemoteConnect.CurrentRow = RemoteConnect.getComputerListViewItem(e.Argument.ToString());
        }

        private void singleListViewBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!RemoteConnect.cancelRequest)
            {
                int index = resultList.SelectedItems[0].Index;
                resultList.Items.RemoveAt(index);
                resultList.Items.Insert(index, RemoteConnect.CurrentRow);
            }
        }

        private void fillObjectList_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void fillObjectList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void syncDatabase_Click(object sender, EventArgs e)
        {
            if (RemoteConnect.syncDatabase())
            {
                MessageBox.Show("Database has been successfully updated.", "Update complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update database.", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                
        }

        private void exportSaveButton_Click(object sender, EventArgs e)
        {
            exportSaveFileDialog.Filter = "Text file (*.txt)|*.txt|Excel Spreadsheet (*.xls)|*.xls|All files (*.*)|*.*";
            exportSaveFileDialog.AddExtension = true;
            exportSaveFileDialog.RestoreDirectory = true;
            exportSaveFileDialog.FileName = "computer_list.txt";
            exportSaveFileDialog.Title = "Save exported list to file";

            string folderPath = DirectoryReport.findUserFolder(Environment.UserName);
            if (folderPath.Equals(string.Empty))
            {
                exportSaveFileDialog.InitialDirectory = @"desktop";
            }
            else
            {
                exportSaveFileDialog.InitialDirectory = folderPath + @"\My Documents";
            }

            DialogResult returnValue = exportSaveFileDialog.ShowDialog();
            exportFileBox.Text = exportSaveFileDialog.FileName;
            //MessageBox.Show(exportSaveFileDialog.FileName);
        }

        private void exportTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (exportTypeCombo.Text.Equals("Excel"))
            {
                exportSaveButton.Enabled = false;
                exportFileBox.Enabled = false;
            }
            else
            {
                exportFileBox.Enabled = true;
                exportSaveButton.Enabled = true;
            }
        }

        private void hideMailboxFromGALToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            userContextMenu.Close();
            if (ExchangeMgmt.hideMailbox(UserControls.CurrentUsers[userGroupChangeList.SelectedItems[0].Text], true))
            {
                MessageBox.Show("Mailbox has been successfully hidden from the Global Address List", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void enableMailboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userContextMenu.Close();
            if (ExchangeMgmt.enableMailbox("string", UserControls.CurrentUsers[userGroupChangeList.SelectedItems[0].Text]))
            {
                MessageBox.Show("Mailbox has been successfully enabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unable to enable mailbox.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void disableMailboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userContextMenu.Close();
            if (ExchangeMgmt.disableMailbox(UserControls.CurrentUsers[userGroupChangeList.SelectedItems[0].Text]))
            {
                MessageBox.Show("Mailbox has been successfully disabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unable to disable mailbox.\n\n" + ExchangeMgmt.errorMessage, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void enableMailboxToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!e.ClickedItem.Text.Contains("In Folder"))
            {
                userContextMenu.Close();
                if (ExchangeMgmt.enableMailbox(ExchangeMgmt.Databases[e.ClickedItem.Text], UserControls.CurrentUsers[userGroupChangeList.SelectedItems[0].Text]))
                {
                    MessageBox.Show("Mailbox has been successfully enabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to enable mailbox.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void userQueueList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && userQueueList.SelectedItems.Count > 0)
            {
                 queueListContextMenu.Show(userQueueList, e.Location);
            }
        }

        private void removeFromQueue_Click(object sender, EventArgs e)
        {
            queueListContextMenu.Close();
            ListView.SelectedListViewItemCollection itemsToAdd = userQueueList.SelectedItems;
            foreach (ListViewItem item in itemsToAdd)
            {
                userQueueList.Items.Remove(item);
                UserControls.BatchUsers.Remove(item.Text);
            }
        }

        private void showMailboxInGALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userContextMenu.Close();
            if (ExchangeMgmt.hideMailbox(UserControls.CurrentUsers[userGroupChangeList.SelectedItems[0].Text], false))
            {
                MessageBox.Show("Mailbox has been shown in the Global Address List", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void resultList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && resultList.SelectedItems.Count > 0)
            {
                computerMenu.Show(resultList, e.Location);
            }
        }

        private void probeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fillListDblClk();
        }

        private void exportUsersButton_Click(object sender, EventArgs e)
        {
            if (UserControls.isValidUser())
            {
                MessageBox.Show("Cool");
            }
            //exportToExcel();
            //UserControls.exportUsers(userGroupChangeList.Items);
            //DirectoryReport.updateExtensions(@"c:\external_ext.txt");
            //DirectoryReport.updateExtensions(@"c:\soft_phone_ext.txt");
        }
        private void exportToExcel()
        {
            /*int i = 1;
            CreateExcelWorksheet excelSheet = new CreateExcelWorksheet();
            //create column headers
            Object[] newRow = new string[] { "Name", "Description", "Username", "OU", "Number" };
            excelSheet.WriteRow(i, newRow);
            i++;

            //add resultList items to excel sheet
            foreach (ListViewItem item in userGroupChangeList.Items)
            {
                newRow = new string[] { item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text };
                excelSheet.WriteRow(i, newRow);
                i++;
            }
            //show the application
            excelSheet.AutoFit();
            excelSheet.Commit();*/
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportToExcel();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControls.exportUsers(userGroupChangeList.Items);
        }

        private void userFindLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdvancedSearch window = new AdvancedSearch();
            DirectoryReport.UserList.Clear();
            window.ShowDialog();
            if (DirectoryReport.UserList.Count > 0 && DirectoryReport.UserList[0] != null)
            {
                applyUserSearchFilter(DirectoryReport.UserList);
            }
        }

        private void moveToToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (UserControls.moveObject("LDAP://" + UserControls.CurrentUsers[userGroupChangeList.SelectedItems[0].Text], TreeOU[e.ClickedItem.Text]))
            {
                DirectoryReport.UserList.Clear();
                DirectoryReport.UserList.Add(userNameFindBox.Text);
                applyUserSearchFilter(DirectoryReport.UserList);
            }
        }

        private void openCDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedComputer = resultList.SelectedItems[0].Text;
            if (RemoteConnect.canConnect(selectedComputer))
            {
                Process.Start("explorer.exe", @"\\" + selectedComputer + @"\c$");
            }
            else
            {
                MessageBox.Show("Cannot connect to " + selectedComputer, "Ping", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void runCleanupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resultList.SelectedItems.Count >= 1 || ipEnterCheckBox.Checked)
            {
                if (resultList.SelectedItems.Count >= 1)
                {
                    SelectedComputer = resultList.SelectedItems[0].Text;
                }
                if (ipEnterCheckBox.Checked)
                {
                    SelectedComputer = getHostName(ipEnterTextBox.Text);
                }
                Forms.RunCleanup cleanupWindow = new Forms.RunCleanup(SelectedComputer);
                cleanupWindow.Show();
            }
            else
            {
                MessageBox.Show("Computer must be selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
