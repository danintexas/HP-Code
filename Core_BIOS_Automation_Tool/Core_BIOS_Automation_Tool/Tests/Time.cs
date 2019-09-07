using System;
using System.IO;

namespace Core_BIOS_Automation_Tool.Tests
{
    class Time
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*
         * Used to grab 2 different times and calculate the difference
         * 
         *      Arguments Expected
         *      0: Time
         *      1: Three different entries
         *          0: Grab system time and write into new file
         *          1: Grab system time and append into the new file
         *          3: Calculate the difference between 0 and 1 then append into that same file 
        */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_Time(string[] args)
        {
            if (args[1] == "0")
            {
                string time = DateTime.Now.ToString();
                string write = "// Time Before the restart = " + time + Environment.NewLine +
                    "TESTINPUT_TIMEBEFORE = " + time + Environment.NewLine;

                File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);

                Environment.Exit(0);  

            }

            if (args[1] == "1" && File.Exists(@"c:\Core_BIOS_Automation_Tool\Restart_Difference.txt"))
            {
                string time = DateTime.Now.ToString();
                string write = "// Time After the restart = " + time + Environment.NewLine +
                    "TESTINPUT_TIMEAFTER = " + time + Environment.NewLine;

                File.AppendAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);

                Environment.Exit(0); 
            }

            if (args[1] == "2" && File.Exists(@"c:\Core_BIOS_Automation_Tool\Restart_Difference.txt"))
            {
                string[] fileLines = File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\Restart_Difference.txt");
                string before = "", after = "";
                string write;     

                for (int i = 0; i < fileLines.Length; i++)
                {
                    if (fileLines[i].Contains("TESTINPUT_TIMEBEFORE = ") || fileLines[i].Contains("TESTINPUT_TIMEAFTER = "))
                    {
                        if (fileLines[i].Contains("TESTINPUT_TIMEBEFORE = "))
                            before = (fileLines[i].Substring(fileLines[i].LastIndexOf('=') + 1));

                        if (fileLines[i].Contains("TESTINPUT_TIMEAFTER = "))
                            after = (fileLines[i].Substring(fileLines[i].LastIndexOf('=') + 1));
                    }
                }

                DateTime beforeReported = DateTime.Parse(before);
                DateTime afterReported = DateTime.Parse(after);

                long difference = (afterReported - beforeReported).Ticks;
                var diff = TimeSpan.FromTicks(difference).TotalMinutes;

                if (diff >= 3.5 || diff <= 0)
                {
                    write = "//Difference is: " + diff + Environment.NewLine +
                    "TIME_DIFFERENCE = FAIL";

                    File.AppendAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);
                }

                else
                {
                    write = "//Difference is: " + diff + Environment.NewLine +
                    "TIME_DIFFERENCE = PASS";

                    File.AppendAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);
                }

                Environment.Exit(0);
            }

            if (args[1] == "3" && File.Exists(@"c:\Core_BIOS_Automation_Tool\Restart_Difference.txt"))
            {
                string[] fileLines = File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\Restart_Difference.txt");
                string before = "", after = "";
                string write;      

                for (int i = 0; i < fileLines.Length; i++)
                {
                    if (fileLines[i].Contains("TESTINPUT_TIMEBEFORE = ") || fileLines[i].Contains("TESTINPUT_TIMEAFTER = "))
                    {
                        if (fileLines[i].Contains("TESTINPUT_TIMEBEFORE = "))
                            before = (fileLines[i].Substring(fileLines[i].LastIndexOf('=') + 1));

                        if (fileLines[i].Contains("TESTINPUT_TIMEAFTER = "))
                            after = (fileLines[i].Substring(fileLines[i].LastIndexOf('=') + 1));
                    }
                }

                DateTime beforeReported = DateTime.Parse(before);
                DateTime afterReported = DateTime.Parse(after);

                long difference = (afterReported - beforeReported).Ticks;
                var diff = TimeSpan.FromTicks(difference).TotalMinutes;

                if (diff >= 10 || diff <= 0)
                {
                    write = "//Difference is: " + diff + Environment.NewLine +
                    "TIME_DIFFERENCE = FAIL";

                    File.AppendAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);
                }

                else
                {
                    write = "//Difference is: " + diff + Environment.NewLine +
                    "TIME_DIFFERENCE = PASS";

                    File.AppendAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);
                }

                Environment.Exit(0);    
            }

            else               
            {
                Console.WriteLine(Environment.NewLine + "Something happened with the WinPVT script." +
                Environment.NewLine + "The Restart & Time Calculation.log file was not found." +
                Environment.NewLine + "Please rerun the script and if you continue to see this error " +
                "dialog" + Environment.NewLine + "you will need to write an SIO on this script." +
                Environment.NewLine + Environment.NewLine +
                "Press any key to close this application and the script will fail.");
                Console.ReadLine();
            }
        }
    }
}
