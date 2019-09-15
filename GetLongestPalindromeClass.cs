using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    class GetLongestPalindromeClass
    {
        static void Main ()
        {
            Console.WriteLine("GetLongestPalindrome for"+ "12343215467 " + GetLongestPalindrome("12343215467"));
            Console.ReadLine();
        }

        private static string GetLongestPalindrome(string input)
        {
            int rightIndex = 0, leftIndex = 0;
            var x = "";
            string currentPalindrome = string.Empty;
            string longestPalindrome = string.Empty;
            for (int currentIndex = 1; currentIndex < input.Length - 1; currentIndex++)
            {
                leftIndex = currentIndex - 1;
                rightIndex = currentIndex + 1;
                while (leftIndex >= 0 && rightIndex < input.Length)
                {
                    if (input[leftIndex] != input[rightIndex])
                    {
                        break;
                    }
                    currentPalindrome = input.Substring(leftIndex, rightIndex - leftIndex + 1);
                    if (currentPalindrome.Length > x.Length)
                        x = currentPalindrome;
                    leftIndex--;
                    rightIndex++;
                }
            }
            return x;
        }
    }
}