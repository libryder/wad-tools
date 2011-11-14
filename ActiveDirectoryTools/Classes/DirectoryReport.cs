using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Management;
using System.Net;
using System.Security;
using ActiveDirectoryTools.Classes;
using System.Data;

namespace ActiveDirectoryTools
{
    class DirectoryReport
    {
        public static string ObjectType;
        public static List<string> UserList = new List<string>();
        public static Dictionary<string, string> ObjectList = new Dictionary<string, string>();
        public static Dictionary<string, string> SearchList = new Dictionary<string, string>();
        public static List<string> UserFolders = new List<string>();
        

        public static bool DownloadFile(string fileloc, string saveto)
        {
            MessageBox.Show("downloading " + fileloc + " to " + saveto);
            bool success = false;
            try
            {
                WebClient getFile = new WebClient();
                getFile.DownloadFile(fileloc, saveto);
                success = true;
            }
            catch
            {
                
            }

            return success;
        }

        public static void clearObjectList()
        {
            //ObjectList.Clear();
        }

        public static void setObjectType(string objectType)
        {
            ObjectType = objectType;
        }

        public static bool getDirectoryReport(string objectType, string search)
        {
            bool success = false;
            if (!search.Equals("null"))
            {
                SearchList = searchList(objectType, search);
                ObjectList = SearchList;
                success = true;
            }
            else if (Directory.Exists(MainWindow.DEPSDIR) && objectType.Equals("Workstations"))
            {
                try
                {
                    UserControls.fillUserFolder();

                    ObjectList = getDirectoryInfo("OU=" + objectType);
                    success = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Not Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ObjectList = new Dictionary<string, string>();
                }
            }
            return success;
        }

        public static string convertDecToSize(decimal number)
        {
            string freeSpaceFinal = null;
            if (number > 1024) //convert to KB
            {
                number = Math.Round(number / 1024, 2);
                if (number > 1024) //convert to MB
                {
                    number = Math.Round(number / 1024, 2);
                    if (number > 1024) //convert to GB
                    {
                        number = Math.Round(number / 1024, 2);
                        freeSpaceFinal = number + " GB";
                    }
                    else freeSpaceFinal = number + " MB";
                }
                else freeSpaceFinal = number + " KB";
            }
            else freeSpaceFinal = number + " B";

            return freeSpaceFinal;
        }

         //this method is a mystery
        public static decimal getFreeDiskSpace(string computer)
        {
            ConnectionOptions opt = new ConnectionOptions();
            ObjectQuery oQuery = new ObjectQuery("SELECT Size, FreeSpace, Name, FileSystem FROM Win32_LogicalDisk WHERE DriveType = 3");

            ManagementScope scope = new ManagementScope(@"\\" + computer + @"\root\cimv2", opt);
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(scope, oQuery);
            ManagementObjectCollection collection = moSearcher.Get();

            decimal freeSpace = 0;
            foreach (ManagementObject res in collection)
            {
                freeSpace = Convert.ToDecimal(res["FreeSpace"]);
            }
            return freeSpace;
        }

        public static Dictionary<string, string[]> findRepPass(string searchString, bool searchByRegional)
        {
            Dictionary<string, string[]> results = new Dictionary<string, string[]>();
            if (searchString.Length >= 3)
            {
                TextReader techReps = new StreamReader(MainWindow.DEPSDIR + "reps.txt");

                string[] nameSplit = searchString.ToLower().Split(' ');
                string[] splitReadLine;
                string[] stringToSearch;
                string fullReadLine;

                while ((fullReadLine = techReps.ReadLine()) != null)
                {

                    splitReadLine = fullReadLine.Split('\t');
                    if (searchByRegional)
                    {
                        stringToSearch = new string[] { splitReadLine[0], splitReadLine[1], splitReadLine[2] };
                    }
                    else
                    {
                        stringToSearch = new string[] { splitReadLine[3], splitReadLine[4] };
                    }
                    bool match = false;


                    for (int i = 0; i < stringToSearch.Length; i++)
                    {
                        foreach (string searchField in nameSplit)
                        {
                            if (stringToSearch[i].ToLower().Contains(searchField.ToLower()))
                            {
                                match = true;
                            }
                            else
                            {
                                match = false;
                                break;
                            }
                        }
                        if (match)
                        {
                            break;
                        }
                    }

                    if (match)
                    {
                        string[] userAndPass = new string[] { splitReadLine[4], splitReadLine[5] };
                        string keyToAdd = splitReadLine[3];
                        while (results.Keys.Contains(keyToAdd))
                        {
                            keyToAdd += "_";
                        }
                        results.Add(keyToAdd, userAndPass);
                    }
                }
                techReps.Close();
            }
            return results;
        }

        /*this method is called if no connection can be made to AD. It loads
         * an object list from a txt file if it exists*/
        public static List<string> importComputerList(string fileName)
        {
            List<string> importedFileItems = new List<string>();
            TextReader importedFileStream = new StreamReader(fileName);
            String line;
            int i = 0;
            while ((line = importedFileStream.ReadLine()) != null)
            {
                importedFileItems.Add(line);
                i++;
            }
            importedFileStream.Close();
            return importedFileItems;
        }


        
        //authenticate user against active directory
        public static bool IsAuthenticated(string server, string user, string pass)
        {
            bool success = false;

            try
            {
                DirectoryEntry entry = new DirectoryEntry(server, user, pass);
                object nativeObject = entry.NativeObject;
                success = true;
            }

            catch (Exception e)
            {
                if (e.ToString().ToLower().Contains("bad password"))
                {
                    MessageBox.Show("You have entered an incorrect username/password combination", "Authentication failure", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("An unknown error has occurred: \n\n" + e, "Unknown error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return success;
        }

        public static void updateExtensions(string fName)
        {
            string line = string.Empty;
            string user = string.Empty;
            string ext = string.Empty;
            try
            {
                TextReader clist = new StreamReader(fName);

                while ((line = clist.ReadLine()) != null)
                {
                    string[] lineSplit = line.Split('\t');
                    string foundUser = UserControls.findOneUserAD(lineSplit[1]);
                    if (!foundUser.Equals("NONE"))
                    {
                        DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + foundUser);
                        ldapEntry.Properties["telephoneNumber"].Value = lineSplit[0].ToString();
                        ldapEntry.CommitChanges();
                        ldapEntry.Close();
                        //MessageBox.Show(ldapEntry.Name);
                    }
                }

                clist.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:\n\n" + e);
            }
        }


        //method to export contents of listbox to text file
        public static void exportToTxtFile(string fName, List<string> listObjects)
        {
            try
            {
                TextWriter clist = new StreamWriter(fName);

                if (listObjects.Count <= 0)
                {
                    MessageBox.Show("Object list is empty; aborting", "Error");
                }

                for (int i = 0; i < listObjects.Count; i++)
                {
                    clist.WriteLine(listObjects[i]);
                }

                clist.Close();
                Process.Start("notepad", fName);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e);
            }
        }

        //this method returns a list that contains directory objects

        public static Dictionary<string, string> getComputers(string ou)
        {
            Dictionary<string, string> objectNames = new Dictionary<string, string>();

            try
            {
                DirectoryEntry ldapEntry = new DirectoryEntry(ou);
                foreach (DirectoryEntry child in ldapEntry.Children)
                {
                    if (child.Properties["objectcategory"][0].ToString().ToLower().Contains("computer"))
                    {
                        objectNames.Add(child.Name.Remove(0, 3), UserControls.getOuFromPath(child.Path));
                    }
                }
            }
            catch { }

            return objectNames;
        }

        public static Dictionary<string, string> getDirectoryInfo(string ou)
        {
            int totalComputers = 0;
            Dictionary<string, string> objectNames = new Dictionary<string, string>();
            //build list of computers
            try
            {
                foreach (string path in Settings.ComputersArr)
                {
                    DirectoryEntry ldapentry = new DirectoryEntry(path);
                    foreach (DirectoryEntry child in ldapentry.Children)
                    {
                        if (child.Properties["objectcategory"][0].ToString().ToLower().Contains("computer"))
                        {
                            objectNames.Add(child.Name.Remove(0, 3), UserControls.getOuFromPath(child.Path));
                            totalComputers++;
                        }
                    }
                    ldapentry.Close();
                }
                ObjectList = objectNames;
            }
            catch (EntryPointNotFoundException e)
            {
                MessageBox.Show("There was a problem querying directory:\n\n" + e, "Error in query", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return objectNames;
        }

        //perform a search on the item objectType 
        public static Dictionary<string, string> searchList(string filter, string objectType)
        {
            Dictionary<string, string> newList = new Dictionary<string, string>();

            try
            {
                foreach (string path in Settings.ComputersArr)
                {
                    DirectoryEntry ldapentry = new DirectoryEntry(path);
                    foreach (DirectoryEntry child in ldapentry.Children)
                    {
                        if (child.Name.ToLower().Contains(filter) && child.Properties["objectcategory"][0].ToString().ToLower().Contains("computer"))
                        {
                            newList.Add(child.Name.Remove(0, 3), child.Path);
                        }
                    }
                    ldapentry.Close();
                }
                SearchList = newList;
                ObjectList = newList;
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot connect to domain controller.\n\n" + e.ToString(), "Problem connecting", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return newList;
        }
        
        public static bool remoteInstall(string computer, string program)
        { 
            bool success = false;

            if (program.Equals("MS Paint")) try
                {
                    string fileToCopy = @"\\" + computer + @"\c$\windows\system32\mspaint.exe";
                    string linkToCopy = @"\\" + computer + @"\c$\documents and settings\all users\start menu\programs\accessories\Paint.lnk";

                    if (!File.Exists(fileToCopy) || !File.Exists(linkToCopy))
                    {
                        File.Copy(MainWindow.DEPSDIR + "mspaint.exe", fileToCopy, true);
                        File.Copy(MainWindow.DEPSDIR + "Paint.lnk", linkToCopy, true);
                        success = true;
                    }
                    else
                    {
                        MessageBox.Show("Program already installed.", "No action taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            else if (program.Equals("MapPoint 2009"))
            {
                string installPath = @"\\vault\Software\ Mappoint 2009\Setup.exe";
                SecureString securePass = new SecureString();

                char[] tmpPass = MainWindow.PassData.ToCharArray();
                for (int i = 0; i < tmpPass.Length; i++)
                {
                    securePass.AppendChar(tmpPass[i]);
                }

                Process mapPoint = new Process();
                mapPoint.StartInfo.UserName = MainWindow.UserData;
                mapPoint.StartInfo.Password = securePass;
                mapPoint.StartInfo.Domain = "APEX";
                Process.Start("psexec", @"\\" + computer + " " + installPath);
            }

            return success;
        }

        public static bool powerShellInstalled()
        {
            bool installed = false;

            if (Directory.Exists(Environment.SystemDirectory + @"\WindowsPowerShell"))
            {
                installed = true; 
            }
            return installed;
        }

        public static string findUserFolder(string searchFor)
        {
            string rootPath = @"\\ratchet\users\";
            string path = string.Empty;
            foreach (string dir in Directory.GetDirectories(rootPath))
            {
                foreach (string subDir in Directory.GetDirectories(dir))
                {
                    int pos = subDir.LastIndexOf("\\");
                    string folderName = subDir.Substring(pos).Remove(0,1);

                    if (folderName.ToLower().Equals(searchFor.ToLower()))
                    {
                        path = subDir;
                        break;
                    }
                    if (!path.Equals(string.Empty))
                    {
                        break;
                    }
                }
            }


            return path;
        }
    }
}
   