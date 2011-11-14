using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Security.Permissions;
using System.IO;


namespace ActiveDirectoryTools
{
    class DiskCleanUp
    {

        public static void DeleteFiles(string computer, string dir, string subDir)
        {
            string baseDir = computer + "\\c$\\" + dir;
            FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.Write, baseDir);

            string[] tmpDir = Directory.GetDirectories(baseDir);
            string currentUser = Environment.UserName;
            string combinedPath;

            foreach (string fileName in tmpDir)
            {
                if (!fileName.Equals("Administrator") && !fileName.Equals("All Users") && !fileName.Equals("Default User") && !fileName.Equals(currentUser))
                {
                    Console.WriteLine("Skipped folder " + fileName);
                }
                else
                {
                    try
                    {
                        combinedPath = Path.Combine(fileName, subDir);

                        if (Directory.Exists(combinedPath))
                        {
                            Directory.Delete(combinedPath, true);
                        }
                    }

                    catch (Exception) { }

                }
            }
        }
    }
}