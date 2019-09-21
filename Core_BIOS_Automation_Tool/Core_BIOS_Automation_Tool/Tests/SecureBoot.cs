using System;
using System.IO;

namespace Core_BIOS_Automation_Tool.Tests
{
    class SecureBoot
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* 3-3 Secure Boot Key Management 
         * 
         *      Arguments Expected:
         *      0: 33MAIN
         *          1: log.txt file to use
        */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_33(string[] args)
        {
            // Run if the file listed in args[1] exists in the Core_BIOS_Automation_Tool folder
            if (args[0] == "33MAIN" && File.Exists(@"c:\Core_BIOS_Automation_Tool\" + args[1]))
            {
                // Read log file line by line and put into an array
                string[] fileLines = File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\" + args[1]);

                String write = "";      // String to print out the log again

                // For each array element put said line into the string 'write'
                for (int i = 2; i < fileLines.Length; i++)    // Starts on line 3 (Or array element #3)
                {
                    if (i == 2)                             // Start of the 'write' string
                        write = fileLines[i];
                    else                                    // Every line after = appends to 'write' with new line
                        write = write + Environment.NewLine + fileLines[i];
                }

                File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Stripped_" + args[1], write);

                Environment.Exit(0);    
            }

            // Run if the args[1] argument is not passed correctly or if the file it lists does not exist
            else
            {
                Console.WriteLine("Please check the argument passed from the 3-3 Win PVT Script.");
                Console.WriteLine("This application was expecting two things:" + Environment.NewLine);
                Console.WriteLine("1.  First argument #2 passed to this application should be the name of a file.");
                Console.WriteLine("2.  Second the file name passed should be located at:");
                Console.WriteLine(@"       c:\Core_BIOS_Automation_Tool\   ");
                Console.WriteLine(Environment.NewLine + "Please check these and try calling this application again.");
                Console.WriteLine(Environment.NewLine + Environment.NewLine + "Press any key to continue....");
                Console.ReadLine();
            }

            Environment.Exit(0);  
        }
    }
}
