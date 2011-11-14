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
    public partial class CopyUser : Form
    {
        private static Dictionary<string, string> exchangeDatabases = new Dictionary<string, string>();

        public CopyUser()
        {
            InitializeComponent();
        }

        private void CopyUser_Load(object sender, EventArgs e)
        {
            exchangeDatabases = ExchangeMgmt.getExchangeDatabases();
            foreach (string exDatabase in exchangeDatabases.Keys)
            {
                exchangeDropDown.Items.Add(exDatabase.Remove(0,3));
            }
            exchangeDropDown.SelectedIndex = 0;

            //this will allow us to check if the form was cancelled
            UserControls.CopyUserDetails["INCOMPLETE"] = string.Empty;
            firstBox.Focus();
        }

        private void defaultPassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultPassCheck.Checked)
            {
                passwordBox.Text = "Password1";
                passwordVerifyBox.Text = "Password1";
                passwordBox.Enabled = false;
                passwordVerifyBox.Enabled = false;
            }
            else
            {
                passwordBox.Text = "";
                passwordVerifyBox.Text = "";
                passwordBox.Enabled = true;
                passwordVerifyBox.Enabled = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text.Equals(passwordVerifyBox.Text))
            {
                if (passwordBox.Text.Length > 0 && firstBox.Text.Length > 0 && lastBox.Text.Length > 0)
                {
                    UserControls.CopyUserDetails.Remove("INCOMPLETE");
                    UserControls.CopyUserDetails["password"] = passwordBox.Text;
                    UserControls.CopyUserDetails["first"] = firstBox.Text;
                    UserControls.CopyUserDetails["middle"] = middleBox.Text;
                    UserControls.CopyUserDetails["last"] = lastBox.Text;
                    if (exchangeCheck.Checked)
                    {
                        UserControls.CopyUserDetails["exDatabase"] = exchangeDatabases["CN=" + exchangeDropDown.Text];
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("First and last name must be filled out.", "User copy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match.", "Copy users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exchangeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (exchangeCheck.Checked)
            {
                exchangeDropDown.Enabled = true;
            }
            else
            {
                exchangeDropDown.Enabled = false;
            }
        }
    }
}
