using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;


namespace ActiveDirectoryTools
{
    public partial class ElevateExplorer : Form
    {
        private string User;
        SecureString SecurePass = new SecureString();
        
        public ElevateExplorer()
        {
            InitializeComponent();
        }

        private void launchExplorer()
        {
            char[] tmpPass = passTextBox.Text.ToCharArray();
            for (int i = 0; i < tmpPass.Length; i++) 
            {
                SecurePass.AppendChar(tmpPass[i]);
            }

            try
            {
                Process proc = new Process();
                proc.StartInfo.UserName = User;
                proc.StartInfo.Password = SecurePass;
                proc.StartInfo.Domain = "apex";
                proc.StartInfo.FileName = "explorer.exe";
                proc.StartInfo.Arguments = @"/e,/select,z:\";
                proc.StartInfo.UseShellExecute = false;
                proc.Start();

                this.Close();
            }
            catch (Exception en)
            {
                MessageBox.Show("You cannot be authenticated: " + en.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            launchExplorer();
        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {
            User = userTextBox.Text;
        }

        private void passTextBox_TextChanged(object sender, EventArgs e)
        {
            //SecurePass =  "";

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                launchExplorer();
            }
        }

    }
}
