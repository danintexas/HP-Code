using System;

namespace Core_BIOS_Automation_Tool.Tests
{
    class YearDetection
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* Arduino Detection method
         * 
         *      Arguments Expected:
         *      0: Year
         *      1: Results from a @smbios(0,0,4) pull in Win PVT  
         */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_Year(string[] args)
        {
            // 2015 platforms
            if (args[0] == "Year" && args[1].Substring(0, 1) == "N")
            {
                // Build the string to print to results
                String text = "//Year detected: 2015" + Environment.NewLine + "YEAR = 2015";

                // Write log
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Year.txt", text);

                Environment.Exit(0); 
            }

            // 2016 platforms
            else if (args[0] == "Year" && args[1].Substring(0, 1) == "P")
            {
                // Build the string to print to results
                String text = "//Year detected: 2016" + Environment.NewLine + "YEAR = 2016";

                // Write log
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Year.txt", text);

                Environment.Exit(0);
            }

            // 2017 platforms
            else if (args[0] == "Year" && args[1].Substring(0, 1) == "Q")
            {
                // Build the string to print to results
                String text = "//Year detected: 2017" + Environment.NewLine + "YEAR = 2017";

                // Write log
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Year.txt", text);

                Environment.Exit(0);
            }

            else
            {
                // Build the string to print to results
                String text = "//Year detected: UNKNOWN" + Environment.NewLine + "YEAR = UNKNOWN";

                // Write log
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Year.txt", text);

                Environment.Exit(0);
            }
        }
    }
}
