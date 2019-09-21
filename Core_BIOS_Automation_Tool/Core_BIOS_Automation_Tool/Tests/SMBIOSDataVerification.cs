using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core_BIOS_Automation_Tool.Tests
{
    class SMBIOSDataVerification
    {
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
                }

                // Make the file that WinPVT will read
                String text = "//Raw UUID reported: " + args[1] + Environment.NewLine + "//UUID Converted: ";

                for (int i = 0; i <= 35; i++)
                    text = text + uuidConverted[i];

                text = text + Environment.NewLine + "F10UUID = ";

                for (int i = 0; i <= 35; i++)
                    text = text + uuidConverted[i];

                File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\SMBIOS_UUID_CONVERSION.txt", text);

                Environment.Exit(0);    // Shut down the application
            }

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
                File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\SMBIOS_MEMORY_CONVERSION.txt", text);

                Environment.Exit(0);    // Shut down the application

            }

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

                Environment.Exit(0);
            }

            if (args[0] == "618T131" && File.Exists(@"c:\Core_BIOS_Automation_Tool\\smbios131.txt"))
            {
                // Reads all needed information from the log file and puts it all into the winPVT list
                StreamReader file = new System.IO.StreamReader(
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
                File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\\Type_131_Return_Code.txt", text);

                Environment.Exit(0);
            }

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
                results = Reverse.ReverseString(results); //Reverse the binary 

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
                day = Reverse.ReverseString(day);
                month = Reverse.ReverseString(month);
                year = Reverse.ReverseString(year);

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
                    File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\batt1wmiman.txt", export);
                }

                if (args[2] == "2") // Battery Two
                {
                    string export = "BATT2WMIMANF10 = " + year + "/" + month + "/" + day + Environment.NewLine +
                        "BATT2WMIMANSMBIOS = " + day + "/" + month + "/" + year;
                    File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\batt2wmiman.txt", export);
                }
            }

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

                Environment.Exit(0);  
            }

            // Run main calculation needed for script
            if (args[0] == "618MAIN" && args.Length == 2)
            {
                // Type 1 - UUID Conversion section

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
                File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\SMBIOS_Type_1_UUID.txt", text);

                // Type 17 Memory section
                if (File.Exists(@"C:\Core_BIOS_Automation_Tool\smbios17.txt"))    // Run Application only if the expected log file exists
                {
                    int counter = 0;           
                    string line;                                // Temp place holder when parsing the log
                    List<string> winPVT = new List<string>();   // List array type that will scale for how many memory sticks are on the machine

                    // Reads all needed information from the log file and puts it all into the winPVT list
                    StreamReader file = new StreamReader(@"C:\Core_BIOS_Automation_Tool\smbios17.txt");

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

                    String memoryOne = "", memoryTwo = "", memoryThree = "", memoryFour = ""; // Sets up the strings to write to files

                    // Writes the information for the first memory slot
                    for (int i = 0; i <= 5; i++)
                    {
                        memoryOne = memoryOne + winPVT[i] + Environment.NewLine;
                    }

                    File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\memOne.txt", memoryOne);

                    // Writes the information for the second memory slot if the log was big enough
                    if (counter > 5)
                    {
                        for (int i = 6; i <= 11; i++)
                        {
                            memoryTwo = memoryTwo + winPVT[i] + Environment.NewLine;
                        }

                       File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\memTwo.txt", memoryTwo);
                    }

                    // Writes the information for the third memory slot if the log was big enough
                    if (counter > 12)
                    {
                        for (int i = 12; i <= 17; i++)
                        {
                            memoryThree = memoryThree + winPVT[i] + Environment.NewLine;
                        }

                        File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\memThree.txt", memoryThree);
                    }

                    // Writes the information for the fourth memory slot if the log was big enough
                    if (counter > 18)
                    {
                        for (int i = 18; i <= 23; i++)
                        {
                            memoryFour = memoryFour + winPVT[i] + Environment.NewLine;
                        }

                        File.WriteAllText(@"C:\Core_BIOS_Automation_Tool\memFour.txt", memoryFour);
                    }
                }

                // Type 1 Family section
                if (File.Exists(@"c:\Core_BIOS_Automation_Tool\smbios1.txt"))
                {
                    StreamReader file = new System.IO.StreamReader(
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
                    File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\SMBIOS_Type_1_Family.txt", text);

                    // Closes out the System.IO.File calls
                    file.Close();
                }

                // Type 13 Languages section
                if (File.Exists(@"c:\Core_BIOS_Automation_Tool\smbios13.txt"))
                {
                    StreamReader file = new StreamReader(@"c:\Core_BIOS_Automation_Tool\smbios13.txt");
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
                    File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\SMBIOS_Type_13_Languages.txt", text);

                    // Closes out the System.IO.File calls
                    file.Close();
                }

                // Type 22 Battery section
                if (File.Exists(@"c:\Core_BIOS_Automation_Tool\smbios22.txt"))    // Run Application only if the expected log file exists
                {
                    int counter = 0, battCount = 0, battCount2 = 0, battCount3 = 0;           // Counters used for the below
                    String export = "";
                    string line;                                // Temp place holder when parsing the log
                    List<string> winPVT = new List<string>();   // List array type that will scale for how many 
                                                                // batteries there are on the machine

                    // Reads all needed information from the log file and puts it all into the winPVT list
                    StreamReader file = new StreamReader(
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
                                    File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\battSerial.txt", export);
                                }

                                if (battCount2 == 2)
                                {
                                    export = Environment.NewLine + "BATT_2_SBDSSER = " + value;
                                    File.AppendAllText(@"c:\Core_BIOS_Automation_Tool\battSerial.txt", export);
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
                                File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\battMan.txt", export);
                            }

                            if (battCount3 == 2)
                            {
                                export = Environment.NewLine + "BATT_2_SBDSMAN = " + value;
                                File.AppendAllText(@"c:\Core_BIOS_Automation_Tool\battMan.txt", export);
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


                        File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\battOne.txt", batteryOne);

                        // Writes the information for the second battery if the log was big enough
                        if (battCount > 6)
                        {
                            for (int i = 6; i <= 11; i++)
                            {
                                batteryTwo = batteryTwo + winPVT[i] + Environment.NewLine;
                            }

                            File.WriteAllText(@"c:\Core_BIOS_Automation_Tool\battTwo.txt", batteryTwo);
                        }

                        // Closes out the System.IO.File calls
                        file.Close();
                    }
                }

                Environment.Exit(0);
            }
        }
    }
}
