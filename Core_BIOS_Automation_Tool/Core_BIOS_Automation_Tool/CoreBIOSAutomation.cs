/* Core_BIOS_Automation_Tool.exe
 * This program is designed to work in conjunction with the Core BIOS WinPVT scripts. No other method of execution
 * is supported.
 * 
 * Ver 2.0
 * 
 * Core BIOS Automation Team Members
 * ---Redacted---
 * ---Redacted---
 * 
 * Main HP Contact
 * ---Redacted--- 
 */

/* Argument Triggers - args[0]
*      Ver
*          WinPVT Version Check
*      Year
*          Year Detection
*      Ard
*          Arduino Detection
*      33
*          3-3 Secure Boot Management
*      552
*          LINUX REPSETUP UTILITY
*      613
*          BIOS Scheduled Power-On - WMI
*      618
*          6-18 SMBIOS Data Verification 
*      143
*          14-3 F10 setting for Firebird policies
*      Parse
*           Parse for a word
*      Time
*           Method to calculate the difference in two times
*      WMIS 
*           Method for the main WMI Stress test
*/

/* Change Log
 * 1.0 
 *     6-18 SMBIOS Data Verification - Daniel     
 * 1.1
 *     Win PVT Version Check - Daniel
 *     Final Catch all for arguments - Daniel
 * 1.2
 *     3-3 Secure Boot Key Management - Daniel
 *     Reverse a String in Tests.cs - Daniel
 * 1.3
 *     Platform Year Check - Daniel
 *     Arduino Detect - Daniel
 * 1.4 
 *     5-52 LINUX REPSETUP UTILITY - Daniel  
 *     Cleaned up all region tags and comments in both Program.cs and Tests.cs
 * 1.5
 *     14-3 F10 setting for Firebird policies - Daniel
 *     Parse - Parses for a passed keyword - Daniel
 * 1.6
 *     14-3 Added the 143Log argument - Daniel    
 *     Time: Added the Time argument - Daniel
 * 1.7
 *     WMIS - Added the argument for WMI Stress test - Daniel
 *     613 - Added 613 argument for the 6-13 BIOS Scheduled Power-On test
 * 1.8
 *     613 - Added '613 1' argument to calculate time till next sunday     
 * 1.9  
 *     Time: Added '3' argument to check for a >= 10 min difference
 * 2.0
 *     Final Refactoring pass
 */
 
using System;
using System.IO;

namespace Core_BIOS_Automation_Tool
{
   class CoreBIOSAutomation
   {
        static void Main(string[] args)
        {
            // Display a message if someone runs this application by itself
            if (args.Length == 0)
            {
                Console.WriteLine("***************************************************" + Environment.NewLine +
                    "        Core BIOS Automation Tool V 1.9" + Environment.NewLine + Environment.NewLine +
                    "           Developed by: Daniel Gail" + Environment.NewLine +
                    "           Email: daniel.gail@hp.com" + Environment.NewLine + Environment.NewLine +
                    "***************************************************" + Environment.NewLine +
                    Environment.NewLine + "No arguments passed to this application." + Environment.NewLine +
                    Environment.NewLine + "This application is designed specifically to run " + Environment.NewLine +
                    "in conjunction with Core BIOS Automation scripts." + Environment.NewLine + Environment.NewLine +
                    Environment.NewLine + "PRESS [ENTER] TO CLOSE THIS APPLICATION");
                Console.ReadLine();

                Environment.Exit(0);
            }

            // Create the Core_BIOS_Automation_Tool folder if it is not there
            if (args.Length > 0 && !Directory.Exists(@"c:\Core_BIOS_Automation_Tool"))
            {
                Directory.CreateDirectory(@"c:\Core_BIOS_Automation_Tool");
            }

            // Win PVT Version check
            if (args[0] == "Ver")
            {
                Tests.VersionCheck.Test_Ver();
            }

            // Year detection
            if (args[0] == "Year")
            {
                Tests.YearDetection.Test_Year(args);
            }

            // Arduino Detection
            if (args[0] == "Ard")
            {
                Tests.ArduinoDetection.Test_Ard();
            }

            // 3-3 Secure Boot Management
            if (args[0].Substring(0, 2) == "33")
            {
                Tests.SecureBoot.Test_33(args);
            }

            // 5-52 LINUX REPSETUP UTILITY
            if (args[0].Substring(0, 3) == "552")
            {
                Tests.LinuxRepsetupUtility.Test_552(args);
            }

            // 6-13 BIOS Scheduled Power-On WMI
            if (args[0].Substring(0, 3) == "613")
            {
                Tests.BIOSScheduledPowerOnWMI.Test_613(args);
            } 

            // 6-18 SMBIOS Data Verification
            if (args[0].Substring(0, 3) == "618")
            {
                Tests.SMBIOSDataVerification.Test_618(args);
            }

            // 14-3 F10 setting for Firebird policies
            if (args[0].Substring(0, 3) == "143")
            {
                Tests.FirebirdPolicies.Test_143(args);
            }

            // Parse a log for a keyword
            if (args[0] == "Parse")
            {
                Tests.Parse.Test_Parse(args);
            }

            // Reports current system time
            if (args[0] == "Time")
            {
                Tests.Time.Test_Time(args);
            }

            // Calls for the WMI Stress method
            if (args[0] == "WMIS")
            {
                Tests.WMIStress.Test_WMIS(args);
            }

            // Final catch all for arguments not covered
            else if (args[0] != null)
            {
                Console.WriteLine("Command line arguments passed to this application" +
                    "are not valid." + Environment.NewLine + Environment.NewLine +
                    "This application is designed specifically for use with " + Environment.NewLine +
                    "Core BIOS Automation scripts." + Environment.NewLine + Environment.NewLine +
                    Environment.NewLine + "PRESS [ENTER] TO CLOSE THIS APPLICATION");
                Console.ReadLine();

                Environment.Exit(0);
            }

           Environment.Exit(0);    
       }
    }
}