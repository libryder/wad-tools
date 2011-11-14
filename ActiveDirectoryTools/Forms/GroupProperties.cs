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

namespace ActiveDirectoryTools
{
    public partial class GroupProperties : Form
    {

        public string CurrentGroup = string.Empty;
        public static string NewGroup = string.Empty;
        public static Dictionary<string, string> AllMembers = new Dictionary<string, string>();

        public GroupProperties()
        {
            InitializeComponent();
        }

        public GroupProperties(string group)
        {
            CurrentGroup = group;
            InitializeComponent();
        }

        private void GroupProperties_Load(object sender, EventArgs e)
        {
            updateMembers();
        }

        public bool updateMembers()
        {
            bool exists = false;
            userGroupList.Items.Clear();
            List<string> userGroups = UserControls.getAllMembers(CurrentGroup);
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

        private void userCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userGroupAddButton_Click(object sender, EventArgs e)
        {
            SelectUserForGroup window = new SelectUserForGroup();
            window.ShowDialog();
            UserControls.addToGroup(UserControls.findOneUserAD(UserControls.SelectedUserForGroup), CurrentGroup);
            updateMembers();
        }

        private void userGroupRemButton_Click(object sender, EventArgs e)
        {
            if (userGroupList.SelectedItems.Count > 0)
            {
                foreach (string obj in userGroupList.SelectedItems)
                {
                    UserControls.remFromGroup(UserControls.findOneUserAD(obj), CurrentGroup);
                }
                updateMembers();
            }
        }
    }
}
