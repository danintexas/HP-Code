using System;
using System.IO;

namespace Core_BIOS_Automation_Tool.Tests
{
    class ArduinoDetection
    {
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
        public static void Test_Ard()
        {
            // If the expected log file is found
            if (File.Exists("C:\\Core_BIOS_Automation_Tool\\Arduino Detection.log"))
            {
                // Reads each line of the log file
                StreamReader file = new StreamReader(
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
                File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Arduino_Detection_Results.txt", text);

                Environment.Exit(0);    // Shut down the application
            }

            // If the expected log file is not found then default to no Arduino
            else
            {
                string text = "//Arduino Not Detected " + Environment.NewLine + "ARDUINO_DETECTED = 0";

               File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Arduino_Detection_Results.txt", text);

                Environment.Exit(0);    // Shut down the application
            }
        }
    }
}
