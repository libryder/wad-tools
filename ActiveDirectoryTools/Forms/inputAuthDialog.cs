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
    public partial class inputAuthDialog : Form
    {
        public inputAuthDialog()
        {
            InitializeComponent();
        }

        private void sendUserPassButton_Click(object sender, EventArgs e)
        {
            sendUserPass(sender, e);
        }

        private void sendUserPass(object sender, EventArgs e)
        {
            bool authenticated = DirectoryReport.IsAuthenticated("LDAP://apex.local", userTextBox.Text, passTextBox.Text);
            MainWindow.setData(userTextBox.Text, passTextBox.Text, authenticated);
            this.Close();
        }
        
        private void inputAuthDialog_Load(object sender, EventArgs e)
        {

        }

        private void sendUserPassButton_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void passTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                sendUserPass(sender, e);
            }
        }

        private void passTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
