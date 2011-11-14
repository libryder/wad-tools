using System;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ActiveDirectoryTools.Classes
{
    class CreateExcelWorksheet
    {
        Workbook wb;
        Worksheet ws;
        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        public static string[] alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
            "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

        public CreateExcelWorksheet()
        {
            if (xlApp == null)
            {
                MessageBox.Show("EXCEL could not be started. Check that your office installation and project references are correct.");
                return;
            }
            wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            ws = (Worksheet)wb.Worksheets[1];
        }

        public bool WriteRow(int row, Object[] rowData)
        {
            bool success = false;

            try
            {
                Range aRange = ws.get_Range("A" + row, alphabet[rowData.Length-1] + "" + row);
                Object[] args = new Object[1];
                args[0] = rowData;
                aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return success;
        }

        public void AutoFit()
        {
            xlApp.Columns.AutoFit();
        }

        public void Commit()
        {
            xlApp.Visible = true;
        }
    }
}
