using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    class SwitchCase
    {
        void Main()
        {

            switch (1.11)
            {
                case 1.12:
                    Console.WriteLine("1.1");
                    break;
                case 1.110:
                    Console.WriteLine("1.0");
                    break;
                case 1.10:
                    Console.WriteLine("1.0");
                    break;
                default:
                    break;
            }
        }
    }
}
