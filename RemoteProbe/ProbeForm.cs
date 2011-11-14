using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;


namespace RemoteProbe
{
    public partial class ProbeForm : Form
    {
        public ProbeForm()
        {
            InitializeComponent();
            //FormLoad();

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            try
            {
                string MyString = "";
                string RemoteMachineName = "localhost"; //or "batcomputer01"
                string MyScope = "\\\\" + RemoteMachineName + "\\root\\cimv2";
                string MyQuery = "select * from Win32_ComputerSystem";

                ManagementObjectSearcher MyMOS = new ManagementObjectSearcher(MyScope, MyQuery);

                foreach (ManagementObject MyMO in MyMOS.Get())
                {
                    foreach (PropertyData MyProperty in MyMO.Properties)
                    {
                        if (MyProperty.Value != null)
                        {
                            MyString = MyString + MyProperty.Name + " = " + MyProperty.Value.ToString() + "; ";
                        }
                    }
                    MyString = MyString + "\r\n\r\n";
                }
                string[] formattedString = MyString.Split(';');
                string finalString = string.Empty;
                foreach (string tmp in formattedString)
                {
                    finalString += tmp.Trim() + "\n";
                }
                MessageBox.Show(finalString, "localhost");
            }
            catch (Exception MyError)
            {
                MessageBox.Show("An error has occurred: " + MyError.Message);
            }
        }
        
        /*public void FormLoad()
        {
            SystemInfo si;
            SystemInfo.GetSystemInfo(out si);

            txtboxApplication.Text = si.AppName;
            txtboxVersion.Text = si.AppVersion;
            txtBoxComputerName.Text = si.MachineName;
            txtBoxMemory.Text = Convert.ToString((si.TotalRam / 1073741824)
                + " GigaBytes");
            txtBoxProcessor.Text = si.ProcessorName;
            txtBoxOperatingSystem.Text = si.OperatingSystem;
            txtBoxOSVersion.Text = si.OperatingSystemVersion;
            txtBoxManufacturer.Text = si.Manufacturer;
            txtBoxModel.Text = si.Model;
        }*/

    }
}
