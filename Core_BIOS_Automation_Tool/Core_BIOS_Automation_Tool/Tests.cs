using System;
using System.IO;

namespace Core_BIOS_Automation_Tool
{
    public class Testss
    {
        #region "14-3 F10 setting for Firebird policies"
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* 14-3 F10 setting for Firebird policies method
         * 
         *      Arguments Expected:
         *      0: 143Time -> This is no longer used
         *      0: 143Log
         *          1: Cycle count
         *          2: Pass/Fail of the Cycle
         *                
         */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_143(string[] args)
        {
            #region"Time argument"
            // This section will check the Restart &Time Calculation.log file located in the c:\Core_BIOS_Automation_Tool
            //  folder and parse that log for two values:
            //      TESTINPUT_TIMEBEFORE = #VALUE
            //      TESTINPUT_TIMEAFTER = #VALUE
            //
            // Section will then convert these strings to an INT and return the difference to the Restart_Difference.txt
            if (args[0] == "143Time")
            {
                if (File.Exists(@"c:\Core_BIOS_Automation_Tool\Restart & Time Calculation.log"))
                {
                    // Read log file line by line and put into an array
                    string[] fileLines = System.IO.File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\Restart & Time Calculation.log");

                    int difference = 0, before = 0, after = 0;

                    String write = "";      // String to print out the log again

                    // For each array element put said line into the string 'write'
                    for (int i = 0; i < fileLines.Length; i++)
                    {
                        // Look for TESTINPUT_TIMEBEFORE || TESTINPUT_TIMEAFTER
                        if (fileLines[i].Contains("TESTINPUT_TIMEBEFORE = ") || fileLines[i].Contains("TESTINPUT_TIMEAFTER = "))
                        {
                            if (fileLines[i].Contains("TESTINPUT_TIMEBEFORE = "))
                                before = Convert.ToInt32(fileLines[i].Substring(fileLines[i].LastIndexOf('=') + 1));

                            if (fileLines[i].Contains("TESTINPUT_TIMEAFTER = "))
                                after = Convert.ToInt32(fileLines[i].Substring(fileLines[i].LastIndexOf('=') + 1));

                            difference = after - before;
                        }
                    }

                    write = "// Time before the restart = " + before + Environment.NewLine +
                        "//Time after the restart = " + after + Environment.NewLine +
                        Environment.NewLine + "//Difference is: " + difference + Environment.NewLine +
                        "TIME_DIFFERENCE = " + difference;

                    System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);

                    Environment.Exit(0);    // Shut down the application
                }

                else                // File not found
                {
                    Console.WriteLine(Environment.NewLine + "Something happened with the WinPVT script." +
                    Environment.NewLine + "The Restart & Time Calculation.log file was not found." + 
                    Environment.NewLine + "Please rerun the script and if you continue to see this error " +
                    "dialog" + Environment.NewLine + "you will need to write an SIO on this script." +
                    Environment.NewLine + Environment.NewLine +
                    "Press any key to close this application and the script will fail.");
                    Console.ReadLine();

                    Environment.Exit(0);    // Shut down the application
                }
            }
            #endregion

            #region"Error Argument"
            if (args[0] == "143Log")
            {
                // Variables needed for logging
                string csv = "", result = "";

                // Pass/Fail state
                if (args[2] == "P")
                    result = "Pass";
                if (args[2] == "F")
                    result = "Fail";

                // Set up all the default WMI states
                string wmi_one = "Disable", wmi_two = "Automatic";
                string wmi_three = "Enable", wmi_four = "Disable";
                string wmi_five = "Grey/Disable", wmi_six = "Enable";
                string wmi_seven = "Log event and notify user", wmi_eight = "Disable";
                string test = "";

                // Adjust wmi settings depending on test
                switch (Convert.ToInt32(args[1]))
                {
                    #region"1 @ a Time"
                    case 1:
                        {
                            test = "1 @ a Time";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 2:
                        {
                            test = "1 @ a Time";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 3:
                        {
                            wmi_six = "Disable";
                            test = "1 @ a Time";
                            break;
                        }

                    case 4:
                        {
                            wmi_five = "Enable";
                            test = "1 @ a Time";
                            break;
                        }

                    case 5:
                        {
                            wmi_four = "Enable";
                            test = "1 @ a Time";
                            break;
                        }

                    case 6:
                        {
                            wmi_three = "Disable";
                            test = "1 @ a Time";
                            break;
                        }

                    case 7:
                        {
                            wmi_two = "Manual";
                            test = "1 @ a Time";
                            break;
                        }

                    case 8:
                        {
                            wmi_one = "Enable";
                            test = "1 @ a Time";
                            break;
                        }
                    #endregion

                    #region"2 @ a Time"
                    case 9:
                        {
                            test = "2 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 10:
                        {
                            test = "2 @ a Time";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 11:
                        {
                            test = "2 @ a Time";
                            wmi_eight = "Enable";
                            wmi_five = "Enable";
                            break;
                        }
                    case 12:
                        {
                            test = "2 @ a Time";
                            wmi_eight = "Enable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 13:
                        {
                            test = "2 @ a Time";
                            wmi_eight = "Enable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 14:
                        {
                            test = "2 @ a Time";
                            wmi_eight = "Enable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 15:
                        {
                            test = "2 @ a Time";
                            wmi_eight = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 16:
                        {
                            test = "2 @ a Time";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 17:
                        {
                            test = "2 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_five = "Enable";
                            break;
                        }

                    case 18:
                        {
                            test = "2 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_four = "Enable";
                            break;
                        }

                    case 19:
                        {
                            test = "2 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_three = "Disable";
                            break;
                        }

                    case 20:
                        {
                            test = "2 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_two = "Manual";
                            break;
                        }

                    case 21:
                        {
                            test = "2 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_one = "Enable";
                            break;
                        }

                    case 22:
                        {
                            test = "2 @ a Time";
                            wmi_six = "Disable";
                            wmi_five = "Enable";
                            break;
                        }

                    case 23:
                        {
                            test = "2 @ a Time";
                            wmi_six = "Disable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 24:
                        {
                            test = "2 @ a Time";
                            wmi_six = "Disable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 25:
                        {
                            test = "2 @ a Time";
                            wmi_six = "Disable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 26:
                        {
                            test = "2 @ a Time";
                            wmi_six = "Disable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 27:
                        {
                            test = "2 @ a Time";
                            wmi_five = "Enable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 28:
                        {
                            test = "2 @ a Time";
                            wmi_five = "Enable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 29:
                        {
                            test = "2 @ a Time";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            break;
                        }

                    case 30:
                        {
                            test = "2 @ a Time";
                            wmi_five = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 31:
                        {
                            test = "2 @ a Time";
                            wmi_four = "Enable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 32:
                        {
                            test = "2 @ a Time";
                            wmi_four = "Enable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 33:
                        {
                            test = "2 @ a Time";
                            wmi_four = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 34:
                        {
                            test = "2 @ a Time";
                            wmi_three = "Disable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 35:
                        {
                            test = "2 @ a Time";
                            wmi_three = "Disable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 36:
                        {
                            test = "2 @ a Time";
                            wmi_two = "Manual";
                            wmi_one = "Enable";
                            break;
                        }
                    #endregion

                    #region"3 @ a Time"
                    case 37:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 38:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            wmi_five = "Enable";
                            break;
                        }

                    case 39:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 40:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 41:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 42:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 43:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_six = "Disable";
                            wmi_five = "Enable";
                            break;
                        }

                    case 44:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_six = "Disable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 45:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_six = "Disable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 46:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_six = "Disable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 47:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_six = "Disable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 48:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_five = "Enable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 49:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_five = "Enable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 50:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_five = "Enable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 51:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_five = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 52:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_four = "Enable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 53:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_four = "Enable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 54:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_four = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 55:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_three = "Disable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 56:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_three = "Disable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 57:
                        {
                            test = "3 @ a Time";
                            wmi_eight = "Enable";
                            wmi_two = "Manual";
                            wmi_one = "Enable";
                            break;
                        }

                    case 58:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_six = "Disable";
                            wmi_five = "Enable";
                            break;
                        }

                    case 59:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_six = "Disable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 60:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_six = "Disable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 61:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_six = "Disable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 62:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_six = "Disable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 63:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_five = "Enable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 64:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_five = "Enable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 65:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_five = "Enable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 66:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_five = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 67:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_four = "Enable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 68:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_four = "Enable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 69:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_four = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 70:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_three = "Disable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 71:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_three = "Disable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 72:
                        {
                            test = "3 @ a Time";
                            wmi_seven = "Log event only";
                            wmi_two = "Manual";
                            wmi_one = "Enable";
                            break;
                        }

                    case 73:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_five = "Enable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 74:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_five = "Enable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 75:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_five = "Enable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 76:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_five = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 77:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 78:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_four = "Enable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 79:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_four = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 80:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            break;
                        }

                    case 81:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_three = "Disable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 82:
                        {
                            test = "3 @ a Time";
                            wmi_six = "Disable";
                            wmi_two = "Manual";
                            wmi_one = "Enable";
                            break;
                        }

                    case 83:
                        {
                            test = "3 @ a Time";
                            wmi_five = "Enable";
                            wmi_four = "Enable";
                            wmi_three = "Disable";
                            break;
                        }

                    case 84:
                        {
                            test = "3 @ a Time";
                            wmi_five = "Enable";
                            wmi_four = "Enable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 85:
                        {
                            test = "3 @ a Time";
                            wmi_five = "Enable";
                            wmi_four = "Enable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 86:
                        {
                            test = "3 @ a Time";
                            wmi_five = "Enable";
                            wmi_three = "Disable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 87:
                        {
                            test = "3 @ a Time";
                            wmi_five = "Enable";
                            wmi_three = "Disable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 88:
                        {
                            test = "3 @ a Time";
                            wmi_five = "Enable";
                            wmi_two = "Manual";
                            wmi_one = "Enable";
                            break;
                        }

                    case 89:
                        {
                            test = "3 @ a Time";
                            wmi_four = "Enable";
                            wmi_three = "Disable";
                            wmi_two = "Manual";
                            break;
                        }

                    case 90:
                        {
                            test = "3 @ a Time";
                            wmi_four = "Enable";
                            wmi_three = "Disable";
                            wmi_one = "Enable";
                            break;
                        }

                    case 91:
                        {
                            test = "3 @ a Time";
                            wmi_four = "Enable";
                            wmi_two = "Manual";
                            wmi_one = "Enable";
                            break;
                        }

                    case 92:
                        {
                            test = "3 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            break;
                        }
                    #endregion

                    #region"4 @ a Time"
                    case 93:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            break;
                        }

                    case 94:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            break;
                        }

                    case 95:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 96:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 97:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 98:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            break;
                        }

                    case 99:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 100:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 101:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 102:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 103:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 104:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 105:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 106:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 107:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }
                    case 108:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            break;
                        }

                    case 109:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 110:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 111:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 112:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 113:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 114:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 115:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 116:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 117:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 118:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 119:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 120:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 121:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 122:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 123:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 124:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 125:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 126:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 127:
                        {
                            test = "4 @ a Time";
                            wmi_one = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 128:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            break;
                        }

                    case 129:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 130:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 131:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 132:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 133:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 134:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 135:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 136:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 137:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 138:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 139:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 140:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 141:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 142:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 143:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 144:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 145:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 146:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 147:
                        {
                            test = "4 @ a Time";
                            wmi_two = "Manual";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 148:
                        {
                            test = "4 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 149:
                        {
                            test = "4 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 150:
                        {
                            test = "4 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 151:
                        {
                            test = "4 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 152:
                        {
                            test = "4 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 153:
                        {
                            test = "4 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 154:
                        {
                            test = "4 @ a Time";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 155:
                        {
                            test = "4 @ a Time";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 156:
                        {
                            test = "4 @ a Time";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 157:
                        {
                            test = "4 @ a Time";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 158:
                        {
                            test = "4 @ a Time";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 159:
                        {
                            test = "4 @ a Time";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 160:
                        {
                            test = "4 @ a Time";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 161:
                        {
                            test = "4 @ a Time";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 162:
                        {
                            test = "4 @ a Time";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }
                    #endregion

                    #region"5 @ a Time"
                    case 163:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            break;
                        }

                    case 164:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 165:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 166:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 167:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 168:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 169:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 170:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 171:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 172:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 173:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 174:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 175:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 176:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 177:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 178:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 179:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 180:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 181:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 182:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 183:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 184:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 185:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 186:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 187:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 188:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 189:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 190:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 191:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 192:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 193:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 194:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 195:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 196:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 197:
                        {
                            test = "5 @ a Time";
                            wmi_one = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 198:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 199:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 200:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 201:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 202:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 203:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 204:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 205:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 206:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 207:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 208:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 209:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 210:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 211:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 212:
                        {
                            test = "5 @ a Time";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 213:
                        {
                            test = "5 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 214:
                        {
                            test = "5 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 215:
                        {
                            test = "5 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 216:
                        {
                            test = "5 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";

                            break;
                        }

                    case 217:
                        {
                            test = "5 @ a Time";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 218:
                        {
                            test = "5 @ a Time";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }
                    #endregion

                    #region"6 @ a Time"
                    case 219:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            break;
                        }

                    case 220:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 221:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 222:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 223:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 224:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 225:
                        {
                            test = "6 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }

                    case 226:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 227:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 228:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 229:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 230:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 231:
                        {
                            test = "6 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 232:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 233:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 234:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 235:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 236:
                        {
                            test = "6 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 237:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 238:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 239:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 240:
                        {
                            test = "6 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 241:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 242:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 243:
                        {
                            test = "6 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 244:
                        {
                            test = "6 @ a Time";
                            wmi_one = "Enable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 245:
                        {
                            test = "6 @ a Time";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 246:
                        {
                            test = "6 @ a Time";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }
                    #endregion

                    #region"7 @ a Time"
                    case 247:
                        {
                            test = "7 @ a Time";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 248:
                        {
                            test = "7 @ a Time";
                            wmi_one = "Enable";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 249:
                        {
                            test = "7 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 250:
                        {
                            test = "7 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 251:
                        {
                            test = "7 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 252:
                        {
                            test = "7 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 253:
                        {
                            test = "7 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_eight = "Enable";
                            break;
                        }

                    case 254:
                        {
                            test = "7 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            break;
                        }
                    #endregion

                    #region"8 @ a Time"
                    case 255:
                        {
                            test = "8 @ a Time";
                            wmi_one = "Enable";
                            wmi_two = "Manual";
                            wmi_three = "Disable";
                            wmi_four = "Enable";
                            wmi_five = "Enable";
                            wmi_six = "Disable";
                            wmi_seven = "Log event only";
                            wmi_eight = "Enable";
                            break;
                        }
                    #endregion

                    #region"Default"
                    default:
                        {
                            Console.WriteLine(Environment.NewLine + "Something happened with the WinPVT script." +
                    Environment.NewLine + "Please rerun the script and if you continue to see this error " +
                    "dialog" + Environment.NewLine + "you will need to write an SIO on this script." +
                    Environment.NewLine + Environment.NewLine +
                    "Press any key to close this application and the script will fail.");
                            Console.ReadLine();

                            Environment.Exit(0);
                            break;
                        }
                        #endregion

                }

                #region"Print out Logs"
                // Print out current test
                if (args[3] == "Flip")
                {
                    if (args[1] == "1")
                    {
                        // First line of the log 
                        csv = "Cycle #,Test Suite,Verify Boot Block on every boot,Bios Data Recovery Policy" +
                            ",Dynamic Runtime Scanning on Boot Block,Prompt on Network Controller Configuration" +
                            " Change,Sure Start BIOS Settings Protection,Enhanced HP Firmware Runtime intrusio" +
                            "n Prevention and Detection,Sure Start Security Event Policy,Lock Bios Version,P" +
                            "ass/Fail" + Environment.NewLine + Environment.NewLine;

                        File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\Change WMI Setting.csv", csv);

                        // Log result
                        csv = args[1] + "," + test + "," + wmi_one + "," + wmi_two + "," + wmi_three + "," + wmi_four +
                            "," + wmi_five + "," + wmi_six + "," + wmi_seven + "," + wmi_eight + "," + result
                            + Environment.NewLine;

                        File.AppendAllText(@"C:\Core_BIOS_Automation_Tool\Change WMI Setting.csv", csv);

                        Environment.Exit(0);
                    }

                    else
                    {
                        // Log result
                        csv = args[1] + "," + test + "," + wmi_one + "," + wmi_two + "," + wmi_three + "," + wmi_four +
                            "," + wmi_five + "," + wmi_six + "," + wmi_seven + "," + wmi_eight + "," + result
                            + Environment.NewLine;

                        File.AppendAllText(@"C:\Core_BIOS_Automation_Tool\Change WMI Setting.csv", csv);

                        Environment.Exit(0);
                    }
                }

                else if (args[3] == "Default")
                {
                    if (args[1] == "1")
                    {
                        // First line of the log 
                        csv = "Cycle #,Test Suite,Verify Boot Block on every boot,Bios Data Recovery Policy" +
                            ",Dynamic Runtime Scanning on Boot Block,Prompt on Network Controller Configuration" +
                            " Change,Sure Start BIOS Settings Protection,Enhanced HP Firmware Runtime intrusio" +
                            "n Prevention and Detection,Sure Start Security Event Policy,Lock Bios Version,P" +
                            "ass/Fail" + Environment.NewLine + Environment.NewLine;

                        File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\Set to Default WMI.csv", csv);

                        // Log result
                        csv = args[1] + "," + test + "," + wmi_one + "," + wmi_two + "," + wmi_three + "," + wmi_four +
                            "," + wmi_five + "," + wmi_six + "," + wmi_seven + "," + wmi_eight + "," + result
                            + Environment.NewLine;

                        File.AppendAllText(@"C:\Core_BIOS_Automation_Tool\Set to Default WMI.csv", csv);

                        Environment.Exit(0);
                    }

                    else
                    {
                        // Log result
                        csv = args[1] + "," + test + "," + wmi_one + "," + wmi_two + "," + wmi_three + "," + wmi_four +
                            "," + wmi_five + "," + wmi_six + "," + wmi_seven + "," + wmi_eight + "," + result
                            + Environment.NewLine;

                        File.AppendAllText(@"C:\Core_BIOS_Automation_Tool\Set to Default WMI.csv", csv);

                        Environment.Exit(0);
                    }
                }

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
                #endregion
            }
            #endregion

            #region"Invalid Argument"
            else                                                
            {
                Console.WriteLine(Environment.NewLine + "Something happened with the WinPVT script." +
                    Environment.NewLine + "Please rerun the script and if you continue to see this error " +
                    "dialog" + Environment.NewLine + "you will need to write an SIO on this script." +
                    Environment.NewLine + Environment.NewLine +
                    "Press any key to close this application and the script will fail.");
                Console.ReadLine();
            }
            #endregion

            Environment.Exit(0);
        }
        #endregion        
    }
}