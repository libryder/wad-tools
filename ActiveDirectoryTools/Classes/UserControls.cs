using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Data;
using System.Diagnostics;

namespace ActiveDirectoryTools.Classes
{
//This class will process all controls from the Users tab.

    class UserControls
    {
        const int UF_ACCOUNTDISABLE = 0x0002;
        const int UF_PASSWD_NOTREQD = 0x0020;
        const int UF_PASSWD_CANT_CHANGE = 0x0040;
        const int UF_NORMAL_ACCOUNT = 0x0200;
        const int UF_DONT_EXPIRE_PASSWD = 0x10000;
        const int UF_SMARTCARD_REQUIRED = 0x40000;
        const int UF_PASSWORD_EXPIRED = 0x800000;

        //public const string LDAPSTRING = "LDAP://OU=Apex,DC=APEX,DC=Local";
        public static List<string> UserFolders = new List<string>();
        public static string SelectedUser = string.Empty;
        public static string SelectedUserForGroup = string.Empty;
        public static List<string> UserList = new List<string>();
        public static List<string> GroupList = new List<string>();
        public static string ClipboardText = string.Empty;
        public static string TermDescription = string.Empty;
        public static List<string> GroupAddResults = new List<string>();
        public static string NewPass = string.Empty;
        public static Dictionary<string, string> UserProperties = new Dictionary<string, string>();
        public static Dictionary<string, string> CurrentUsers = new Dictionary<string, string>();
        public static Dictionary<string, string[]> CurrentDesc = new Dictionary<string, string[]>();
        public static Dictionary<string, string> BatchUsers = new Dictionary<string, string>();
        public static Dictionary<string, string> CopyUserDetails = new Dictionary<string, string>();
        /*
         * This method returns all children in the orginazational unit specified. ou="MIS"
         * will return all users in the MIS folder. It also fills a dictionary list with the
         * user and LDAP path of user so we don't have to search for the user later.
         */
        public static bool resetLockout(string displayName)
        {
            bool success = true;
            try
            {
                DirectoryEntry ldapEntry = new DirectoryEntry(CurrentUsers[displayName]);
                ldapEntry.Properties["LockOutTime"].Value = 0;
                ldapEntry.CommitChanges();
                success = true;
            }
            catch { }
            return success;
        }

        public static string getOuFromPath(string ou)
        {
            string ouPath = ou.Remove(0, 7);
            string[] ouPathReversed = ouPath.Split(',');
            string[] ouPathArr = new string[ouPathReversed.Count()];
            for (int i = ouPathReversed.Count() - 1; i >= 0; i--)
            {
                ouPathArr[ouPathReversed.Count() - 1 - i] = ouPathReversed[i];
            }

            string finalPath = string.Empty;
            foreach (string split in ouPathArr)
            {
                if (split.Substring(0, 2).ToLower().Equals("ou"))
                {
                    finalPath += split.Remove(0, 3) + @"\";
                }
            }
            int indexA = finalPath.Length;
            return finalPath.Remove(indexA-1);
        }

        public static List<string> fillUserList(string ou)
        {
            CurrentUsers.Clear();
            CurrentDesc.Clear();
            List<string> userList = new List<string>();
            string ldapString = "LDAP://" + ou + Settings.dcDn;
            SearchResultCollection results = null;

            try
            {
                DirectoryEntry users = new DirectoryEntry(ldapString);
                DirectorySearcher usersSearch = new DirectorySearcher(users);
                usersSearch.Filter = "(|(objectCategory=group)(&(objectCategory=person)(objectClass=user)))";
                results = usersSearch.FindAll();
            }
            catch (Exception e)
            {
                MessageBox.Show("Failure.\n\n" + e.ToString());
            }

            foreach (SearchResult child in results)
            {
                //this method returns the OU object is contained in OU\SubOU\SubSubOU format
                string finalPath = getOuFromPath(child.Path);

                string finalUser;
                string userToAdd = child.Path.Remove(0, 10);
                int pos = userToAdd.IndexOf(',');

                finalUser = userToAdd.Substring(0, pos);

                //sloppy way of allowing duplicate names
                while (CurrentUsers.Keys.Contains(finalUser))
                {
                    finalUser += finalUser + "_";
                }
                userList.Add(finalUser);

                string tmpDesc = string.Empty;
                string tmpUser = string.Empty;
                string tmpExt = string.Empty;

                ResultPropertyCollection childProperties = child.Properties;

                if (childProperties["description"].Count > 0)
                {
                    tmpDesc = childProperties["description"][0].ToString();
                }

                if (childProperties["telephoneNumber"].Count > 0)
                {
                    tmpExt = childProperties["telephoneNumber"][0].ToString();
                }

                if (childProperties["samAccountName"].Count > 0)
                {
                    tmpUser = childProperties["samAccountName"][0].ToString();
                }

                CurrentDesc.Add(finalUser, new string[] { tmpDesc, tmpUser, finalPath, tmpExt });
                CurrentUsers.Add(finalUser, child.Path.Remove(0, 7));
            }
            return userList;
        }

        /*
         * This method creates a publically accessible list of all top-level orginizational
         * units under Apex. ie: MIS, NIS, *Disabled, etc.
         */

        public static Dictionary<string, string> getAllGroups()
        {
            Dictionary<string, string> groups = new Dictionary<string, string>();
            DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + Settings.dcDn);
            DirectorySearcher deSearch = new DirectorySearcher(ldapEntry);
            deSearch.PropertiesToLoad.Add("cn");
            deSearch.Filter = "(&(objectClass=group)(cn=*))";
            SearchResultCollection results = deSearch.FindAll();
            string groupName;
            foreach (SearchResult group in results)
            {
                groupName = group.Path.Substring(group.Path.IndexOf('=') + 1, group.Path.IndexOf(',') - 10);
                groups.Add(groupName, group.Path.Remove(0,7));
            }

            return groups;
        }

        public static void fillUserFolder()
        {
            try
            {
                DirectoryEntry ldapentry = new DirectoryEntry(Settings.LDAPSTRING);
                foreach (DirectoryEntry child in ldapentry.Children)
                {
                    UserFolders.Add(child.Name.ToString().Remove(0,3));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        
        public static string getUserName(string userPath)
        {
            DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + userPath);
            string userName = ldapEntry.Properties["samAccountName"].Value.ToString();
            ldapEntry.Close();
            return userName;
        }

        //This method attempts to remove a user from specified OU. 
        public static bool remUserAD(string ou, string userName, string userPath)
        {
            bool success = false;
            try
            {
                string ldapString = "LDAP://" + ou + Settings.dcDn;
                DirectoryEntry ldapEntry = new DirectoryEntry(ldapString);
                DirectoryEntry userToDelete = new DirectoryEntry("LDAP://" + userPath);// ldapEntry.Children.Remove("CN=" + userName, "User");
                ldapEntry.Children.Remove(userToDelete);
                ldapEntry.CommitChanges();
                ldapEntry.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to remove user. Remove user manually. Error:\n\n" + ex.ToString(), "Removal failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return success;
        }

        public static bool updateUserAD(Dictionary<string, string> userProperties)
        {
            bool success = false;
            try
            {
                DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + userProperties["userPath"]);

                string[] ouSplit = userProperties["userPath"].Split(',');
                if (!ouSplit[0].Equals("CN=" + userProperties["displayname"]))
                {
                    ouSplit[0] = "CN=" + userProperties["displayname"];
                    string newPath = string.Empty;
                    foreach (string ouSegment in ouSplit)
                    {
                        newPath += ouSegment + ",";
                    }
                    newPath = newPath.Remove(newPath.Length - 1);
                    ldapEntry.Rename("CN=" + userProperties["displayname"]);
                    ldapEntry.CommitChanges();
                }

                foreach (string property in userProperties.Keys)
                {
                    if (!property.Equals("userPath"))
                    {
                        ldapEntry.Properties[property].Value = userProperties[property];
                    }
                }               
    
                ldapEntry.CommitChanges();
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return success;
        }
        public static bool changePassword(string userPath, string newPass)
        {
            bool success = false;
            try
            {
                DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + userPath);
                string guid = ldapEntry.Guid.ToString();
                ldapEntry.Invoke("SetPassword", new object[] { newPass });
                ldapEntry.Properties["LockOutTime"].Value = 0;
                ldapEntry.CommitChanges();
                success = true;
            }
            catch { }
            return success;
        }

        public static bool copyUserAd(string userPath, string newFirst, string newLast, string newMiddle, string newPass)
        {
            bool success = false;
            List<string> groupsToCopy = getAllGroups(userPath);
            string newDisplayName = string.Empty;

            if (newMiddle.Length < 1)
            {
                newDisplayName = newFirst + " " + newLast;
            }
            else
            {
                newDisplayName = newFirst + " " + newMiddle + " " + newLast;
            }
            
            string newUserName = newFirst.Substring(0, 1) + newLast;

            for (int i = 1; userExists(newUserName); i++)
            {
                if (newUserName.Length <= (newFirst.Length + newLast.Length))
                {
                    newUserName = newFirst.Substring(0, i) + newLast;
                }
            }
            
            string[] pathExploded = userPath.Split(',');
            string newOu = string.Empty;
            foreach (string ou in pathExploded)
            {
                if (ou.Substring(0, 3).Equals("OU="))
                {
                    newOu += ou + ",";
                }
            }
            try
            {
                DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + newOu + Settings.dcDn);
                DirectoryEntry newUser = ldapEntry.Children.Add("CN=" + newDisplayName, "user");
                CopyUserDetails.Add("path", newUser.Path);
                Dictionary<string, string> newProperties = getUserProperties(userPath);
                if (newProperties.Keys.Contains("description"))
                {
                    newUser.Properties["description"].Value = newProperties["description"];
                    CopyUserDetails.Add("description", newProperties["description"]);
                }
                else
                {
                    CopyUserDetails.Add("description", string.Empty);
                }

                newUser.Properties["displayname"].Value = newDisplayName;
                newUser.Properties["name"].Value = newDisplayName;
                newUser.Properties["givenname"].Value = newFirst;
                newUser.Properties["sn"].Value = newLast;
                newUser.Properties["samAccountName"].Value = newUserName;
                newUser.Properties["userPrincipalName"].Value = newUserName + "@" + Settings.DOMAIN;

                CopyUserDetails.Add("displayname", newDisplayName);
                CopyUserDetails.Add("samAccountName", newUserName);
                CopyUserDetails.Add("ou", getOuFromPath(newUser.Path));
                
                if (newMiddle.Length > 0)
                {
                    newUser.Properties["initials"].Value = newMiddle;
                }
                newUser.CommitChanges();

                foreach (string group in groupsToCopy)
                {
                    addToGroup(newUser.Path.Remove(0, 7), group);
                }
                newUser.CommitChanges();
                
                changePassword(newUser.Path.Remove(0, 7), newPass);
                enableAccount(newUser.Path.Remove(0, 7));

                if (CopyUserDetails.Keys.Contains("exDatabase"))
                {
                    if (!ExchangeMgmt.enableMailbox(CopyUserDetails["exDatabase"], newDisplayName))
                    {
                        MessageBox.Show("Unable to create user mailbox. Please ensure you\nhave Windows Powershell 1.0 installed.\n\n" + ExchangeMgmt.errorMessage, "Copy user", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return success;
        }

        /*
         * Attempt to add a user to AD. This method requires First Name, Last Name, Middle initial
         * (can be empty string [""]), Orginizational Unit (ie: MIS), Password, and Description.
         */        
        public static bool addUserAD(string first, string last, string middle, string ou, string pass, string description)
        {
            bool success = false;
            string userName = first.Substring(0, 1) + last;
            string fullName;
            if (middle.Equals(""))
            {
                fullName = first + " " + last;
            }
            else
            {
                fullName = first + " " + middle + " " + last;
            }

            //try alternative usernames until the username equals the length of firstname+lastname
            for (int i = 1; userExists(userName); i++)
            {
                if (userName.Length <= (first.Length + last.Length))
                {
                    userName = first.Substring(0, i) + last;
                }
            }

            if (!userExists(userName))
                try
                {
                    string guid = string.Empty;

                    //Variable 'ou' is the folder (orginizational unit) in AD which to create user
                    string ldapString = "LDAP://OU=" + ou + ",OU=" + Settings.primaryOu + "," + Settings.dcDn;
                    DirectoryEntry ldapEntry = new DirectoryEntry(ldapString);
                    DirectoryEntry newUser = ldapEntry.Children.Add("CN=" + fullName, "user");
                    newUser.Properties["samAccountName"].Value = userName;
                    newUser.Properties["displayname"].Value = fullName;
                    newUser.Properties["name"].Value = fullName;
                    newUser.Properties["givenname"].Value = first;
                    newUser.Properties["sn"].Value = last;
                    newUser.Properties["description"].Value = description;

                    //commit changes
                    newUser.CommitChanges();

                    //set password
                    guid = newUser.Guid.ToString();
                    newUser.Invoke("SetPassword", new object[] { pass });
                    newUser.CommitChanges();

                    ldapEntry.Close();
                    newUser.Close();

                    //enable account
                    enableAccount(userName);

                    success = true;
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("0x80072035"))
                    {
                        MessageBox.Show("Password does not meet requirements.\nNo changes have been made.", "Password requirement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (e.ToString().Contains("0x80071392"))
                    {
                        MessageBox.Show("User \"" + first + " " + last + "\" already exists in OU: \"" + ou + "\".\nNo Changes have been made.", "Object exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            //added for improved productivity
            ClipboardText = userName + "\r\n" + pass;
            return success;
        }

        //returns false if username doesn't exist in AD
        public static bool userExists(string user)
        {
            bool exists = false;

            try
            {
                DirectoryEntry ldapEntry = new DirectoryEntry(Settings.LDAPSTRING);
                DirectorySearcher ldapSearch = new DirectorySearcher(ldapEntry);

                ldapSearch.Filter = "(&(objectClass=user)(|(cn=" + user + ")(sAMAccountName=" + user + ")))";
                SearchResult result = ldapSearch.FindOne();

                if (result != null)
                {
                    exists = true;
                }
            }

            catch { }

            return exists;

        }
        public static void addGroupToOU(string groupDn, string ouDn)
        {
            DirectoryEntry search = new DirectoryEntry("LDAP://" + ouDn);
            DirectorySearcher newSearch = new DirectorySearcher(search);
            newSearch.Filter = "(&(objectCategory=person)(objectClass=user))";
            SearchResultCollection tmp = newSearch.FindAll();
            foreach (SearchResult result in tmp)
            {
                addToGroup(result.Path.Remove(0, 7), groupDn);
            }
        }
        
        public static Dictionary<string, string> getUserProperties(string userPath)
        {
            Dictionary<string, string> userProperties = new Dictionary<string, string>();

            try
            {
                string[] pathExploded = userPath.Split(',');
                string topOU = "";
                foreach (string tmp in pathExploded)
                {
                    topOU = tmp.Remove(0, 3);
                    if (UserFolders.Contains(topOU))
                    {
                        break;
                    }
                }
                DirectoryEntry userEntry = new DirectoryEntry("LDAP://" + userPath);
                userProperties.Add("userAccountControl", userEntry.Properties["userAccountControl"].Value.ToString());
                userProperties.Add("samAccountName", userEntry.Properties["samAccountName"].Value.ToString());
                userProperties.Add("givenname", userEntry.Properties["givenname"].Value.ToString());
                userProperties.Add("sn", userEntry.Properties["sn"].Value.ToString());
                userProperties.Add("topOU", topOU);
                userProperties.Add("cn", userEntry.Properties["cn"].Value.ToString());
                userProperties.Add("displayname", userEntry.Properties["displayname"].Value.ToString());
                //these next two try blocks throw an exception if those properties do not exist
                try
                {
                    userProperties.Add("initials", userEntry.Properties["initials"].Value.ToString());
                }
                catch { }
                try
                {
                    userProperties.Add("description", userEntry.Properties["description"].Value.ToString());
                }
                catch { }

                //userProperties.Add("samAccountName", userEntry.Properties["samAccountName"].Value.ToString());

            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
            }

            return userProperties;
        }

        public static List<string> getAllMembers(string groupDn)
        {
            List<string> userGroups = new List<string>();
            try
            {
                DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + groupDn);

                foreach (string member in ldapEntry.Properties["member"])
                {
                    userGroups.Add(member);
                }
            }
            catch { }
            return userGroups;
        }

        public static bool isValidUser()
        {
            bool auth = false;

            try
            {
                //open entry on active directory to perform a search on
                DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://OU=Apex,DC=APEX,DC=Local");

                //search for currently logged on user
                DirectorySearcher ldapSearcher = new DirectorySearcher(ldapEntry);
                ldapSearcher.Filter = "(&(objectCategory=person)(objectClass=user)(samAccountName=" + Environment.UserName + "))";

                //find first result (username is unique, so only one match can be found) and get object's path in AD
                string userPath = ldapSearcher.FindOne().Path;

                //open entry on found user using path from the search result
                DirectoryEntry userEntry = new DirectoryEntry(userPath);

                //look for group membership
                foreach (string property in userEntry.Properties["memberof"])
                {
                    if (property.Contains("Developers"))
                    {
                        auth = true;
                        break;
                    }
                }
                //cleanup
                userEntry.Close();
                ldapEntry.Close();
                ldapSearcher.Dispose();
            }

            //just in case
            catch (Exception e)
            {
                MessageBox.Show("Error:\n\n" + e);
            }

            return auth;
        }


        public static List<string> getAllGroups(string userDn)
        {
            List<string> userGroups = new List<string>();

            try
            {

                DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + userDn);

                foreach (string property in ldapEntry.Properties["memberof"])
                {
                    /* Need a way to get the primary group, as it doesn't appear in "memberof"
                     * 
                     * DirectoryEntry tmp = new DirectoryEntry("LDAP://" + property);
                    byte[] bing = tmp.Properties["objectsid"].Value as byte[];
                    MessageBox.Show("Start");
                    foreach (byte test in bing)
                    {
                        MessageBox.Show("" + test);
                    }*/
                    userGroups.Add(property);
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("There is no such object on the server."))
                {
                    userGroups = null;
                }
            }
            return userGroups;
        }

        public static bool removeAllGroups(string userDn)
        {
            bool success = false;
            try
            {
                DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + userDn);
                foreach (string property in ldapEntry.Properties["memberof"])
                {
                    remFromGroup(userDn, property);
                }
                success = true;
            }
            catch
            {
                //MessageBox.Show(e.ToString());
            }

            return success;
        }

        public static bool termUser(string userPath, string userDesc)
        {
            bool success = false;
            try
            {
                //open the directory and search for user
                string termDescription = userDesc;

                DirectoryEntry termUser = new DirectoryEntry("LDAP://" + userPath);
                termUser.Properties["description"].Value = termDescription;
                termUser.CommitChanges();

                if (!ExchangeMgmt.hideMailbox(userPath, true))
                {
                    MessageBox.Show("Failed to hide mailbox from GAL.", "GAL Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //remove all group membership
                if (!removeAllGroups(userPath))
                {
                    MessageBox.Show("Failed to remove groups.", "Group membership", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //disable account
                if (!disableAccount(userPath))
                {
                    MessageBox.Show("Failed to disable account.", "Disable account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //move user to the *Disabled OU
                DirectoryEntry moveTo = new DirectoryEntry("LDAP://" + Settings.DISABLEDOU);
                termUser.MoveTo(moveTo);
                termUser.CommitChanges();
                
                moveTo.Close();

                //if none of that fails
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
            }

            return success;
        }
        public static string findOneUserAD(string userString)
        {
            string userDn = "NONE";
            try
            {
                DirectoryEntry ldapEntry = new DirectoryEntry(Settings.LDAPSTRING);
                DirectorySearcher findUser = new DirectorySearcher(ldapEntry);
                findUser.Filter = "(&(objectCategory=person)(objectClass=user)(|(cn=" + userString + ")(samAccountName=" + userString + ")))";
                userDn = findUser.FindOne().Path.Remove(0, 7);
            }
            catch (Exception)
            {
                userDn = "NONE";
            }

            return userDn;
        }

        public static Dictionary<string, string> findGroup(string groupSearchString)
        {
            Dictionary<string, string> allGroups = getAllGroups();
            Dictionary<string, string> searchReturn = new Dictionary<string,string>();
            string[] explodedSearch = groupSearchString.Split(' ');

            foreach (string groupName in allGroups.Keys)
            {
                bool match = false;

                foreach (string singleSearch in explodedSearch)
                {
                    if (groupName.ToLower().Contains(singleSearch))
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
                    searchReturn.Add(groupName, allGroups[groupName]);
                }
            }

            return searchReturn;
        }

        public static Dictionary<string, string> exportUsers(ListView.ListViewItemCollection userList)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            string fName = "tmp.txt";
            try
            {
                TextWriter clist = new StreamWriter(fName);

                if (userList.Count <= 0)
                {
                    MessageBox.Show("Object list is empty; aborting", "Error");
                }

                foreach (ListViewItem item in userList)
                {
                    clist.WriteLine(item.SubItems[0].Text + "\t" + item.SubItems[1].Text + "\t" + item.SubItems[2].Text + "\t" + item.SubItems[3].Text + "\t" + item.SubItems[4].Text);
                }

                clist.Close();
                Process.Start("notepad", fName);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e);
            }

            return results;
        }

        public static List<string> findUserAD(string userString, bool restoreUsers)
        {
            /*if (!restoreUsers)
            {
                CurrentUsers.Clear();
                CurrentDesc.Clear();
            }*/
            List<string> userDn = new List<string>();
            string[] userExploded = userString.Split(' ');

            DirectoryEntry ldapEntry = new DirectoryEntry(Settings.LDAPSTRING);
            DirectorySearcher findUser = new DirectorySearcher(ldapEntry);

            findUser.Filter = "(&(|(objectCategory=group)(objectCategory=person))(|(sAMAccountName=*" + userExploded[0] + "*)(displayname=*" + userExploded[0] + "*)))";

            SearchResultCollection resultCollection = findUser.FindAll();
            foreach (SearchResult result in resultCollection)
            {
                string finalPath = getOuFromPath(result.Path);
                bool match = true;
                for (int i = 1; i < userExploded.Length; i++)
                {
                    if (result.Path.ToLower().Contains(userExploded[i].ToLower()))
                    {
                        match = true;
                    }
                    else
                    {
                        match = false;
                    }
                }

                if (match)
                {
                    string tmp = result.Path.Remove(0, 10);
                    int i = tmp.IndexOf(',');
                    string accountName = tmp.Substring(0, i);

                    while (CurrentUsers.Keys.Contains(accountName))
                    {
                        accountName += "_";
                    }
                    string tmpDesc = string.Empty;
                    string tmpUser = string.Empty;
                    string tmpExt = string.Empty;
                    try
                    {
                        DirectoryEntry descEntry = new DirectoryEntry(result.Path);
                        tmpDesc = descEntry.Properties["description"].Value.ToString();
                        tmpUser = descEntry.Properties["samaccountname"].Value.ToString();
                        tmpExt = descEntry.Properties["telephoneNumber"].Value.ToString();
                        descEntry.Close();
                    }
                    catch
                    {
                        DirectoryEntry descEntry = new DirectoryEntry(result.Path);

                        if (descEntry.Properties["samaccountname"].Value != null)
                        {
                            tmpUser = descEntry.Properties["samaccountname"].Value.ToString();
                        }
                        else
                        {
                            tmpUser = string.Empty;
                        }
                        descEntry.Close();
                    }
                    CurrentDesc.Add(accountName, new string[] { tmpDesc, tmpUser, finalPath, tmpExt });
                    if (!restoreUsers && !CurrentUsers.Keys.Contains(accountName))
                    {
                        CurrentUsers.Add(accountName, result.Path.Remove(0, 7));
                    }
                    userDn.Add(accountName);
                }
            }
            return userDn;
        }

        public static bool remFromGroup(string userDn, string groupDn)
        {
            bool success = false;
            try
            {
                DirectoryEntry dirEntry = new DirectoryEntry("LDAP://" + groupDn);
                dirEntry.Properties["member"].Remove(userDn);
                dirEntry.CommitChanges();
                dirEntry.Close();
                success = true;
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
            }
            return success;
        }

        public static bool moveObject(string oldDn, string newDn)
        {
            bool success = false;

            try
            {
                DirectoryEntry oldLocation = new DirectoryEntry(oldDn);
                DirectoryEntry newLocation = new DirectoryEntry(newDn);
                string name = oldLocation.Name;
                oldLocation.MoveTo(newLocation, name);
                newLocation.Close();
                oldLocation.Close();
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: \n\n" + e);
            }

            return success;
        }

        public static bool addToGroup(string userDn, string groupDn)
        {
            bool success = false;
            try
            {
                DirectoryEntry dirEntry = new DirectoryEntry("LDAP://" + groupDn);

                dirEntry.Properties["member"].Add(userDn);
                dirEntry.CommitChanges();
                dirEntry.Close();
                success = true;
            }
            catch (Exception e) 
            {
                //ignore error "Object already exists"
                if (!e.ToString().Contains("Object already exists"))
                {
                    success = true;
                }
            }
            return success;
        }
        //OU is the orginizational unit to search for user (CN) from. 
        public static bool matchUserRights(string ou, string cnFrom, string first, string last, string middle)
        {
            string cnTo;
            if (middle.Equals(""))
            {
                cnTo = first + " " + last;
            }
            else
            {
                cnTo = first + " " + middle + " " + last;
            }
            bool success = false;
            try
            {
                string ldapString = "LDAP://cn=" + cnFrom + ",OU=" + ou + ",OU=Apex,DC=APEX,DC=Local";
                DirectoryEntry ldapEntry = new DirectoryEntry(ldapString);

                foreach (string groupOU in ldapEntry.Properties["memberof"])
                {
                    addToGroup("CN=" + cnTo + ",OU=" + ou + ",OU=Apex,DC=APEX,DC=Local", groupOU);
                }
                ldapEntry.CommitChanges();
                ldapEntry.Close();
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return success;
        }


        public static string getDescription(string userPath)
        {
            string description = string.Empty;
            try
            {
                DirectoryEntry ldapEntry = new DirectoryEntry("LDAP://" + userPath);
                description = ldapEntry.Properties["description"].Value.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return description;
        }
        public static string getDescription(string user, string ou)
        {
            string description = "";
            try
            {
                if (!user.Equals("[NONE]"))
                {
                    string ldapString = "LDAP://CN=" + user + ",OU=" + ou + ",OU=Apex,DC=APEX,DC=Local";
                    DirectoryEntry ldapEntry = new DirectoryEntry(ldapString);
                    description = ldapEntry.Properties["description"].Value.ToString();

                }
            }
            //this will catch errors that are caused by an object not having a description, such as an OU
            catch { }
            return description;
        }

        /*
         * Returns true if account was successfully enabled in AD. By default user is disabled  
         * so this must be done after the user has been created. 
        */

        public static bool disableAccount(string userPath)
        {
            bool success = false;
            try
            {
                DirectoryEntry userEnable = new DirectoryEntry("LDAP://" + userPath);
                int val = (int)userEnable.Properties["userAccountControl"].Value;
                userEnable.Properties["userAccountControl"].Value = val | 0x2;

                userEnable.CommitChanges();
                userEnable.Close();
                success = true;
            }
            catch { }

            return success;

        }

        public static bool isGroup(string dn)
        {
            bool isgroup = false;
            try
            {
                DirectoryEntry obj = new DirectoryEntry("LDAP://" + dn);
                if (obj.SchemaClassName.ToString().Equals("group"))
                {
                    isgroup = true;
                }
            }
            catch { }
            return isgroup;
        }

        public static bool isDisabled(string userPath)
        {
            DirectoryEntry user = new DirectoryEntry("LDAP://" + userPath);
            bool disabled = false;
            try
            {
                int val = (int)user.Properties["userAccountControl"].Value;
                if (val == 66050 || val == 514)
                {
                    disabled = true;
                }
            }
            catch { }
            return disabled;
        }

        public static bool enableAccount(string userPath)
        {
            bool success = false;
            try
            {
                DirectoryEntry userEnable;
                if (userPath.Contains("LDAP://"))
                {
                    userEnable = new DirectoryEntry(userPath);
                }
                else
                {
                    userEnable = new DirectoryEntry("LDAP://" + userPath);
                }
                int val = (int)userEnable.Properties["userAccountControl"].Value;
                userEnable.Properties["userAccountControl"].Value = val & ~0x2; 

                userEnable.CommitChanges();
                userEnable.Close();
                success = true;
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.ToString());            
            }

            return success;

        }

        public static bool setEmployeeID(string userDn, int id)
        {
            bool success = false;
            try
            {
                DirectoryEntry employee = new DirectoryEntry("LDAP://" + userDn);
                employee.Properties["employeeID"].Value = id;
                employee.CommitChanges();
                employee.Close();
                success = true;
            }
            catch { }

            return success;
        }

        public static string getEmployeeID(string userDn)
        {
            string id = "0";
            try
            {
                DirectoryEntry employee = new DirectoryEntry("LDAP://" + userDn);
                id = employee.Properties["employeeID"].Value.ToString();
                employee.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return id;
        }
    }
}
