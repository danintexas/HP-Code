using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Core_BIOS_Automation_Tool
{
    public class Testss
    {
        #region "Win PVT Version check"

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
                #region "Win PVT 7.1"
                if (File.Exists(@"c:\Program Files\Hewlett-Packard\WinPVT " +
                    @"7.1A\WinPVT.exe"))
                {
                    FileVersionInfo currentVersion = FileVersionInfo.GetVersionInfo(@"c:\Program Files\Hewlett-Packard\WinPVT " +
                        @"7.1A\WinPVT.exe");

                    // Read version & build expected from the CBAT file in the Script Tools folder
                    System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\\\" + Environment.UserName +
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
                        System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Version Check.txt", text);
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
                        System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Version Check.txt", text);
                    }
                }
                #endregion

                #region "Win PVT 8.1"
                if (File.Exists(@"c:\Program Files\Hewlett-Packard\WinPVT " +
                    @"8.1A\WinPVT.exe"))
                {
                    FileVersionInfo currentVersion = FileVersionInfo.GetVersionInfo(@"c:\Program Files\Hewlett-Packard\WinPVT " +
                        @"8.1A\WinPVT.exe");

                    // Read version & build expected from the CBAT file in the Script Tools folder
                    System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\\\" + Environment.UserName +
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
                        System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Version Check.txt", text);
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
                        System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Version Check.txt", text);
                    }
                }
                #endregion
            }

            // Run the below only if the CBAT does not exist
            else if (!File.Exists("C:\\Users\\\\" + Environment.UserName + "\\Desktop\\Core WinPVT\\Test Scripts\\" +
                "Script Tools\\CBAT"))
            {
                String text = "//CBAT was not found" + Environment.NewLine +
                        "RETURNCODE = 2";
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Version Check.txt", text);
            }

            Environment.Exit(0);    // Shut down the application
        }
        #endregion

        #region "WMI Stress"
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
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\WMI_Current.txt", text);

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

                Environment.Exit(0);    // Shut down the application
            }
        }
        #endregion

        #region "Platform Year Detection"

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

                Environment.Exit(0);    // Shut down the application
            }

            // 2016 platforms
            else if (args[0] == "Year" && args[1].Substring(0, 1) == "P")
            {
                // Build the string to print to results
                String text = "//Year detected: 2016" + Environment.NewLine + "YEAR = 2016";

                // Write log
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Year.txt", text);

                Environment.Exit(0);    // Shut down the application
            }

            // 2017 platforms
            else if (args[0] == "Year" && args[1].Substring(0, 1) == "Q")
            {
                // Build the string to print to results
                String text = "//Year detected: 2017" + Environment.NewLine + "YEAR = 2017";

                // Write log
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Year.txt", text);

                Environment.Exit(0);    // Shut down the application
            }

            else
            {
                // Build the string to print to results
                String text = "//Year detected: UNKNOWN" + Environment.NewLine + "YEAR = UNKNOWN";

                // Write log
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Year.txt", text);

                Environment.Exit(0);    // Shut down the application
            }
        }
        #endregion

        #region "Arduino Detection"

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* Arduino Detection method
         * 
         *      Arguments Expected:
         *      0:  Ard
         *      
         *      This method will check the Arduino Detection.log file located in the c:\Core_BIOS_Automation_Tool 
         *      folder and parse that log for the entry 'USB Composite Device: Arduino LLC, Arduino Leonardo, HIDPC'
         *      
         *      If that string is found then this application will write a file for WinPVT to parse with the following:
         *          arduino_detect = #
         *              # being a 1 if the device is seen and 0 if it is not seen    
         */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_Ard ()
        {
            // If the expected log file is found
            if (File.Exists("C:\\Core_BIOS_Automation_Tool\\Arduino Detection.log"))
            {
                // Reads each line of the log file
                System.IO.StreamReader file = new System.IO.StreamReader(
                    @"c:\Core_BIOS_Automation_Tool\Arduino Detection.log");
                string line, text = "";
                int arduino_detect = 0;

                while ((line = file.ReadLine()) != null) // Repeats through every line of the file till the end
                {
                    if (line.Contains("USB Composite Device: Arduino LLC, Arduino Leonardo, HIDPC"))
                    {
                        arduino_detect = 1;     
                    }
                }

                // If the expected text is found in the log
                if (arduino_detect == 1)
                    text = "//Arduino Detected " + Environment.NewLine + "ARDUINO_DETECTED = 1";

                // If the expected text is not found in the log
                if (arduino_detect == 0)
                    text = "//Arduino Not Detected " + Environment.NewLine + "ARDUINO_DETECTED = 0";

                // Write to the new file that WinPVT will read
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Arduino_Detection_Results.txt", text);

                Environment.Exit(0);    // Shut down the application
            }

            // If the expected log file is not found then default to no Arduino
            else
            {
                string text = "//Arduino Not Detected " + Environment.NewLine + "ARDUINO_DETECTED = 0";

                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Arduino_Detection_Results.txt", text);

                Environment.Exit(0);    // Shut down the application
            }
        }
        #endregion

        #region "3-3 Secure Boot Key Management"

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
                string[] fileLines = System.IO.File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\" + args[1]);

                String write = "";      // String to print out the log again

                // For each array element put said line into the string 'write'
                for (int i=2; i < fileLines.Length; i++)    // Starts on line 3 (Or array element #3)
                {
                    if (i == 2)                             // Start of the 'write' string
                        write = fileLines[i];               
                    else                                    // Every line after = appends to 'write' with new line
                        write = write + Environment.NewLine + fileLines[i];
                }

                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Stripped_" + args[1], write);

                Environment.Exit(0);    // Shut down the application
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

            Environment.Exit(0);    // Shut down the application
        }
        #endregion

        #region"5-52 LINUX REPSETUP UTILITY"

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
            if(File.Exists(@"c:\Core_BIOS_Automation_Tool\HPSETUP.TXT"))
            {
                // Read log file line by line and put into an array
                string[] fileLines = System.IO.File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\HPSETUP.TXT");

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

                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\HPSETUP_MOD.TXT", write);

                Environment.Exit(0);    // Shut down the application
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
        #endregion

        #region "6-18 SMBIOS Data Verification"

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* 6-18 SMBIOS Data Verification 
         * 
         *      Arguments Expected:
         *      0: 618UUID
         *          1: UUID as reported from WinPVT
         *      0: 618MEMORY
         *          1: Memory value reported by SMBIOS
         *      0: 618T131
         *      0: 61822
         *          1: HEX value from SMBIOS WMI call from the SBDS Manufacture Date 
         *          2: Number of the Battery (1 or 2)
         *      0: 618MAIN
         *          1: UUID
         *       
         * 
        */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_618(string[] args)
        {
            #region "UUID [618UUID] [UUID]"

            // Converts UUID reported by SMBIOS/BCU and returns the scrambled UUID reported in F10
            /*      
             *      Arguments Expected:
             *      0: 618UUID
             *      1: UUID
             * 
            */

            if (args[0] == "618UUID" && Directory.Exists(@"c:\Core_BIOS_Automation_Tool"))
            {
                char[] uuid = args[1].ToCharArray();
                char[] uuidConverted = new char[36];

                for (int i = 0; i <= 35; i++)
                {
                    #region "Per Character UUID Converstion"
                    // First eight positions
                    if (i == 0)
                        uuidConverted[i] = uuid[6];
                    if (i == 1)
                        uuidConverted[i] = uuid[7];
                    if (i == 2)
                        uuidConverted[i] = uuid[4];
                    if (i == 3)
                        uuidConverted[i] = uuid[5];
                    if (i == 4)
                        uuidConverted[i] = uuid[2];
                    if (i == 5)
                        uuidConverted[i] = uuid[3];
                    if (i == 6)
                        uuidConverted[i] = uuid[0];
                    if (i == 7)
                        uuidConverted[i] = uuid[1];

                    // Next four positions after the first '-'
                    if (i == 9)
                        uuidConverted[i] = uuid[10];
                    if (i == 10)
                        uuidConverted[i] = uuid[11];
                    if (i == 11)
                        uuidConverted[i] = uuid[8];
                    if (i == 12)
                        uuidConverted[i] = uuid[9];

                    // Next four positions after the first '-'
                    if (i == 14)
                        uuidConverted[i] = uuid[14];
                    if (i == 15)
                        uuidConverted[i] = uuid[15];
                    if (i == 16)
                        uuidConverted[i] = uuid[12];
                    if (i == 17)
                        uuidConverted[i] = uuid[13];

                    // Next 4 positions are in a row and not mixed up. 
                    // Three position deviation between the two array values.
                    if ((i < 23) && (i > 18))
                        uuidConverted[i] = uuid[i - 3];

                    // Last 11 positions are in a row and not mixed up
                    // Four position deviation between the two array values.
                    if (i > 23)
                        uuidConverted[i] = uuid[i - 4];

                    // Insert the '-' chars where it is expected
                    if ((i == 8) || (i == 13) || (i == 18) || (i == 23))
                        uuidConverted[i] = '-';
                    #endregion
                }

                // Make the file that WinPVT will read
                String text = "//Raw UUID reported: " + args[1] + Environment.NewLine + "//UUID Converted: ";

                for (int i = 0; i <= 35; i++)
                    text = text + uuidConverted[i];

                text = text + Environment.NewLine + "F10UUID = ";

                for (int i = 0; i <= 35; i++)
                    text = text + uuidConverted[i];

                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\SMBIOS_UUID_CONVERSION.txt", text);

                Environment.Exit(0);    // Shut down the application
            }
            #endregion

            #region "Memory [618MEMORY] [MEMORY]"

            // Converts memory value from SMBIOS and returns a value that is equal to what is shown in F10. 
            /*      
             *      Arguments Expected:
             *      0: 618MEMORY
             *      1: Memory value reported by SMBIOS
             * 
            */

            if (args[0] == "618MEMORY" && Directory.Exists(@"c:\Core_BIOS_Automation_Tool"))
            {
                string memory = args[1];    // Puts the Memory from WinPVT into the variable to convert
                double memoryConverted = Double.Parse(memory);

                memoryConverted = Math.Round(memoryConverted * 0.0009765625);        // Calculate the total MB of ram from the SMBIOS reported in KB

                // Make the file that WinPVT will read
                String text = "//Raw Memory reported: " + args[1] + Environment.NewLine + "//Memory Converted: " + memoryConverted +
                    Environment.NewLine + "F10MEMORYSIZE = " + memoryConverted;
                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\SMBIOS_MEMORY_CONVERSION.txt", text);

                Environment.Exit(0);    // Shut down the application

            }
            #endregion

            #region "Type 131 - OEM Defined Structures"

            // Parses the smbiosview log for Type 131 if found for the presence of any key word 'Fail'
            // except for 2 acceptable 'Fail' lines
            /*
             *      Arguments Expected:
             *      0: 618T131
             *      
             *      Files Parsed:
             *      smbios131.txt    -   SMBIOSVIEW dump file of Type 131 - OEM Defined Structure
             * 
            */

            if (args[0] == "618T131" && !File.Exists(@"c:\Core_BIOS_Automation_Tool\\smbios131.txt"))
            {
                Console.WriteLine(Environment.NewLine + "smbios131.txt log file was not detected in the " + Environment.NewLine +
                    "           'c:\\Core_BIOS_Automation_Tool' folder." + Environment.NewLine + Environment.NewLine +
                    "This could be a failure with the script. " + Environment.NewLine + Environment.NewLine +
                    "Please ensure you have Secure Boot turned off and rerun the script");
                Console.WriteLine(Environment.NewLine + Environment.NewLine + "Press <ENTER> to continue");
                Console.ReadLine();

                Environment.Exit(0);    // Shut down the application
            }

            if (args[0] == "618T131" && File.Exists(@"c:\Core_BIOS_Automation_Tool\\smbios131.txt"))
            {
                // Reads all needed information from the log file and puts it all into the winPVT list
                System.IO.StreamReader file = new System.IO.StreamReader(
                    @"c:\Core_BIOS_Automation_Tool\smbios131.txt");
                string line;
                int returnCode = 0;

                while ((line = file.ReadLine()) != null) // Repeats through every line of the file till the end
                {
                    if (line.Contains("Fail"))
                    {
                        if (line.Contains("Reserved - Offset 8-F (Must be zero)") || line.Contains("PCH Reserved (Must be zero)"))
                        {
                            // These conditions are ignored                        
                        }

                        // Set the returnCode to a value that will generate an error for WinPVT
                        else
                            returnCode = 1;
                    }
                }

                // Write the returnCode value that WinPVT will be looking for. 
                String text = "//Raw Return Code: " + returnCode + Environment.NewLine + "T131RETURNCODE = " + returnCode;
                System.IO.File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\\Type_131_Return_Code.txt", text);

                Environment.Exit(0);    // Shut down the application
            }

            #endregion

            #region "Extra Battery Calculation [61822]"

            // Converts  
            /*      
             *      Arguments Expected:
             *      0: 61822
             *          1: HEX value from SMBIOS WMI call
             *          2: Number of the Battery (1 or 2)
             * 
            */

            if (args[0] == "61822" && args.Length == 3)
            {
                string results = "", 
                    month = "", 
                    year = "", 
                    day = "";
                
                results = Convert.ToString(Convert.ToInt32(args[1], 16), 2); // Converts HEX to binary
                results = Tests.Reverse(results); //Reverse the binary 

                // Break up the binary into respective bits per the manyal test plan
                day = results.Substring(0, 5);
                month = results.Substring(5, 4);
                year = results.Substring(9);

                // Ensure the year in bits is the correct length - extend it if needed.
                if (year.Length < 7)
                {
                    while (year.Length < 7)
                    {
                        year = "0" + year;
                    }
                }

                // Reverse all binaries
                day = Tests.Reverse(day);
                month = Tests.Reverse(month);
                year = Tests.Reverse(year);

                // Convert all binaries to decimals and run calculations listed in the test plan
                int dayConverted = Convert.ToInt32(day, 2);
                int monthConverted = Convert.ToInt32(month, 2);
                int yearConverted = (Convert.ToInt32(year, 2) + 1980);

                // Convert back into strings
                day = dayConverted.ToString();
                month = monthConverted.ToString();
                year = yearConverted.ToString();

                // If day or month are single digits add a '0'
                if (day.Length < 2)
                    day = "0" + day;
                if (month.Length < 2)
                    month = "0" + month;
                
                // Write the results to a report file
                if (args[2] == "1") // Battery One
                {
                    string export = "BATT1WMIMANF10 = " + year + "/" + month + "/" + day + Environment.NewLine +
                        "BATT1WMIMANSMBIOS = " + day + "/" + month + "/" + year;
                    System.IO.File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\batt1wmiman.txt", export);
                }

                if (args[2] == "2") // Battery Two
                {
                    string export = "BATT2WMIMANF10 = " + year + "/" + month + "/" + day + Environment.NewLine +
                        "BATT2WMIMANSMBIOS = " + day + "/" + month + "/" + year;
                    System.IO.File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\batt2wmiman.txt", export);
                }
            }
            #endregion

            #region "Main Calculation of SMBIOS information"

            // Perform tasks needed for this SMBIOS Data Verification script if two arguments are sent to this application
            /*      
             *      Arguments Expected:
             *      0: 618MAIN
             *      1: UUID reported by SMBIOS
             *      
             *      All other information is parsed from SMBIOSVIEW logs that WINPVT puts into the Core_BIOS_Automation_Tool
             *      folder.
             *      
             *      Files Parsed:
             *      smbios17.txt    -   SMBIOSVIEW dump file of Type 17 - Memory
             *      smbios1.txt     -   SMBIOSVIEW dump file of Type 1 - Family 
             *      smbios13.txt    -   SMBIOSVIEW dump file of Type 13 - Languages
             *      smbios22.txt    -   SMBIOSVIEW dump file of Type 22 - Batteries
             * 
            */

            #region"Error Dialog if UUID is not passed"
            // Error dialog if 618MAIN is called but the UUID is not passed

            if (args[0] == "618MAIN" && args.Length == 1)
            {
                Console.WriteLine(Environment.NewLine + "A problem occured with this application." + Environment.NewLine +
                    Environment.NewLine + "This is usually caused if this test system has" + Environment.NewLine +
                    "      \"Secure Boot On/Legacy Mode Off\"" + Environment.NewLine +
                    Environment.NewLine + "Please boot into F10 and set it to" + Environment.NewLine +
                    "      \"Legacy Mode Enabled/Secure Boot Disabled\"" + Environment.NewLine +
                    Environment.NewLine + "Then rerun this script" + Environment.NewLine + Environment.NewLine +
                    Environment.NewLine + "Press <ENTER> to continue");
                Console.ReadLine();

                Environment.Exit(0);    // Shut down the application
            }
            #endregion

            #region"Main Calulation"
            // Run main calculation needed for script

            if (args[0] == "618MAIN" && args.Length == 2)
            {
                // Type 1 - UUID Conversion section
                #region "UUID Conversion"

                string uuid = args[1];      // Puts the UUID from WinPVT into the variable to convert
                int pre = uuid.Length;      // Get the length of the UUID reported

                // Take RAW SMBIOS UUID and put a space after each two characters
                for (int i = 2; i <= uuid.Length; i += 2)
                {
                    uuid = uuid.Insert(i, " ");
                    i++;
                }

                // Take the spaced our UUID and replace the 24th char slot with a '-'
                StringBuilder uuidFixed = new StringBuilder(uuid);
                uuidFixed[23] = '-';

                // Convert back to a string
                uuid = uuidFixed.ToString();

                // Make the file that WinPVT will parse
                String text = "Raw UUID reported: " + args[1] + Environment.NewLine + "UUID Converted: " + uuid;
                System.IO.File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\SMBIOS_Type_1_UUID.txt", text);

                #endregion

                #region "Type 17 - Memory"
                // Type 17 Memory section

                if (File.Exists(@"C:\Core_BIOS_Automation_Tool\smbios17.txt"))    // Run Application only if the expected log file exists
                {
                    int counter = 0, memoryCount = 0;           // Counters used for the below
                    string line;                                // Temp place holder when parsing the log
                    List<string> winPVT = new List<string>();   // List array type that will scale for how many memory sticks are on the machine

                    // Reads all needed information from the log file and puts it all into the winPVT list
                    System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Core_BIOS_Automation_Tool\smbios17.txt");

                    while ((line = file.ReadLine()) != null) // Repeats through every line of the file till the end
                    {
                        // Pulls in the size of the memory
                        if (line.Contains("Size: "))
                        {
                            winPVT.Add(line);
                            counter++;
                        }

                        // Pulls in the location of the memory
                        if (line.Contains("DeviceLocator: "))
                        {
                            winPVT.Add(line);
                            counter++;
                        }

                        // Pulls in the speed of the memory
                        if (line.Contains("Speed: "))
                        {
                            // Pull the hex value from the log and convert into a decimal
                            String speedTemp = line.Substring(line.LastIndexOf("x") + 1);
                            int value = Int32.Parse(speedTemp, System.Globalization.NumberStyles.HexNumber);

                            winPVT.Add("Speed: " + value);
                            counter++;
                        }

                        // Pulls in the manufacturer of the memory
                        if (line.Contains("Manufacturer: "))
                        {
                            winPVT.Add(line);
                            counter++;
                        }

                        // Pulls in the part number of the memory
                        if (line.Contains("PartNumber: "))
                        {
                            winPVT.Add(line);
                            counter++;
                        }

                        // Pulls in the serial number
                        if (line.Contains("SerialNumber: "))
                        {
                            winPVT.Add(line);
                            counter++;
                        }
                    }


                    //memoryCount = counter;     // Counts the size of the list 'winPVT'
                    String memoryOne = "", memoryTwo = "", memoryThree = "", memoryFour = ""; // Sets up the strings to write to files

                    // Writes the information for the first memory slot
                    for (int i = 0; i <= 5; i++)
                    {
                        memoryOne = memoryOne + winPVT[i] + Environment.NewLine;
                    }

                    System.IO.File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\memOne.txt", memoryOne);

                    // Writes the information for the second memory slot if the log was big enough
                    if (counter > 5)
                    {
                        for (int i = 6; i <= 11; i++)
                        {
                            memoryTwo = memoryTwo + winPVT[i] + Environment.NewLine;
                        }

                        System.IO.File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\memTwo.txt", memoryTwo);
                    }

                    // Writes the information for the third memory slot if the log was big enough
                    if (counter > 12)
                    {
                        for (int i = 12; i <= 17; i++)
                        {
                            memoryThree = memoryThree + winPVT[i] + Environment.NewLine;
                        }

                        System.IO.File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\memThree.txt", memoryThree);
                    }

                    // Writes the information for the fourth memory slot if the log was big enough
                    if (counter > 18)
                    {
                        for (int i = 18; i <= 23; i++)
                        {
                            memoryFour = memoryFour + winPVT[i] + Environment.NewLine;
                        }

                        System.IO.File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\memFour.txt", memoryFour);
                    }
                }

                #endregion

                #region "Family"
                // Type 1 Family section
                if (File.Exists(@"c:\Core_BIOS_Automation_Tool\smbios1.txt"))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(
                        @"c:\Core_BIOS_Automation_Tool\smbios1.txt");
                    string line = "";
                    string parseValue = "";
                    List<string> winPVT2 = new List<string>();

                    while (line != "$")
                    {
                        line = file.ReadLine();
                    }

                    for (int i = 0; i <= 4; i++)
                        line = file.ReadLine();


                    while (line != "")
                    {

                        line = line.Split('*', '*')[1];

                        parseValue = parseValue + line;
                        line = file.ReadLine();
                    }

                    // Make the file that WinPVT will parse
                    text = "Family information parsed: " + parseValue;
                    System.IO.File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\SMBIOS_Type_1_Family.txt", text);

                    // Closes out the System.IO.File calls
                    file.Close();
                }

                #endregion

                #region "Languages"
                // Type 13 Languages section

                if (File.Exists(@"c:\Core_BIOS_Automation_Tool\smbios13.txt"))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(@"c:\Core_BIOS_Automation_Tool\smbios13.txt");
                    string line = "";
                    string parseValue = "";
                    List<string> winPVT2 = new List<string>();

                    while (line != "$")
                    {
                        line = file.ReadLine();
                    }

                    for (int i = 0; i <= 4; i++)
                        line = file.ReadLine();


                    while (line != "")
                    {

                        line = line.Split('*', '*')[1];

                        parseValue = parseValue + line;
                        line = file.ReadLine();
                    }

                    // Make the file that WinPVT will parse
                    text = "Type 13: Available Languages parsed: " + parseValue;
                    System.IO.File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\SMBIOS_Type_13_Languages.txt", text);

                    // Closes out the System.IO.File calls
                    file.Close();
                }
                #endregion

                #region "Batteries"
                // Type 22 Battery section

                if (File.Exists(@"c:\Core_BIOS_Automation_Tool\smbios22.txt"))    // Run Application only if the 
                                                                                  //expected log file exists
                {
                    int counter = 0, battCount = 0, battCount2 = 0, battCount3 = 0;           // Counters used for the below
                    String export = "";
                    string line;                                // Temp place holder when parsing the log
                    List<string> winPVT = new List<string>();   // List array type that will scale for how many 
                                                                // batteries there are on the machine

                    // Reads all needed information from the log file and puts it all into the winPVT list
                    System.IO.StreamReader file = new System.IO.StreamReader(
                        @"c:\Core_BIOS_Automation_Tool\smbios22.txt");

                    while ((line = file.ReadLine()) != null) // Repeats through every line of the file till the end
                    {
                        // Pulls in the Location of the battery
                        if (line.Contains("Location: "))
                        {
                            winPVT.Add(line);
                            counter++;
                        }

                        // Pulls in the Manufacturer of the battery
                        if (line.Contains("Manufacturer: "))
                        {
                            winPVT.Add(line);
                            counter++;
                        }

                        // Pulls in the Serial Number of the battery
                        if (line.Contains("SerialNumber: "))
                        {
                            // Pulls in the SBDSSerialNumber of the battery
                            if (line.Contains("SBDSSerialNumber: "))
                            {
                                battCount2++;
                                winPVT.Add(line);
                                string value = line.Substring(line.LastIndexOf(' ') + 1);
                                
                                if (battCount2 == 1)
                                {
                                    export = "BATT_1_SBDSSER = " + value;
                                    System.IO.File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\battSerial.txt", export);
                                }

                                if (battCount2 == 2)
                                {
                                    export = Environment.NewLine + "BATT_2_SBDSSER = " + value;
                                    System.IO.File.AppendAllText(@"c:\Core_BIOS_Automation_Tool\battSerial.txt", export);
                                }

                                counter++;
                            }

                            else
                            {
                                winPVT.Add(line);
                                counter++;
                            }
                        }

                        // Pulls in the Battery Date of the battery
                        if (line.Contains("ManufactureDate: "))
                        {
                            winPVT.Add(line);
                            counter++;
                        }

                        // Pulls in the SBDS Manufacture Date of the battery
                        if (line.Contains("SBDS Manufacture Date: "))
                        {
                            battCount3++;
                            winPVT.Add(line);
                            string value = line.Substring(line.LastIndexOf(' ') + 1);

                            if (battCount3 == 1)
                            {
                                export = "BATT_1_SBDSMAN = " + value;
                                System.IO.File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\battMan.txt", export);
                            }

                            if (battCount3 == 2)
                            {
                                export = Environment.NewLine + "BATT_2_SBDSMAN = " + value;
                                System.IO.File.AppendAllText(@"c:\Core_BIOS_Automation_Tool\battMan.txt", export);
                            }

                            counter++;
                        }
                    }

                    if (counter > 0)
                    {
                        battCount = winPVT.Count;     // Counts the size of the list 'winPVT'
                        
                        String batteryOne = "", batteryTwo = ""; // Sets up the strings to write to files

                        // Writes the information for the first battery
                        for (int i = 0; i <= 5; i++)
                        {
                            batteryOne = batteryOne + winPVT[i] + Environment.NewLine;
                        }
                        

                        System.IO.File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\battOne.txt", batteryOne);
                        
                        // Writes the information for the second battery if the log was big enough
                        if (battCount > 6)
                        {
                            for (int i = 6; i <= 11; i++)
                            {
                                batteryTwo = batteryTwo + winPVT[i] + Environment.NewLine;
                            }

                            System.IO.File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\battTwo.txt", batteryTwo);
                        }

                        // Closes out the System.IO.File calls
                        file.Close();
                    }
                }

                #endregion

                Environment.Exit(0);    // Shut down the application
            }
            #endregion

            #endregion
        }
        #endregion

        #region "6-13 BIOS Scheduled Power-On WMI "
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
            #region "getfile.txt parse"
            if (File.Exists(@"c:\Core_BIOS_Automation_Tool\getfile.txt") && args.Length == 1)
            {
                string[] fileLines = System.IO.File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\getfile.txt");

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

                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\GETFILE_Results.txt", text);

                Environment.Exit(0);    // Shut down the application
            }
            #endregion

            #region "Return seconds to next Sun at 10am"
            if (args[1] == "1")
            {
                DateTime now = DateTime.Now;
                string day = now.ToString("dddd");

                int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)now.DayOfWeek + 7) % 7;
                int seconds = daysUntilSunday * 86400;
                string write = "//Days till next Sunday: " + daysUntilSunday + Environment.NewLine +
                    "//Seconds till next Sunday: " + seconds + Environment.NewLine +
                    "SECONDS_TILL_SUNDAY = " + seconds;

                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Sunday_Calc.txt", write);

                Environment.Exit(0);    // Shut down the application
            }
            #endregion

            #region "Invalid argument or getfile.txt was not found"
            else                // File not found
            {
                Console.WriteLine(Environment.NewLine + "Something happened with the WinPVT script." +
                Environment.NewLine + "The getfile.txt file was not found or an invalid argument was passed." +
                Environment.NewLine + "Please rerun the script and if you continue to see this error " +
                "dialog" + Environment.NewLine + "you will need to write an SIO on this script." +
                Environment.NewLine + Environment.NewLine +
                "Press any key to close this application and the script will fail.");
                Console.ReadLine();

                Environment.Exit(0);    // Shut down the application
            }
            #endregion
        }
        #endregion

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

        #region"Reverse a String"

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*
         * 
         * Used to reverse a String
         * 
        */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        #endregion

        #region"Time"
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*
         * 
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

                System.IO.File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);

                Environment.Exit(0);    // Shut down the application

            }

            if (args[1] == "1" && File.Exists(@"c:\Core_BIOS_Automation_Tool\Restart_Difference.txt"))
            {
                string time = DateTime.Now.ToString();

                string write = "// Time After the restart = " + time + Environment.NewLine +
                    "TESTINPUT_TIMEAFTER = " + time + Environment.NewLine;

                System.IO.File.AppendAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);

                Environment.Exit(0);    // Shut down the application
            }

            if (args[1] == "2" && File.Exists(@"c:\Core_BIOS_Automation_Tool\Restart_Difference.txt"))
            {
                // Read log file line by line and put into an array
                string[] fileLines = System.IO.File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\Restart_Difference.txt");

                string before = "", after = "";

                String write = "";      // String to print out the log again

                // For each array element put said line into the string 'write'
                for (int i = 0; i < fileLines.Length; i++)
                {
                    // Look for TESTINPUT_TIMEBEFORE || TESTINPUT_TIMEAFTER
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

                    System.IO.File.AppendAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);
                }

                else
                {
                    write = "//Difference is: " + diff + Environment.NewLine +
                    "TIME_DIFFERENCE = PASS";

                    System.IO.File.AppendAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);
                }

                Environment.Exit(0);    // Shut down the application
            }

            if (args[1] == "3" && File.Exists(@"c:\Core_BIOS_Automation_Tool\Restart_Difference.txt"))
            {
                // Read log file line by line and put into an array
                string[] fileLines = System.IO.File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\Restart_Difference.txt");

                string before = "", after = "";

                String write = "";      // String to print out the log again

                // For each array element put said line into the string 'write'
                for (int i = 0; i < fileLines.Length; i++)
                {
                    // Look for TESTINPUT_TIMEBEFORE || TESTINPUT_TIMEAFTER
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

                    System.IO.File.AppendAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);
                }

                else
                {
                    write = "//Difference is: " + diff + Environment.NewLine +
                    "TIME_DIFFERENCE = PASS";

                    System.IO.File.AppendAllText("c:\\Core_BIOS_Automation_Tool\\Restart_Difference.txt", write);
                }

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
            }
        }
        #endregion
    }
}