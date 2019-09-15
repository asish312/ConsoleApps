using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    public class Temp
    {
    


    static void Main(string[] args)
        {
            //Console.WriteLine("Please Enter a number");
            //string str=Console.ReadLine();

            //// convert the string to char array
            //char[] charArray = str.ToCharArray();
            //int len = str.Length - 1;


            //for (int i = 0; i < len; i++, len--)
            //{
            //    charArray[i] ^= charArray[len];
            //    charArray[len] ^= charArray[i];
            //    charArray[i] ^= charArray[len];            
            //}
            //string test= new string(charArray);
            //Console.WriteLine(test);

            //Console.ReadLine();

            //---------------------------------------------
            Console.WriteLine("Please Enter a number");
            string inputStr = Console.ReadLine();
            char[] revStr = inputStr.ToCharArray();
            int count = inputStr.Length-1;
            for (int i = 0; i < count; i++)
            {
                revStr[i] ^= revStr[count];
                revStr[count] ^= revStr[i];
                revStr[i] ^= revStr[count];
                count = count - 1;
            }
            inputStr = new string(revStr);
            Console.WriteLine(inputStr);
            Console.ReadLine();
        }
    }
}
