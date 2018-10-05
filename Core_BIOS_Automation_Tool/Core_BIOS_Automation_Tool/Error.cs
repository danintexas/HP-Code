using System;
using System.Collections.Generic;
using System.Text;

namespace Core_BIOS_Automation_Tool
{
    class Error
    {
        #region"Old Code"
        /*
        if (args.Length == 4)
        {
            // Set all numbers needed
            int errorCount = Convert.ToInt32(args[1]), sectionNumber = Convert.ToInt32(args[2]), 
                wmiNumber = Convert.ToInt32(args[3]);

            string section = "", wmi = "", csv = "";

            // Set all the Section Number strings
            switch (sectionNumber)
            {
                case 1:
                    section = "1 @ a time";
                    break;
                case 2:
                    section = "2 @ a time";
                    break;
                case 3:
                    section = "3 @ a time";
                    break;
                case 4:
                    section = "4 @ a time";
                    break;
                case 5:
                    section = "5 @ a time";
                    break;
                case 6:
                    section = "6 @ a time";
                    break;
                case 7:
                    section = "7 @ a time";
                    break;
                case 8:
                    section = "8 @ a time";
                    break;
            }

            // Set all the wmiNumber strings
            switch (wmiNumber)
            {
                case 1:
                    wmi = "Verify Boot Block on every boot";
                    break;
                case 2:
                    wmi = "BIOS Data Recovery Policy";
                    break;
                case 3:
                    wmi = "Dynamic Runtime Scanning of Boot Block";
                    break;
                case 4:
                    wmi = "Prompt on Network Controller Configuration Change";
                    break;
                case 5:
                    wmi = "Sure Start BIOS Settings Protection";
                    break;
                case 6:
                    wmi = "Enhanced HP Firmware Runtime Intrusion Prevention and Detection";
                    break;
                case 7:
                    wmi = "Sure Start Security Event Policy";
                    break;
                case 8:
                    wmi = "Lock BIOS Version";
                    break;
            }

            // Create a fresh log file and log the first error
            if (errorCount == 1)
            {
                // First line of the log 

                csv = "Error # , Test Suite Failure , Last WMI that failed" + Environment.NewLine;

                File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\Error Log.csv", csv);

                // Log error
                csv = errorCount + " , " + section + " , " + wmi + Environment.NewLine;
                File.AppendAllText(@"C:\Core_BIOS_Automation_Tool\Error Log.csv", csv);
            }

            // Append to the existing log file
            else 
            {
                // Log error
                csv = errorCount + " , " + section + " , " + wmi + Environment.NewLine;
                File.AppendAllText(@"C:\Core_BIOS_Automation_Tool\Error Log.csv", csv);
            }

            Environment.Exit(0);
        }

        // Number of arguments is not enough
        else
        {
            Console.WriteLine(Environment.NewLine + "Something happened with the WinPVT script." +
            Environment.NewLine + "Please rerun the script and if you continue to see this error " +
            "dialog" + Environment.NewLine + "you will need to write an SIO on this script." +
            Environment.NewLine + Environment.NewLine +
            "Press any key to close this application and the script will fail.");
            Console.ReadLine();

            Environment.Exit(0);
        }
        */
        #endregion
    }
}
