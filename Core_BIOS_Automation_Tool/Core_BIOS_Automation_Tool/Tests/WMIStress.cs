using System;
using System.IO;

namespace Core_BIOS_Automation_Tool.Tests
{
    class WMIStress
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* Win PVT Version check method
         * 
         *      Arguments Expected:
         *      0:  WMIS
         *      1:  # = WMI counter number from script
         *      
         *      
         */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_WMIS(string[] args)
        {
            if (args.Length == 2)
            {
                // Build the string to print to results
                String text = "//Name of WMI" + Environment.NewLine + "WMI_Current = $WMI_" + args[1];

                // Write log
                File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\WMI_Current.txt", text);

                Environment.Exit(0);    // Shut down the application
            }

            else                // Incorrect # of arguments
            {
                Console.WriteLine(Environment.NewLine + "Something happened with the WinPVT script." +
                Environment.NewLine + "An incorrect number of arguments was passed to this application" +
                Environment.NewLine + "Please rerun the script and if you continue to see this error " +
                "dialog" + Environment.NewLine + "you will need to write an SIO on this script." +
                Environment.NewLine + Environment.NewLine +
                "Press any key to close this application and the script will fail.");
                Console.ReadLine();

                Environment.Exit(0);  
            }
        }
    }
}
