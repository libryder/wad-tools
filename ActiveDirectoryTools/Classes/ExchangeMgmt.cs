using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Windows.Forms;
using System.DirectoryServices;

namespace ActiveDirectoryTools
{
    class ExchangeMgmt
    {
        public static string errorMessage = string.Empty;
        public static Dictionary<string, string> Databases = new Dictionary<string, string>();

        public static Dictionary<string, string> getExchangeDatabases()
        {
            Dictionary<string, string> mailBoxPaths = new Dictionary<string, string>();
            string mailBoxesPath = "CN=InformationStore,CN=Mailbox,CN=Servers,CN=Exchange Administrative Group (FYDIBOHF23SPDLT)," +
                "CN=Administrative Groups,CN=APEX,CN=Microsoft Exchange,CN=Services,CN=Configuration,DC=APEX,DC=Local";

            DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + mailBoxesPath);            
            foreach (DirectoryEntry entry in ldapEntry.Children)
            {
                foreach (DirectoryEntry rootEntry in entry.Children)
                {
                    mailBoxPaths.Add(rootEntry.Name, @"Mailbox\" + rootEntry.Name.Remove(0, 3) + @"\" + rootEntry.Name.Remove(0, 3));
                }
            }
            return mailBoxPaths;
        }

        public static bool hideMailbox(string userPath, bool hide)
        {
            bool success = false;
            try
            {
                RunspaceConfiguration config = RunspaceConfiguration.Create();
                PSSnapInException warning;

                config.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.Admin", out warning);
                if (warning != null) throw warning;

                Runspace exRunSpace = RunspaceFactory.CreateRunspace(config);
                exRunSpace.Open();

                Pipeline exPipeline = exRunSpace.CreatePipeline();
                exPipeline.Commands.Add("Set-Mailbox");
                exPipeline.Commands[0].Parameters.Add("Identity", userPath);
                exPipeline.Commands[0].Parameters.Add("hiddenfromaddresslistsenabled", hide);

                exPipeline.Invoke();
                exPipeline.Dispose();
                exRunSpace.Close();
                success = true;
            }

            catch { }
            
            return success;
        }

        public static bool enableMailbox(string database, string identity)
        {
            bool success = false;
            try
            {
                RunspaceConfiguration config = RunspaceConfiguration.Create();
                PSSnapInException warning;

                //using exchange powershell snap-in to create mailbox
                config.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.Admin", out warning);
                if (warning != null) throw warning;

                Runspace exRunSpace = RunspaceFactory.CreateRunspace(config);
                exRunSpace.Open();
                Pipeline exPipeline = exRunSpace.CreatePipeline();

                exPipeline.Commands.Add("Enable-Mailbox");
                exPipeline.Commands[0].Parameters.Add("Database", database);
                exPipeline.Commands[0].Parameters.Add("identity", identity);

                exPipeline.Invoke();
                exPipeline.Dispose();
                exRunSpace.Close();
                success = true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message.ToString();
            }
            
            return success;
        }

        public static bool disableMailbox(string identity)
        {
            bool success = false;
            try
            {
                RunspaceConfiguration config = RunspaceConfiguration.Create();
                PSSnapInException warning;

                //using exchange powershell snap-in to create mailbox
                config.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.Admin", out warning);
                if (warning != null) throw warning;

                Runspace exRunSpace = RunspaceFactory.CreateRunspace(config);
                exRunSpace.Open();
                Pipeline exPipeline = exRunSpace.CreatePipeline();

                exPipeline.Commands.Add("Disable-Mailbox");
                exPipeline.Commands[0].Parameters.Add("identity", identity);

                exPipeline.Invoke();
                exPipeline.Dispose();
                exRunSpace.Close();
                success = true;
            }
            catch (Exception e)
            {
                errorMessage = e.ToString();
            }

            return success;
        }
    }
}
