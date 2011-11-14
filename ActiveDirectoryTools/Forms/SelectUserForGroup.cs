using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveDirectoryTools.Classes;

namespace ActiveDirectoryTools
{
    public partial class SelectUserForGroup : Form
    {
        public string selectedUser = string.Empty;

        public SelectUserForGroup()
        {
            InitializeComponent();
        }

        private void findUserButton_Click(object sender, EventArgs e)
        {
            applyUserSearchFilter();
        }

        private void applyUserSearchFilter()
        {
            if (findUserText.Text.Length < 3)
            {
                MessageBox.Show("Please make your search more specific.", "Too vague", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                userResultBox.Items.Clear();
                backgroundUserSearch.RunWorkerAsync(findUserText.Text);
            }
        }

        private void backgroundUserSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            UserControls.GroupList = UserControls.findUserAD(e.Argument.ToString(), true);
            UserControls.GroupList.Sort();
        }

        private void backgroundUserSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (string result in UserControls.GroupList)
            {
                userResultBox.Items.Add(result);
            }

            if (userResultBox.Items.Count > 1)
            {
                userResultBox.SelectedIndex = 0;
                userResultBox.Focus();
            }
            else if (userResultBox.Items.Count == 1)
            {
                UserControls.SelectedUserForGroup = userResultBox.Items[0].ToString();
                this.Close();
            }
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userResultBox_DoubleClick(object sender, EventArgs e)
        {
            UserControls.SelectedUserForGroup = userResultBox.SelectedItem.ToString();
            this.Close();
        }

        private void findUserText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                applyUserSearchFilter();
            }
        }
    }
}
