using System;
using System.IO;

namespace Core_BIOS_Automation_Tool.Tests
{
    class BIOSScheduledPowerOnWMI
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* 6-13 BIOS Scheduled Power-On WMI 
         * 
         *      Arguments Expected:
         *      0: 613
         *      1: 1 - This calls the section to count seconds to the next Sun at 10 am
        */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_613(string[] args)
        {
            if (File.Exists(@"c:\Core_BIOS_Automation_Tool\getfile.txt") && args.Length == 1)
            {
                string[] fileLines = File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\getfile.txt");

                int counter = 0, arrayCounter = 0;
                string text = "";

                for (int i = 0; i < fileLines.Length; i++)
                {
                    // Look for the keyword or phrase and grab everything after it
                    if (fileLines[i].Contains("Sunday"))
                    {
                        counter++;
                        i++;
                        string[] expected = { "*Disable", "Enable" , "Monday", "*Disable", "Enable",
                            "Tuesday", "*Disable", "Enable" , "Wednesday", "*Disable", "Enable" ,
                            "Thursday", "*Disable", "Enable" , "Friday", "*Disable", "Enable" ,
                            "Saturday", "*Disable", "Enable" , "BIOS Power-On Hour" , "0" ,
                            "BIOS Power-On Minute" , "0"};
                        do
                        {
                            if (fileLines[i].Contains(expected[arrayCounter]))
                            {
                                counter++;
                                i++;
                                arrayCounter++;
                            }

                            else
                            {
                                i++;
                                arrayCounter++;
                            }
                        } while (arrayCounter != 24);
                    }
                }

                if (counter == 25)
                {
                    text = "//Correct values found in log " + Environment.NewLine +
                        "GETFILE = 1";
                }

                else
                {
                    text = "//Incorrect values found in log " + Environment.NewLine +
                        "GETFILE = 0";
                }

                File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\GETFILE_Results.txt", text);

                Environment.Exit(0);    // Shut down the application
            }

            if (args[1] == "1")
            {
                DateTime now = DateTime.Now;
                string day = now.ToString("dddd");

                int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)now.DayOfWeek + 7) % 7;
                int seconds = daysUntilSunday * 86400;
                string write = "//Days till next Sunday: " + daysUntilSunday + Environment.NewLine +
                    "//Seconds till next Sunday: " + seconds + Environment.NewLine +
                    "SECONDS_TILL_SUNDAY = " + seconds;

                File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Sunday_Calc.txt", write);

                Environment.Exit(0);
            }

            else                // File not found
            {
                Console.WriteLine(Environment.NewLine + "Something happened with the WinPVT script." +
                Environment.NewLine + "The getfile.txt file was not found or an invalid argument was passed." +
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
