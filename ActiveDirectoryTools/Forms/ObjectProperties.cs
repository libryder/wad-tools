using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using ActiveDirectoryTools.Classes;
using System.Numeric;

namespace ActiveDirectoryTools
{
    public partial class ObjectProperties : Form
    {

        public string CurrentUser = string.Empty;
        public static string NewGroup = string.Empty;
        public static Dictionary<string, string> AllGroups = new Dictionary<string, string>();

        public ObjectProperties()
        {
            InitializeComponent();
        }

        public ObjectProperties(string user)
        {
            CurrentUser = user;
            InitializeComponent();
        }

        private void ObjectProperties_Load(object sender, EventArgs e)
        {
            if (UserControls.UserFolders.Count > 0)
            {
                foreach (string userFolder in UserControls.UserFolders)
                {
                    userFolderCombo.Items.Add(userFolder);
                }
                loadUserPropertiesThread.RunWorkerAsync(CurrentUser);
            }
            if (updateGroups())
            {
                AllGroups = UserControls.getAllGroups();
                if (UserControls.isDisabled(CurrentUser))
                    userStatusLabel.Text = "[DISABLED]";
            }
            else
            {
                userBasicInfoGroup.Enabled = false;
                this.Text = "OBJECT DOES NOT EXIST";
                userStatusLabel.Text = "[BROKEN]";
            }
        }

        public bool updateGroups()
        {
            bool exists = false;
            userGroupList.Items.Clear();
            List<string> userGroups = UserControls.getAllGroups(CurrentUser);
            if (userGroups != null)
            {
                exists = true;
                userGroups.Sort();
                foreach (string group in userGroups)
                {
                    string groupConcat = group.Remove(0, 3);
                    int pos = groupConcat.IndexOf(',');
                    userGroupList.Items.Add(groupConcat.Substring(0, pos));
                }
            }
            return exists;
        }

        private void userSaveButton_Click(object sender, EventArgs e)
        {
            if (userFirstNameBox.Text.Length >= 1 && userLastNameBox.Text.Length >= 1 && userFolderCombo.Text.Length >= 1)
            {
                Dictionary<string, string> userProperties = new Dictionary<string, string>();
                userProperties.Add("description", userDescriptionBox.Text);
                userProperties.Add("samAccountName", userUserNameBox.Text);
                userProperties.Add("displayname", userDisplayNameBox.Text);
                userProperties.Add("givenname", userFirstNameBox.Text);
                userProperties.Add("sn", userLastNameBox.Text);
                userProperties.Add("userPath", CurrentUser);
                userProperties.Add("userPrincipalName", userUserNameBox.Text + "@APEX.Local");
                if (userMiddleInitBox.Text.Length > 0)
                {
                    userProperties.Add("initials", userMiddleInitBox.Text);
                }

                bool success = UserControls.updateUserAD(userProperties);
                if (success)
                {
                    userSaveButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Unkown error!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Missing required field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void loadUserPropertiesThread_DoWork(object sender, DoWorkEventArgs e)
        {
            UserControls.UserProperties = UserControls.getUserProperties(e.Argument.ToString());
        }

        private void loadUserPropertiesThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, string> userProperties = UserControls.UserProperties;

            if (userProperties.ContainsKey("userAccountControl"))
            {
                int userAccountControl = Convert.ToInt32(userProperties["userAccountControl"]);
            }
            //MessageBox.Show(userAccountControl.ToString());
            /*if (userAccountControl == 66048 || userAccountControl == 66050 || userAccountControl == 66114 || userAccountControl == 66112)
            {
                passwordNeverExpireCheck.Checked = true;
            }
            if (userAccountControl == 8389120 || userAccountControl == 8389184 || userAccountControl == 8389120 || userAccountControl == 8389186)
            {
                passwordExpiredCheck.Checked = true;
            }
            if (userAccountControl == 576 || userAccountControl == 578 || userAccountControl == 66112 || userAccountControl == 66114)
            {
                noPasswordChangeCheck.Checked = true;
            }
            if (userAccountControl == 66050 || userAccountControl == 514 || userAccountControl == 8389122 || userAccountControl == 578)
            {
                accountDisabledCheck.Checked = true;
            }*/
            
            if (userProperties.ContainsKey("displayname"))
            {
                userDisplayNameBox.Text = userProperties["displayname"];
            }
            if (userProperties.ContainsKey("givenname"))
            {
                userFirstNameBox.Text = userProperties["givenname"];
            }
            if (userProperties.ContainsKey("sn"))
            {
                userLastNameBox.Text = userProperties["sn"];
            }
            if (userProperties.ContainsKey("initials"))
            {
                userMiddleInitBox.Text = userProperties["initials"];
            }
            if (userProperties.ContainsKey("description"))
            {
                userDescriptionBox.Text = userProperties["description"];
            }
            if (userProperties.ContainsKey("topOU"))
            {
                userFolderCombo.SelectedItem = userProperties["topOU"];
            }
            if (userProperties.ContainsKey("samAccountName"))
            {
                userUserNameBox.Text = userProperties["samAccountName"];
            }
        }

        private void userCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userFirstNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            userSaveButton.Enabled = true;
        }

        private void userMiddleInitBox_KeyDown(object sender, KeyEventArgs e)
        {
            userSaveButton.Enabled = true;
        }

        private void userLastNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            userSaveButton.Enabled = true;
        }

        private void userDisplayNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            userSaveButton.Enabled = true;
        }

        private void userUserNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            userSaveButton.Enabled = true;
        }

        private void userDescriptionBox_KeyDown(object sender, KeyEventArgs e)
        {
            userSaveButton.Enabled = true;
        }

        private void userGroupAddButton_Click(object sender, EventArgs e)
        {
            Forms.SelectGroup selectGroup = new Forms.SelectGroup();
            selectGroup.ShowDialog();
            if (!NewGroup.Equals(string.Empty) && UserControls.addToGroup(CurrentUser, NewGroup))
            {
                updateGroups();
            }
        }

        private void userGroupRemButton_Click(object sender, EventArgs e)
        {
            foreach (string group in userGroupList.SelectedItems)
            {
                UserControls.remFromGroup(CurrentUser, AllGroups[group]);
            }
            updateGroups();
        }
    }
}
