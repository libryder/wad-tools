using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryTools.Forms
{
    public partial class FindRep : Form
    {
        public FindRep()
        {
            InitializeComponent();
        }

        Dictionary<string, string[]> repResults = new Dictionary<string, string[]>();

        private void searchButton_Click(object sender, EventArgs e)
        {
            resultsCheckListBox.Items.Clear();
            int i = 0;
            int j = 0;
            foreach (string searchLine in searchTextBox.Lines)
            {
                if (searchLine.Length >= 3)
                {

                    if (searchRegionalCheck.Checked)
                    {
                        repResults = DirectoryReport.findRepPass(searchLine, true);
                    }
                    else
                    {
                        repResults = DirectoryReport.findRepPass(searchLine, false);
                    }
                    foreach (string user in repResults.Keys)
                    {
                        string[] userAndPass = repResults[user];
                        resultsCheckListBox.Items.Add(user + "\t" + userAndPass[0] + "\t" + userAndPass[1]);
                        i++;
                    }
                    
                    j++;
                }
            }
            resultsLabel.Text = "Results: " + i;
            namesLabel.Text = "Names: " + j;
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            string clipboardText = string.Empty;
            if (resultsCheckListBox.CheckedItems.Count >= 1)
            {
                foreach (string userPass in resultsCheckListBox.CheckedItems)
                {
                    clipboardText += userPass + "\r\n";
                }
                Clipboard.SetText(clipboardText);
                MessageBox.Show("Login information is now in your clipboard.", "Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("At least one item must be checked.", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void resultsCheckListBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void FindRep_Load(object sender, EventArgs e)
        {
            resultsCheckListBox.CheckOnClick = true;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            resultsCheckListBox.Items.Clear();
            searchTextBox.Clear();
            resultsLabel.Text = "Results: 0";
            namesLabel.Text = "Names: 0";
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < resultsCheckListBox.Items.Count; i++)
            {
                resultsCheckListBox.SetItemCheckState(i, CheckState.Checked);
            }
        }
    }
}
