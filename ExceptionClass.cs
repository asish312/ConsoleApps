using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    class ExceptionClass
    {
        static void Main()
        {
            try
            {
                int num = 0;
                int num1 = 1;
                int z = num1 / num;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("ArgumentException caught!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught!");
            }

            Console.WriteLine("I am some code that's running after the exception!");
            Console.ReadLine();
        }
    }
}
