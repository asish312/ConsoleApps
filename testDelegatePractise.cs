using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    class testDelegatePractise
    {
        public delegate  string delDisplay(string str);
        static void Main()
        {
            testDelegatePractise obj = new testDelegatePractise();
            //delDisplay delObj = obj.Display;
            delDisplay delObj = delegate (string test123) {

                return test123;
            };


            //            delDisplay delObj =obj.Display;
           // delDisplay delObj = delegate (string name)
             // {
              //    return ("Hey this is::" + name);
             // };
            string test = delObj.Invoke("Asish");


            Console.WriteLine("Hola:"+test);
            Console.ReadLine();
        }
        public  string Display(string ch)
        {
            return ("Hey this is"+ch);           
        }
    }
}
