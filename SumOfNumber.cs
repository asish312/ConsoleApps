using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    class SumOfNumber
    {
        static void Main()
        {
            List<int> mylist = new List<int>();
            mylist.Add(0);
            mylist.Add(1);
            mylist.Add(03);
            mylist.Add(9);
            foreach (int i in Sum(mylist))
                Console.WriteLine(i);

            Console.ReadLine();
        }
        static IEnumerable<int> Sum(IEnumerable<int> a)
        {
            int sum = 0;
            foreach (int i in a)
            {
                sum += i;
                yield return sum;
            }
        }
    }
}
