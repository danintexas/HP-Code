using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_BIOS_Automation_Tool.Tests
{
    class Reverse
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*
         * 
         * Used to reverse a String
         * 
        */
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
