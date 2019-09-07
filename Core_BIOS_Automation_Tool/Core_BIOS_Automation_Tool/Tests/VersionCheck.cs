using System;
using System.Diagnostics;
using System.IO;

namespace Core_BIOS_Automation_Tool.Tests
{
    class VersionCheck
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* Win PVT Version check method
         * 
         *      Arguments Expected:
         *      0:  Ver
         *      
         *      Should be noted the above argument is only use to kick off this method. It is not used by the 
         *          method.
         *      
         *      Files Parsed:
         *      CBAT - Document located in the Script Tools folder that only has the expected 
         *          version of Win PVT.
         *          
         *      Return Codes
         *          0: Version and Build of WinPVT.exe matches to what is listed in Automation Code.txt
         *          1: Version or Build of WinPVT.exe does not match to what is listed in Automation Code.txt
         *          2: Automation Code.txt was not found in the Script Tools folder
         */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_Ver()
        {
            // Run the below only if the CBAT exists
            if (File.Exists("C:\\Users\\\\" + Environment.UserName + "\\Desktop\\Core WinPVT\\Test Scripts\\" +
                "Script Tools\\CBAT"))
            {
                // Get the file information of the WinPVT.exe file
                if (File.Exists(@"c:\Program Files\Hewlett-Packard\WinPVT " +
                    @"7.1A\WinPVT.exe"))
                {
                    FileVersionInfo currentVersion = FileVersionInfo.GetVersionInfo(@"c:\Program Files\Hewlett-Packard\WinPVT " +
                        @"7.1A\WinPVT.exe");

                    // Read version & build expected from the CBAT file in the Script Tools folder
                    StreamReader file = new StreamReader("C:\\Users\\\\" + Environment.UserName +
                        "\\Desktop\\Core WinPVT\\Test Scripts\\Script Tools\\CBAT");

                    for (int i = 0; i <= 7; i++)
                        file.ReadLine();

                    string version = file.ReadLine();
                    string build = file.ReadLine();
                    int currBuild = Convert.ToInt32(build);
                    file.Close();

                    // Return code '0' if both the Version & Build match
                    if (version == currentVersion.FileVersion && currBuild == currentVersion.FilePrivatePart)
                    {
                        String text = "//Win PVT Version and Build matched" + Environment.NewLine +
                            "//Detected Version: " + version + Environment.NewLine +
                            "//Expected Version: " + currentVersion.FileVersion + Environment.NewLine + Environment.NewLine +
                            "//Detected Build: " + currBuild + Environment.NewLine +
                            "//Expected Build: " + currentVersion.FilePrivatePart + Environment.NewLine + Environment.NewLine +
                            "RETURNCODE = 0";
                        File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Version Check.txt", text);
                    }

                    // Return code '1' if either Version or Build do not match
                    else
                    {
                        String text = "//Win PVT Version or Build did not match expected resuts" + Environment.NewLine +
                            "//Detected Version: " + version + Environment.NewLine +
                            "//Expected Version: " + currentVersion.FileVersion + Environment.NewLine + Environment.NewLine +
                            "//Detected Build: " + currBuild + Environment.NewLine +
                            "//Expected Build: " + currentVersion.FilePrivatePart + Environment.NewLine + Environment.NewLine +
                            "RETURNCODE = 1";
                        File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Version Check.txt", text);
                    }
                }

                if (File.Exists(@"c:\Program Files\Hewlett-Packard\WinPVT " +
                    @"8.1A\WinPVT.exe"))
                {
                    FileVersionInfo currentVersion = FileVersionInfo.GetVersionInfo(@"c:\Program Files\Hewlett-Packard\WinPVT " +
                        @"8.1A\WinPVT.exe");

                    // Read version & build expected from the CBAT file in the Script Tools folder
                    StreamReader file = new StreamReader("C:\\Users\\\\" + Environment.UserName +
                        "\\Desktop\\Core WinPVT\\Test Scripts\\Script Tools\\CBAT");

                    for (int i = 0; i <= 7; i++)
                        file.ReadLine();

                    string version = file.ReadLine();
                    string build = file.ReadLine();
                    int currBuild = Convert.ToInt32(build);
                    file.Close();

                    // Return code '0' if both the Version & Build match
                    if (version == currentVersion.FileVersion && currBuild == currentVersion.FilePrivatePart)
                    {
                        String text = "//Win PVT Version and Build matched" + Environment.NewLine +
                            "//Detected Version: " + version + Environment.NewLine +
                            "//Expected Version: " + currentVersion.FileVersion + Environment.NewLine + Environment.NewLine +
                            "//Detected Build: " + currBuild + Environment.NewLine +
                            "//Expected Build: " + currentVersion.FilePrivatePart + Environment.NewLine + Environment.NewLine +
                            "RETURNCODE = 0";
                        File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Version Check.txt", text);
                    }

                    // Return code '1' if either Version or Build do not match
                    else
                    {
                        String text = "//Win PVT Version or Build did not match expected resuts" + Environment.NewLine +
                            "//Detected Version: " + version + Environment.NewLine +
                            "//Expected Version: " + currentVersion.FileVersion + Environment.NewLine + Environment.NewLine +
                            "//Detected Build: " + currBuild + Environment.NewLine +
                            "//Expected Build: " + currentVersion.FilePrivatePart + Environment.NewLine + Environment.NewLine +
                            "RETURNCODE = 1";
                        File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Version Check.txt", text);
                    }
                }
            }

            // Run the below only if the CBAT does not exist
            else if (!File.Exists("C:\\Users\\\\" + Environment.UserName + "\\Desktop\\Core WinPVT\\Test Scripts\\" +
                "Script Tools\\CBAT"))
            {
                String text = "//CBAT was not found" + Environment.NewLine +
                        "RETURNCODE = 2";
                File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Version Check.txt", text);
            }

            Environment.Exit(0);
        }
    }
}
