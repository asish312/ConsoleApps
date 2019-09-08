using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    class TestProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter A string");
            string str = Console.ReadLine();
            //            Console.WriteLine(StrReverse(str));
               Console.WriteLine(StrReverse1(str));
            //Console.WriteLine(stringReverseString5(str));
            Console.ReadLine();

        }
        static string StrReverse(string OldString)
        {
            char[] chrArray = OldString.ToCharArray();
            Array.Reverse(chrArray);
            OldString = new string(chrArray);
            return OldString;
        }
        static string StrReverse1(string OldString)
        {
            if (OldString == null) return null;

            char[] chrArray = OldString.ToCharArray();
            int len = OldString.Length - 1;

            for (int i = 0; i < len; i++, len--)
            {
                chrArray[i] ^= chrArray[len];
                chrArray[len] ^= chrArray[i];
                chrArray[i] ^= chrArray[len];
              
            }

            return new string(chrArray);

        }
        public static string stringReverseString5(string str)
        {
            char[] inputstream = str.ToCharArray();
            int length = str.Length - 1;
            for (int i = 0; i < length; i++, length--)
            {
                inputstream[i] ^= inputstream[length];
                inputstream[length] ^= inputstream[i];
                inputstream[i] ^= inputstream[length];
            }
            return new string(inputstream);
        }


    }
}
