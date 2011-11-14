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
    public partial class SetPassword : Form
    {
        public SetPassword()
        {
            InitializeComponent();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void defaultCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultCheck.Checked)
            {
                passwordBox.Text = "Password1";
                passwordConfirmBox.Text = "Password1";
            }
            else
            {
                passwordBox.Text = "";
                passwordConfirmBox.Text = "";
            }
        }

        private void SetPassword_Load(object sender, EventArgs e)
        {
            UserControls.NewPass = string.Empty;
        }
        private void Execute()
        {
            if (passwordBox.Text.Equals(passwordConfirmBox.Text) && passwordBox.Text.Length > 0)
            {
                UserControls.NewPass = passwordBox.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Passwords do not match or are empty.", "Set password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Execute();
            }

        }
    }
}
