using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveDirectoryTools.Classes;

namespace ActiveDirectoryTools.Forms
{
    public partial class SelectGroup : Form
    {
        public static Dictionary<string, string> AllGroups = new Dictionary<string, string>();

        public SelectGroup()
        {
            InitializeComponent();
        }

        private void SelectGroup_Load(object sender, EventArgs e)
        {
            AllGroups = UserControls.getAllGroups();
        }

        private void groupOkButton_Click(object sender, EventArgs e)
        {
            ObjectProperties.NewGroup = AllGroups[groupListBox.Text];
            this.Close();
        }

        private void groupCancelButton_Click(object sender, EventArgs e)
        {
            ObjectProperties.NewGroup = string.Empty;
            this.Close();
        }

        private void groupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupOkButton.Enabled = true;
        }

        private void groupListBox_DoubleClick(object sender, EventArgs e)
        {
            ObjectProperties.NewGroup = AllGroups[groupListBox.Text];
            this.Close();
        }

        private void applySearchFilter()
        {
            List<string> searchResultGroups = UserControls.findGroup(groupSearchBox.Text).Keys.ToList();
            searchResultGroups.Sort();
            foreach (string group in searchResultGroups)
            {
                groupListBox.Items.Add(group);
            }
            if (searchResultGroups.Count == 1)
            {
                ObjectProperties.NewGroup = AllGroups[searchResultGroups[0]];
                this.Close();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            applySearchFilter();
        }

        private void groupSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                applySearchFilter();
            }
        }

    }
}
