using System;
using System.Linq;
using System.Management;
using System.DirectoryServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ActiveDirectoryTools
{
    static class RemoteConnect
    {
        public static Dictionary<string, string> Computers = new Dictionary<string, string>();
        public static string[] SearchArray = new string[] { "Model", "UserName", "Status", "TotalPhysicalMemory", "Name" };
        public static List<ListViewItem> ResultList = new List<ListViewItem>();
        public static int Count = 0;
        public static ListViewItem CurrentRow = new ListViewItem();
        public static Dictionary<string, int> Summary = new Dictionary<string, int>();
        public static bool pauseRequest = false;
        public static bool cancelRequest = false;
        public static DataTable ComputerTable;

        public static void importDatabase()
        {
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\ironhide\public\Departments\MIS\Remote Management\Dependencies\CompDATA.accdb";
            string query = "SELECT * FROM MyTable";
            CompDATADataSet myDataSet = new CompDATADataSet();
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, new OleDbConnection(connString));
            
            MessageBox.Show(myDataSet.Tables["main"].Rows[0].ToString());
            dAdapter.Update(ComputerTable);
        }

        public static bool syncDatabase()
        {
            bool success = false;
            
            try
            {
                CompDATADataSet myDataSet = new CompDATADataSet();
                CompDATADataSetTableAdapters.mainTableAdapter mainTableAdapter = new ActiveDirectoryTools.CompDATADataSetTableAdapters.mainTableAdapter();

                mainTableAdapter.Update(myDataSet);
                success = true;
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
            }

            return success;
        }

        public static void createDataTable()
        {
            ComputerTable = MakeNamesTable();
            /*OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=\\ironhide\public\Departments\MIS\Remote Management\Dependencies\CompDATA.mdb");
            
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand("SELECT * from main", conn);
            adapter.SelectCommand = command;
            OleDbCommandBuilder cb = new OleDbCommandBuilder(adapter);*/
        }

        public static DataTable MakeNamesTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable namesTable = new DataTable("main");
            // Add three column objects to the table.
            
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = System.Type.GetType("System.Int32");
            idColumn.ColumnName = "id";
            idColumn.AutoIncrement = true;
            namesTable.Columns.Add(idColumn);

            DataColumn compNameCol = new DataColumn();
            compNameCol.DataType = System.Type.GetType("System.String");
            compNameCol.ColumnName = "compname";
            compNameCol.DefaultValue = string.Empty;
            namesTable.Columns.Add(compNameCol);

            DataColumn modelCol = new DataColumn();
            modelCol.DataType = System.Type.GetType("System.String");
            modelCol.ColumnName = "model";
            modelCol.DefaultValue = string.Empty;
            namesTable.Columns.Add(modelCol);

            DataColumn memoryCol = new DataColumn();
            memoryCol.DataType = System.Type.GetType("System.String");
            memoryCol.ColumnName = "memory";
            memoryCol.DefaultValue = string.Empty;
            namesTable.Columns.Add(memoryCol);

            DataColumn usernameCol = new DataColumn();
            usernameCol.DataType = System.Type.GetType("System.String");
            usernameCol.ColumnName = "username";
            usernameCol.DefaultValue = string.Empty;
            namesTable.Columns.Add(usernameCol);

            DataColumn statusCol = new DataColumn();
            statusCol.DataType = System.Type.GetType("System.String");
            statusCol.ColumnName = "status";
            statusCol.DefaultValue = string.Empty;
            namesTable.Columns.Add(statusCol);

            DataColumn freespaceCol = new DataColumn();
            freespaceCol.DataType = System.Type.GetType("System.String");
            freespaceCol.ColumnName = "freespace";
            freespaceCol.DefaultValue = string.Empty;
            namesTable.Columns.Add(freespaceCol);

            DataColumn servicetagCol = new DataColumn();
            servicetagCol.DataType = System.Type.GetType("System.String");
            servicetagCol.ColumnName = "servicetag";
            servicetagCol.DefaultValue = string.Empty;
            namesTable.Columns.Add(servicetagCol);
            
            DataColumn[] keys = new DataColumn[1];
            keys[0] = compNameCol;
            namesTable.PrimaryKey = keys;
            
            return namesTable;
        }


        public static bool updateRow(string computer)
        {
            object[] data = new object[] { false, -1 };
            bool contained = false;
            foreach (DataRow row in ComputerTable.Rows)
            {
                if (row.ItemArray[0].ToString().ToLower().Contains(computer.ToLower()))
                {
                    ComputerTable.Rows.Remove(row);
                    contained = true;
                    break;
                }
            }
            return contained;
        }

        public static bool updateDatabase(ListViewItem row)
        {

            bool success = false;

            foreach (DataRow rowSearch in ComputerTable.Rows)
            {
                if (rowSearch.ItemArray[0].ToString().ToLower().Contains(row.Text.ToLower()))
                {
                    ComputerTable.Rows.Remove(rowSearch);
                    break;
                }
            }
            
            object[] rowToAdd = new object[] { row.SubItems[0].Text, row.SubItems[1].Text, row.SubItems[2].Text, row.SubItems[3].Text, row.SubItems[4].Text, row.SubItems[5].Text, row.SubItems[6].Text };
            
            DataRow myRow = ComputerTable.NewRow();

            int index = 0;
            if (ComputerTable.Rows.Count > 0)
            {
                index = ComputerTable.Rows.Count - 1;
            }

            // Then add the new row to the collection.
            myRow["compname"] = row.SubItems[0].Text;
            myRow["model"] = row.SubItems[1].Text;
            myRow["memory"] = row.SubItems[2].Text;
            myRow["username"] = row.SubItems[3].Text;
            myRow["status"] = row.SubItems[4].Text;
            myRow["freespace"] = row.SubItems[5].Text;
            myRow["servicetag"] = row.SubItems[6].Text;
            ComputerTable.Rows.InsertAt(myRow, index);

            //dataGrid1.DataSource = myTable;            

            return success;
        }

        public static bool isInArray(string searchString, string[] arrayToSearch)
        {
            bool match = false;

            int strNumber;
            int strIndex = 0;
            for (strNumber = 0; strNumber < arrayToSearch.Length; strNumber++)
            {
                strIndex = arrayToSearch[strNumber].IndexOf(searchString);
                if (strIndex >= 0)
                {
                    match = true;
                }
            }
            return match;
        }

        /*public static bool renameComputer(string computer, string newName)
        {
            bool success = false;

            string MyString = string.Empty;
            string RemoteMachineName = computer;
            string MyScope = @"\\" + RemoteMachineName + @"\root\cimv2";
            string MyQuery = "select * from Win32_ComputerSystem";
            if (canConnect(computer))
            {
                try
                {
                    ConnectionOptions co = new ConnectionOptions();
                    co.Authentication = AuthenticationLevel.PacketPrivacy;

                    ManagementPath mp = new ManagementPath("Win32_ComputerSystem");
                    ManagementScope ms = new ManagementScope(MyScope, co);
                    ObjectGetOptions ogo = new ObjectGetOptions();
                    ManagementObject dir = new ManagementObject(ms, mp, ogo);
                    dir.Get();
                    //ms.Connect();                                       
                    //ManagementObject dir = new ManagementObject(mp

                    ManagementBaseObject inputArgs = dir.GetMethodParameters("Rename");

                    inputArgs["Name"] = newName;
                    inputArgs["UserName"] = @"apex\dryder";
                    inputArgs["Password"] = "";

                    ManagementBaseObject outParams = dir.InvokeMethod("Rename", inputArgs, null);
                    uint ret = (uint)(outParams.Properties["ReturnValue"].Value);
                    if (ret == 0)
                    {
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            return success;
        }*/

        public static bool canConnect(string host)
        {
            bool connect = false;
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                PingReply reply = pingSender.Send(host + ".APEX.Local", timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    connect = true;
                }
            }
            catch { }

            return connect;

        }

        public static string convertDecToSize(decimal number)
        {
            string freeSpaceFinal = null;
            if (number > 1024) //convert to KB
            {
                number = Math.Round(number / 1024, 0);
                if (number > 1024) //convert to MB
                {
                    number = Math.Round(number / 1024, 0);
                    if (number > 1024) //convert to GB
                    {
                        number = Math.Round(number / 1024, 0);
                        freeSpaceFinal = number + " GB";
                    }
                    else freeSpaceFinal = number + " MB";
                }
                else freeSpaceFinal = number + " KB";
            }
            else freeSpaceFinal = number + " B";

            return freeSpaceFinal;
        }

        public static ListViewItem getComputerListViewItem(string computer)
        {
            ListViewItem itemOut = new ListViewItem();

            string MyString = string.Empty;
            string RemoteMachineName = computer;
            string MyScope = @"\\" + RemoteMachineName + @"\root\cimv2";
            string MyQuery = "select * from Win32_ComputerSystem";
            if (RemoteConnect.canConnect(computer))
            {
                try
                {
                    ManagementObjectSearcher MyMOS = new ManagementObjectSearcher(MyScope, MyQuery);

                    foreach (ManagementObject MyMO in MyMOS.Get())
                    {
                        foreach (PropertyData MyProperty in MyMO.Properties)
                        {
                            if (MyProperty.Value != null && isInArray(MyProperty.Name, SearchArray))
                            {
                                if (MyProperty.Name.ToString().Contains("Model"))
                                {
                                    if (MyProperty.Value.ToString().Contains("520"))
                                    {
                                        Summary["520"]++;
                                    }
                                    else if (MyProperty.Value.ToString().Contains("740"))
                                    {
                                        Summary["740"]++;
                                    }
                                    else if (MyProperty.Value.ToString().Contains("755"))
                                    {
                                        Summary["755"]++;
                                    }
                                    else if (MyProperty.Value.ToString().Contains("760"))
                                    {
                                        Summary["760"]++;
                                    }
                                    else if (MyProperty.Value.ToString().Contains("960"))
                                    {
                                        Summary["960"]++;
                                    }
                                    else
                                    {
                                        Summary["other"]++;
                                    }
                                }
                                if (MyProperty.Name.ToString().Contains("TotalPhysicalMemory"))
                                {
                                    long memorySize = Convert.ToInt64(MyProperty.Value) / 1024 / 1024;
                                    string sizeString = string.Empty;
                                    if (memorySize > 400 && memorySize < 800)
                                    {
                                        sizeString = "512 MB";
                                    }
                                    else if (memorySize > 800 && memorySize < 1400)
                                    {
                                        sizeString = "1024 MB";
                                    }
                                    else if (memorySize > 1400 && memorySize < 2400)
                                    {
                                        sizeString = "2048 MB";
                                    }
                                    else if (memorySize > 2400 && memorySize < 3400)
                                    {
                                        sizeString = "3072 MB";
                                    }
                                    else
                                    {
                                        sizeString = memorySize + " MB";
                                    }
                                    //RemoteConnect.convertDecToSize(Convert.ToDecimal(MyProperty.Value));
                                    MyString += sizeString + ";";
                                }
                                else
                                {
                                    MyString += MyProperty.Value.ToString().Trim() + ";";
                                }
                            }
                            else if (MyProperty.Value == null && isInArray(MyProperty.Name, SearchArray))
                            {
                                if (MyProperty.Name.Contains("UserName"))
                                {
                                    MyString += "LOGGED OFF;";
                                }
                                else
                                {
                                    MyString += string.Empty + ";";
                                }
                            }
                        }
                        MyString += Math.Round(getFreeDiskSpace(computer) / 1024 / 1024 / 1024, 1) + " GB;";
                        MyString += getServiceTag(computer) + ";";
                    }
                    string[] formattedString = MyString.Split(';');
                    string[] finalString = new string[] { formattedString[1], formattedString[0], formattedString[3], formattedString[4], formattedString[2], formattedString[5], formattedString[6] };
                    itemOut = new ListViewItem(finalString);
                    Count++;
                }

                //can connect, but encountered another error:
                catch (Exception)
                {
                    string[] errorRow = new string[] { computer, string.Empty, string.Empty, string.Empty, "PROBE FAILED", string.Empty, string.Empty };
                    itemOut = new ListViewItem(errorRow);
                    Count++;
                    Summary["errors"]++;
                }
            }
            else
            {
                string[] errorRow = new string[] { computer, string.Empty, string.Empty, string.Empty, "CONNECT FAILED", string.Empty, string.Empty };
                itemOut = new ListViewItem(errorRow); 
                Count++;
                Summary["errors"]++;
            }
            //updateDatabase(itemOut);
            return itemOut;
        }

        public static string getServiceTag(string computer)
        {
            string serviceTag = string.Empty;

            try
            {
                if (canConnect(computer))
                {
                    ManagementScope scope = new ManagementScope(@"\\" + computer + @"\root\cimv2");
                    ManagementPath path = new ManagementPath("Win32_Bios");
                    ObjectGetOptions obj = new ObjectGetOptions(null);
                    ManagementClass wmi = new ManagementClass(scope, path, obj);
                    foreach (ManagementObject bios in wmi.GetInstances())
                    {
                        serviceTag = bios.Properties["Serialnumber"].Value.ToString().Trim();
                        //myString += " rev:" + bios.Properties["smbiosbiosversion"].Value.ToString().Trim();
                    }
                }
            }
            catch { }

            return serviceTag;
        }

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


    }
}