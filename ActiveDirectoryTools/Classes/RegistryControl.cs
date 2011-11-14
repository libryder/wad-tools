using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Windows.Forms;

[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum, ViewAndModify = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Terminal Server")]
[assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum,  Unrestricted = true)]

namespace ActiveDirectoryTools
{
    class RegistryControl
    {
        public static bool checkRdEnabled(string computer)
        {
            bool success = false;
            RegistryKey environmentKey;
            try
            {
                environmentKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine,
                    computer).OpenSubKey(@"System\CurrentControlSet\Control\Terminal Server", RegistryKeyPermissionCheck.ReadWriteSubTree);
                foreach (string value in environmentKey.GetValueNames())
                {
                    if (value.Equals("fDenyTSConnections") && environmentKey.GetValue(value).ToString().Equals("0"))
                    {
                        success = true;
                    }
                }
            }
            catch
            {
                success = false;
            }

            return success;
        }


        public static bool changeRemoteDesktop(string computer, string setto)
        {
            //if setto = 1 remote desktop will be disabled. 0 will enable
            //the return of this function will help the calling member to determine if the operation was a success
            bool success = false;
            RegistryKey environmentKey;
            try
            {
                environmentKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine,
                    computer).OpenSubKey(@"System\CurrentControlSet\Control\Terminal Server", RegistryKeyPermissionCheck.ReadWriteSubTree);
                foreach (string value in environmentKey.GetValueNames())
                {
                    if (value.Equals("fDenyTSConnections"))
                    {
                        environmentKey.SetValue(value, setto, RegistryValueKind.DWord);
                        //check to verify the change was made
                        if (environmentKey.GetValue(value).ToString().Equals(setto))
                        {
                            success = true;
                        }
                    }
                }

                environmentKey.Close();
            }
            catch
            {
                success = false;
            }

            return success;

        }

    }
}
