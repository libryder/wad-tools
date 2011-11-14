using System;
using System.IO;
using System.Security.Permissions;

namespace ActiveDirectoryTools
{
    class Cleanup
    {
        public static void DeleteFiles()
        {
            string targetDir = "C:\\Documents and Settings\\";
            string subDir = "\\Local Settings";

            FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.Write, targetDir);

            DriveInfo.GetDrives();

            string[] tmpDir = Directory.GetDirectories(targetDir);
            string currentUser = Environment.UserName;
            string combinedPath;

            foreach (string fileName in (string)targetDir)
            {
                if (!fileName.Equals("Administrator") && !fileName.Equals("All Users") && !fileName.Equals("Default User"))
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

        public static long GetFreeSpace()
        {
            //This method is not currently non-functional as security stops 
            //us from getting information about the hard disk.

            long freeSpace = 0;

            return freeSpace;

        }
    }
}
