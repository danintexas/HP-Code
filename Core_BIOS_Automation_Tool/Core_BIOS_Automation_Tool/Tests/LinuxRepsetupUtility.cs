using System;
using System.IO;

namespace Core_BIOS_Automation_Tool.Tests
{
    class LinuxRepsetupUtility
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* 5-52 LINUX REPSETUP UTILITY 
         * 
         *      Arguments Expected:
         *      0: 552
         *      
         *      Files Parsed:
         *          HPSETUP.TXT
         *       
         *      This method will parse a log file looking for the 'Asset Tracking Number'
         *      and then putting in '1234567890' as the Asset Tracking Number then saving the log
         *      with that change.
         * 
        */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_552(string[] args)
        {
            if (File.Exists(@"c:\Core_BIOS_Automation_Tool\HPSETUP.TXT"))
            {
                // Read log file line by line and put into an array
                string[] fileLines = File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\HPSETUP.TXT");

                String write = "";      // String to print out the log again

                // For each array element put said line into the string 'write'
                for (int i = 0; i < fileLines.Length; i++)
                {
                    if (fileLines[i] == "Asset Tracking Number")    // Special Manipulation for Asset Tracking Number
                    {
                        write = write + Environment.NewLine + fileLines[i];
                        i++;
                        write = write + Environment.NewLine + "        1234567890";
                    }

                    else                                            // Any other line = appends to 'write' with new line
                    {
                        if (i == 0)                                 // Write line for the first line
                            write = fileLines[i];
                        else
                            write = write + Environment.NewLine + fileLines[i];
                    }
                }

               File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\HPSETUP_MOD.TXT", write);

                Environment.Exit(0);   
            }

            else                                                    // In case the HPSETUP.TXT isn't found
            {
                Console.WriteLine(Environment.NewLine + "Something happened with the WinPVT script." +
                    Environment.NewLine + "Please rerun the script and if you continue to see this error " +
                    "dialog" + Environment.NewLine + "you will need to execute the manual test plan 5-52-1."
                    + Environment.NewLine + "If the manual test passes please write an SIO on this script." +
                    Environment.NewLine + Environment.NewLine +
                    "Press any key to close this application and the script will fail.");
                Console.ReadLine();
            }

            Environment.Exit(0);
        }
    }
}
