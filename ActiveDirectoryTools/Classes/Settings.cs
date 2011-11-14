using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryTools.Classes
{
    class Settings
    {
        public static string DC = string.Empty;
        public static string primaryOu = string.Empty;
        public static string dcDn = string.Empty;
        public static string LDAPSTRING = string.Empty;
        public static string DOMAIN = string.Empty;
        public static string DISABLEDOU = string.Empty;
        public static string ComputersDN = string.Empty;
        public static string[] ComputersArr = null;
        public static string[] ComputerSearchArr = null;

        public static bool initializeSettings()
        {
            /*MessageBox.Show("" + Properties.Settings.Default.Properties["domain"].ToString());
            DC = Properties.Settings.Default.Properties["domain"].ToString();
            primaryOu = Properties.Settings.Default.Properties["primaryOu"].ToString();

            foreach (string dc in DC.Split('.'))
            {
                dcDn += "DC=" + dc + ",";
            }*/
            primaryOu = "Apex";
            dcDn = "DC=APEX,DC=Local";
            LDAPSTRING = "LDAP://OU=" + primaryOu + "," + dcDn;
            DOMAIN = "APEX.Local";
            DISABLEDOU = "OU=*Disabled,OU=Apex,DC=APEX,DC=Local";
            ComputersDN = "OU=Workstations,OU=Apex,DC=APEX,DC=Local";
            ComputersArr = new string[] { "LDAP://OU=Workstations,OU=Apex,DC=APEX,DC=Local", "LDAP://OU=Call Center,OU=Workstations,OU=Apex,DC=APEX,DC=Local" };

            return true;

        }
    }
}
