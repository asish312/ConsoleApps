using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{

    class Reverse_CountEle
    {
        public Dictionary<char, int> getCount(string name)
        {
            return name.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Please Enter a string (duplicate and number of count):");
            string input = Console.ReadLine();

            //Using Dictionary
            Reverse_CountEle p = new Reverse_CountEle();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict = p.getCount(input);
            foreach (KeyValuePair<char, int> pair in dict)
            {
                Console.WriteLine(pair.Key.ToString() + "  -  " + pair.Value.ToString());
            }






            //Only Using For Loop

            Console.WriteLine("User Entered String:" + input.ToString());
            while (input.Length > 0)

            {

                Console.Write(input[0] + " : ");

                int count = 0;

                for (int j = 0; j < input.Length; j++)

                {

                    if (input[0] == input[j])

                    {

                        count++;

                    }

                }

                Console.WriteLine(count);

                input = input.Replace(input[0].ToString(), string.Empty);

            }



            Console.WriteLine(("reverse string words"));
            input = Console.ReadLine();
            string[] words = input.Split(' ');
            Array.Reverse(words);
            input = String.Join(" ", words);
            Console.WriteLine(input);



            //or 
            input = String.Join(" ", input.Split(' ').Reverse().ToArray());
            Console.WriteLine("with user defined method :"+input);


            //or


            Console.WriteLine("original string: " + input);
            StringBuilder sb = new StringBuilder();
            string[] split = input.Split(' ');
            for (int i = split.Length - 1; i > -1; i--)
            {
                sb.Append(split[i]);
                sb.Append(" ");
            }
            Console.WriteLine("original string: "+sb);
            Console.ReadLine();

          
        }
    }
}
