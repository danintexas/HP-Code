using System;
using System.IO;

namespace Core_BIOS_Automation_Tool.Tests
{
    class Parse
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /* Parse a logfile
         * 
         *      Arguments Expected
         *      0: Parse
         *      1: Keyword or phrase to look for
         *      2: Filename to parse 
        */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_Parse(string[] args)
        {
            if (File.Exists(@"c:\Core_BIOS_Automation_Tool\" + args[2]))
            {
                string[] fileLines = File.ReadAllLines(@"c:\Core_BIOS_Automation_Tool\" + args[2]);
                string write = "";

                for (int i = 0; i < fileLines.Length; i++)
                {
                    if (fileLines[i].Contains(args[1]))
                    {
                        write = (fileLines[i].Substring(fileLines[i].LastIndexOf(args[1]) + (args[1].Length + 1)));
                    }
                }

                write = "// File parsed = " + args[2] + Environment.NewLine +
                    "//Keyword to look for = " + args[1] + Environment.NewLine +
                    Environment.NewLine + "KEYWORD_PARSED = " + write;

                File.WriteAllText("c:\\Core_BIOS_Automation_Tool\\Keyword_Parsed.txt", write);

                Environment.Exit(0);   
            }

            else 
            {
                Console.WriteLine(Environment.NewLine + "Something happened with the WinPVT script." +
                    Environment.NewLine + "Please rerun the script and if you continue to see this error " +
                    "dialog" + Environment.NewLine + "you will need to write an SIO on this script." +
                    Environment.NewLine + Environment.NewLine + @"File: c:\Core_BIOS_Automation_Tool\" + args[2] +
                    " Not found" + Environment.NewLine + Environment.NewLine +
                    "Press any key to close this application and the script will fail.");
                Console.ReadLine();
            }

            Environment.Exit(0);
        }
    }
}
