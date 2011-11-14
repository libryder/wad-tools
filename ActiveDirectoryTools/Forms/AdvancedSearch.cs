using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryTools
{
    public partial class AdvancedSearch : Form
    {
        
        public AdvancedSearch()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DirectoryReport.UserList.Clear();
            foreach (string name in inputBox.Lines)
            {
                if (name.Length >= 3)
                {
                    string tmp = name.Trim();
                    DirectoryReport.UserList.Add(tmp.Replace('\t', ' '));
                }
            }
            this.Close();
        }

        private void AdvancedSearch_Load(object sender, EventArgs e)
        {
            DirectoryReport.UserList.Add(null);
        }
    }
}
