using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ActiveDirectoryTools
{
    static class Program
    {
        public static String mode = String.Empty;
        [STAThread]
        static void Main()
        {
            //how should application run? Modes = domain or workstation
            if (Classes.DomainTools.isInDomain())
            {
                mode = "domain";
                string userDn = Classes.UserControls.findOneUserAD(Environment.UserName);

                List<string> userGroups = Classes.UserControls.getAllGroups(userDn);
                bool isAdmin = false;
                foreach (string group in userGroups)
                {
                    if (group.Contains("Account Operators") || group.Contains("Domain Admins"))
                    {
                        isAdmin = true;
                        break;
                    }
                }

                if (!isAdmin)
                {
                    MessageBox.Show("You must be a domain admin to run this application.", "Insufficient rights", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                else
                {
                    Classes.Settings.initializeSettings();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainWindow());
                }
            }
            else
            {
                mode = "workstation";
            }

        }
    }
}
