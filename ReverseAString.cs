using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    class ReverseAString
    {
        public static string answer = "";
        static void Main(string[] args)
        {
            do
            {
                //Ask the user if they want to roll the dice
                Console.WriteLine("Hola! {0} Would you like to roll the dice (y or n)?", Environment.MachineName);
                //Get the user's response and validate that it is either 'y' or 'n'.
                answer = Console.ReadLine();
                //Perform some Operations
                doScheduler();             
            } while (answer == "y");
        }
       static void doScheduler()
        {        
            Console.WriteLine("Please enter which Task would you like to perform? Enter only Integer value follwed by Enter key..");
            Console.WriteLine("1. > Reverse a string");
            Console.WriteLine("2. > Storing in List and Displaying");
            int userOption = Convert.ToInt32(Console.ReadLine());
            switch (userOption)
            {
                case 1:
                    ReverseMyString();
                    break;
                case 2:
                    DisplayAuthor();
                        break;

                default:
                    Console.WriteLine("Invalid choice.We are sorry to let you go in 5 Seconds :( ");
                    System.Threading.Thread.Sleep(5000);
                    break;
            }
        }
        public static void ReverseMyString()
        {
            string myString = "In the game of mahjong \U0001F01C denotes the Four of circles";
            Console.WriteLine(myString);
            string fourCircles = char.ConvertFromUtf32(0x1F01C);
            Console.WriteLine(fourCircles);
            string myStringNew = "In the game of mahjong 🀜 denotes the Four of circles";
            Console.WriteLine(myStringNew);

            //Console.WriteLine("Please Enter the String:");
           // string str = Console.ReadLine();
            char[] chrArray = myString.ToCharArray();
            Array.Reverse(chrArray);
            myString = new string(chrArray);
            Console.WriteLine(myString);
            Console.ReadLine();

      
            //  var query = someList.Where(a => (someCondition) ? a == "something" : true);
        }

        public static void DisplayAuthor()
        {
       

        }

    }
}